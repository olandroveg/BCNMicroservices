using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UDRF.Adapters.ContentAdapter;
using UDRF.Adapters.ServicesAdapter;
using UDRF.Services.ContentService;
using UDRF.Services.ServicesService;

namespace UDRF.Area.Api
{
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class ContentController : Controller
    {
        private readonly IContentService _contentService;
        private readonly IContentAdapter _contentAdapter;
        private readonly IServicesAdapter _servicesAdapter;
        private readonly IServicesService _servicesService;
        
        public ContentController (IContentService contentService,
            IContentAdapter contentAdapter,
            IServicesAdapter servicesAdapter, 
            IServicesService servicesService)
            {
            _contentService = contentService;
            _contentAdapter = contentAdapter;
            _servicesAdapter = servicesAdapter;
            _servicesService = servicesService;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult GetAllContents()
        {
            try
            {
                var data = _contentAdapter.ConvertContentsToTableDtos(_contentService.GetAllContents());
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        public IActionResult GetAllServices()
        {
            try
            {
                var services = _servicesAdapter.ConvertServiceToDto(_servicesService.GetServices());
                
                return Ok(services);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public IActionResult LoadSingleContent([FromBody] Guid contentId)
        {
            if (contentId == Guid.Empty)
                return BadRequest("content Id empty");
            var contentDto = _contentAdapter.ConvertContentToDto(_contentService.GetContentById(contentId));
            return Ok(data);
        }
    }
}
