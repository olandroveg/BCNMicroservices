using System;
using Microsoft.AspNetCore.Mvc;
using OF.RequestApi;

namespace OF.Area.Api
{
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    public class NwdafController: Controller
    {
		public NwdafController()
		{
		}
        [HttpPost]
        public async Task<IActionResult> VideoCateg([FromBody] string input)
        {
            if (!string.IsNullOrEmpty(input))
            {
                await SendCategoryByAPI(input);
                return Ok("Success");
            }
            
            return BadRequest();
        }
        public async Task<string> SendCategoryByAPI(string category)
        {
            var configRequest = await new SendCategory().SendConfig(category);
            return configRequest;
        }
    }
}

