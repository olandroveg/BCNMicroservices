using UDRF.Services.TokenService;
using UDRF.Utility;

namespace UDRF.Services.NRFService
{
    public class NRFService : INRFService
    {
        private readonly string _aafAddress;
        private readonly string _register;
        private readonly ITokenRequestService _tokenRequestService;

        public NRFService(ITokenRequestService tokenRequestService)
        {
            _tokenRequestService = tokenRequestService;
            _aafAddress = StaticConfigurationManager.AppSetting["ApiAddress:AAF_Address"];
            _register = StaticConfigurationManager.AppSetting["ApiAddress:AAF_getToken"];
        }
    }
    
}
