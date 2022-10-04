using AANF.Classes;
using AANF.Data;
using AANF.Utility;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AANF.Areas.Api
{
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    public class AuthController : ControllerBase
    {
        
        
        ApplicationDbContext _context;
        UserManager<IdentityUser> _userManager;

        public AuthController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        [HttpPost]
        public async Task<IActionResult> GetToken([FromBody] UserToken userToken)
        {
            if (userToken == null || string.IsNullOrEmpty(userToken.User) || string.IsNullOrEmpty(userToken.Password))
                return BadRequest();
            var userValid = await VerifyUserValid(userToken.User, userToken.Password);
            if (!userValid)
                return BadRequest();
            return Ok(await GenerateToken(userToken.User));


        }
        private async Task<dynamic> GenerateToken(string username)
        {
            var user = await _userManager.FindByEmailAsync(username);
            var role = _context.Roles.Where(x => x.Id == _context.UserRoles.Where(e => e.UserId == user.Id).Select(e => e.RoleId).FirstOrDefault()).FirstOrDefault().Name;

            var jwtTokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(StaticConfigurationManager.AppSetting["TokenSecret:Key"]);
            var issuer =StaticConfigurationManager.AppSetting["TokenSecret:Issuer"];
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim("Id", user.Id),
                    new Claim (ClaimTypes.NameIdentifier, user.Id),
                    new Claim(JwtRegisteredClaimNames.Email, user.Email),
                    new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                    new Claim(ClaimTypes.Role, role)
                }),
                Expires = DateTime.UtcNow.AddSeconds(20),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                Issuer = issuer,
                Audience = issuer
            };
            var token = jwtTokenHandler.CreateToken(tokenDescriptor);
            var jwToken = jwtTokenHandler.WriteToken(token);
            return string.IsNullOrEmpty(jwToken) ? new JwtAuthResponse { Token = "", Status = "Unsuccess" } : new JwtAuthResponse { Token = jwToken, Status = "Success", UserName = username };


        }
        private async Task<bool> VerifyUserValid(string username, string password)
        {
            var user = await _userManager.FindByEmailAsync(username);
            if (user != null)
            {
                var isValid = await _userManager.CheckPasswordAsync(user, password);
                return isValid;
            }

            return false;

        }
    }
}
