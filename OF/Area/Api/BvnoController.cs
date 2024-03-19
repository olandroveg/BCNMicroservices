using System;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OF.Dto.Bvno;

namespace OF.Area.Api
{
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]

    public class BvnoController : Controller
    {
		public BvnoController()
		{
		}
        [HttpPost]
        public IActionResult RequestIgestion([FromBody] BvnoDto bvnoDto)
        {
            try
            {
                if (bvnoDto == null)
                    throw new ArgumentNullException(nameof(bvnoDto));
                return Ok(SimulateIngestionResponse());

            }
            catch  (Exception e)
            {
                return BadRequest();
            }
        }

        private IngestionRsponseDto SimulateIngestionResponse()
        {
            return new IngestionRsponseDto
            {
                isAccepted = true,
                ingestionMode = new IngestionMode
                {
                    isBestEfford = true,
                    isScheddule = false
                },
                ChannelList = new List<string> { "Channel1", "Channel3" },
                isAudiovisual = true,
                Resolution = "640x480"

            };
        }
    }
}

