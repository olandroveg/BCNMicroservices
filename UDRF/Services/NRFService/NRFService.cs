using Newtonsoft.Json;
using System.Text;
using UDRF.Adapters.LocationAdapter;
using UDRF.Dto.NRFDto;
using UDRF.Services.TokenService;
using UDRF.Utility;

namespace UDRF.Services.NRFService
{
    public class NRFService : INRFService
    {
        private readonly string _nrfAddress;
        private readonly string _register;
        private readonly ILocationAdapter _locationAdapter;

        public NRFService(ILocationAdapter locationAdapter)
        {
            
            _nrfAddress = StaticConfigurationManager.AppSetting["ApiAddress:NRF_Address"];
            _register = StaticConfigurationManager.AppSetting["ApiAddress:NRF_registerNF"];
            _locationAdapter = locationAdapter;
        }
        public async Task<Guid> RegisterNF(string token, IncomeNFDto incomeNFDto)
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    StringContent content = new StringContent(JsonConvert.SerializeObject(incomeNFDto), Encoding.UTF8, "application/json");
                    httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                    using (var response = await httpClient.PostAsync(_nrfAddress + _register, content))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        if (response.StatusCode == System.Net.HttpStatusCode.OK)
                        {
                            var Id = JsonConvert.DeserializeObject<Guid>(apiResponse);
                            return Id;
                        }
                        throw new Exception(HttpResponseCode.GetMessageFromStatus(response.StatusCode));
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        //public IncomeNFDto ConformNFDto()
        //{

        //}
    


    }
    
    
}
