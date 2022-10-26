using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using UDRF.Adapters.LocationAdapter;
using UDRF.Dto.FilterDto;
using UDRF.Dto.LocationDto;
using UDRF.Services.LocationService;

namespace UDRF.Area.Api
{
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class LocationController : Controller
    {
        private readonly ILocationService _locationService;
        private readonly ILocationAdapter _locationAdapter;
        private const string EditTitle = "Edit location";
        private const string NewTitle = "New location";

        public LocationController(ILocationAdapter locationAdapter, ILocationService locationService)
        {
            _locationAdapter = locationAdapter;
            _locationService = locationService;

        }
        [HttpPost]
        public IActionResult LoadLocation([FromBody] BaseFilter filters)
        {
            
            try
            {
                if (filters == null)
                    throw new ArgumentNullException(nameof(filters));
                var data = _locationAdapter.ConvertLocationsToDTOs(_locationService.GetLocations(filters));
                return Ok(data);
            }
            catch (Exception ex)
            {
               return BadRequest(ex.Message);
            }
            
        }
        [HttpGet]
        public IActionResult LoadAllLocations()
        {
            try
            {
                var data = _locationAdapter.ConvertListDto(_locationService.GetAllLocations());
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
            
        }
        [HttpPost]
        public IActionResult LoadSingleLocation ([FromBody] Guid locationId)
        {
            if (locationId == Guid.Empty)
                return BadRequest("location Id empty");
            var data = _locationAdapter.ConvertLocationToDTO(_locationService.GetLocation(locationId));
            return Ok(data);
        }
        [HttpPost]
        public async Task<IActionResult> ReceiveLocation([FromBody] LocationDto locationDto)
        {
            var locationId = await _locationService.AddOrUpdate(_locationAdapter.ConvertDtoToLocation(locationDto));
            return Ok(locationId);
        }
        [HttpPost]
        public async Task<IActionResult> DeleteRange([FromBody] IEnumerable<Guid> locations)
        {
            try
            {
                await _locationService.DeleteRange(locations);
                return Ok();
            }
            catch (ArgumentException)
            {
                return BadRequest();
            }
        }

    }
}
