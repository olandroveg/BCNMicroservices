﻿using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using UDRF.Adapters.LocationAdapter;
using UDRF.Dto.FilterDto;
using UDRF.Services.LocationService;

namespace UDRF.Area.Api
{
    [Area("Admin")] 
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
                var data = _locationAdapter.ConvertLocationsToDTOs(_locationService.GetAllLocations());
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
            
        }
    }
}
