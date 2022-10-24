using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using UDRF.Adapters.BcNodeAdapter;
using UDRF.Data;
using UDRF.Dto.BcNodeDto;
using UDRF.Dto.FilterDto;
using UDRF.Services.BcNodeService;

namespace UDRF.Area.Api
{
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    //[Authorize(Policy = "BcNode")]
    public class BcNodeController : ControllerBase

    {
        private UserManager<IdentityUser> _userManager;
        private readonly IBcNodeService _bcNodeService;
        private readonly IBcNodeAdapter _bcNodeAdapter;

        public BcNodeController(UserManager<IdentityUser> userManager,
            IBcNodeService bcNodeService, IBcNodeAdapter bcNodeAdapter)
        {
            _userManager = userManager;
            _bcNodeService = bcNodeService;
            _bcNodeAdapter = bcNodeAdapter;
        }
        [HttpGet]
        public async Task<IActionResult> GetProfile()
        {
            var loggedUser = await _userManager.GetUserAsync(HttpContext.User);
            //var loggedUser2 = await _userManager.GetUserAsync(HttpContext.);
            if (loggedUser == null)
                return BadRequest("user not found");
            var role = User.Claims.Where(x => x.Type == ClaimTypes.Role).Select(x => x.Value).FirstOrDefault();
            return Ok(role);
        }
        
        
        [HttpPost]
        [AllowAnonymous]
        
        public IActionResult Sum(string val1, string val2)
        {
            int sum1, sum2;
            int.TryParse(val1, out sum1);
            int.TryParse(val2, out sum2);
            var result = sum1 + sum2;
            return Ok(result.ToString());
        }
        [HttpPost]
        public IActionResult LoadBcNodes ([FromBody] BaseFilter filters)
        {
            
            try 
            {
                if (filters == null)
                    throw new ArgumentNullException(nameof(filters));
                var data = _bcNodeAdapter.ConvertBcNodesToDTOs(_bcNodeService.GetBcNodes(filters)).ToList();

                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            

        }
        [HttpGet]
        public IActionResult LoadAllBcNodes()
        {
            return Ok( _bcNodeAdapter.ConvertBcNodesToDTOs(_bcNodeService.GetAllBcNodes()).ToList() );

        }
    }
}
