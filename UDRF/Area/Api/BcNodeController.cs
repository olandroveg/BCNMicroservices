using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using UDRF.Adapters.BcNodeAdapter;
using UDRF.Adapters.BcNodeContentAdapter;
using UDRF.Adapters.ContentAdapter;
using UDRF.Data;
using UDRF.Dto;
using UDRF.Dto.BcNodeContentDto;
using UDRF.Dto.BcNodeDto;
using UDRF.Dto.FilterDto;
using UDRF.Services.BcNodeContentService;
using UDRF.Services.BcNodeService;
using UDRF.Services.ContentService;

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
        private readonly IBcNodeContentAdapter _bcNodeContentAdapter;
        private readonly IBcNodeContentService _bcNodeContentService;
        private readonly IContentAdapter _contentAdapter;
        private readonly IContentService _contentService;

        public BcNodeController(UserManager<IdentityUser> userManager,
            IBcNodeService bcNodeService, IBcNodeAdapter bcNodeAdapter,
            IBcNodeContentAdapter bcNodeContentAdapter, IBcNodeContentService bcNodeContentService,
            IContentAdapter contentAdapter, IContentService contentService)
        {
            _userManager = userManager;
            _bcNodeService = bcNodeService;
            _bcNodeAdapter = bcNodeAdapter;
            _bcNodeContentAdapter = bcNodeContentAdapter;
            _bcNodeContentService = bcNodeContentService;
            _contentAdapter = contentAdapter;
            _contentService = contentService;
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

                var data = new List<BcNodeDto>();
                if (filters.IsAdmin)
                    data = _bcNodeAdapter.ConvertBcNodesToDTOs(_bcNodeService.GetAllBcNodes()).ToList();
                else
                    data = _bcNodeAdapter.ConvertBcNodesToDTOs(_bcNodeService.GetBcNodes(filters)).ToList();

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
        [HttpPost]
        public IActionResult GetBcNode ([FromBody] Guid bcNodeId)
        {
            if (bcNodeId == Guid.Empty)
                return BadRequest("bcNode Id empty");
            var data = new BcNodeDto();
            try
            {
                data = _bcNodeAdapter.ConvertBcNodeToDTO(_bcNodeService.GeBcNode(bcNodeId));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
             
            return Ok(data);
        }
        [HttpPost]
        public async Task<IActionResult> ReceiveBcNode([FromBody] BcNodeDto bcNodeDto)
        {
            try
            {
                if (bcNodeDto == null)
                    throw new ArgumentNullException(nameof(bcNodeDto));
                var bcNodeId = Guid.Empty;
                bcNodeId = await _bcNodeService.AddOrUpdate(_bcNodeAdapter.ConvertDtoToBcNode(bcNodeDto));
                return Ok(bcNodeId);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }
        [HttpPost]
        public IActionResult LoadBcNodeContents([FromBody] BaseFilter filters)
        {

            try
            {
                if (filters == null)
                    throw new ArgumentNullException(nameof(filters));

                var data = _bcNodeContentAdapter.ConvertBcNodesContentToDTOs(_bcNodeContentService.GetBcNodeContents(filters));
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }


        }
        [HttpPost]
        public IActionResult LoadContents([FromBody] string bcNodeId)
        {

            try
            {
                if (bcNodeId == string.Empty)
                    throw new ArgumentNullException(nameof(bcNodeId));

                var data = _contentAdapter.ConvertContentsToDtos(_contentService.GetAllContents()).Select(x => new BaseDTO
                {
                    Id = x.Id,
                    Name = x.Name
                });
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }


        }
        [HttpPost]
        public async Task<IActionResult> ReceiveBcNodeContents([FromBody] BcNodeContentDto bcNodeContentDto)
        {
            try
            {
                if (bcNodeContentDto == null)
                    throw new ArgumentNullException(nameof(bcNodeContentDto));
                var bcNodeContentId = Guid.Empty;
                bcNodeContentId = await _bcNodeContentService.AddOrUpdate(_bcNodeContentAdapter.ConvertDtoToBcNodeContent(bcNodeContentDto));
                return Ok(bcNodeContentId);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpPost]
        public IActionResult GetBcNodeContentDto([FromBody] Guid bcNodeContentId)
        {

            try
            {
                if (bcNodeContentId == Guid.Empty)
                    throw new ArgumentNullException(nameof(bcNodeContentId));

                var bcNodeContentDto = _bcNodeContentAdapter.ConvertBcNodeContentToDto(_bcNodeContentService.GetBcNodeContentById(bcNodeContentId));
                return Ok(bcNodeContentDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }


        }
    }
}
