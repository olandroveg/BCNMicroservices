using System;
using Newtonsoft.Json;
using System.Text;
using OF.Utility;
using OF.Dto.NRFDto;
using OF.Services.IdNRFService;

namespace OF.Services.NRFService
{
    public class NRFService : INRFService
    {
        private readonly string _nrfAddress;
        private readonly string _register;
        
        private readonly IIdNRFService _idNRFService;

        public NRFService( IIdNRFService idNRFService)
        {

            _nrfAddress = StaticConfigurationManager.AppSetting["ApiAddress:NRF_Address"];
            _register = StaticConfigurationManager.AppSetting["ApiAddress:NRF_registerNF"];
            
            _idNRFService = idNRFService;
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
        public IncomeNFDto ConformNFDto()
        {
            var nfId = _idNRFService.GetNF_IDinNRF().Id;
            var nfName = StaticConfigurationManager.AppSetting["PublicNRF:Name"];
            var nfVersion = StaticConfigurationManager.AppSetting["PublicNRF:Version"];
            var nfBusyIndex = StaticConfigurationManager.AppSetting["PublicNRF:BusyIndex"];
            var nfState = StaticConfigurationManager.AppSetting["PublicNRF:state"];
            var nfSuscriptionApi = StaticConfigurationManager.AppSetting["PublicNRF:SuscriptionApi"];
            var numberOfApi = StaticConfigurationManager.AppSetting["PublicNRF:NumberOfApis"];
            var nfLocationName = StaticConfigurationManager.AppSetting["PublicNRF:NFLocation:Name"];
            var nfLatitude = StaticConfigurationManager.AppSetting["PublicNRF:NFLocation:Latitude"];
            var nfLongitude = StaticConfigurationManager.AppSetting["PublicNRF:NFLocation:Longitude"];

            var location = new IncomeLocationDto
            {
                Name = nfLocationName,
                Latitude = double.Parse(nfLatitude),
                Longitude = double.Parse(nfLongitude)
            };
            var services = new List<IncomeServiceDto>();
            for (int i = 1; i < (int.Parse(numberOfApi) + 1); i++)
            {
                services.Add(new IncomeServiceDto
                {
                    Name = StaticConfigurationManager.AppSetting["PublicNRF:API_" + i.ToString() + ":Name"],
                    Description = StaticConfigurationManager.AppSetting["PublicNRF:API_" + i.ToString() + ":Descrip"],
                    ServiceAPI = StaticConfigurationManager.AppSetting["PublicNRF:API_" + i.ToString() + ":Address"],
                    NfBaseAddress = StaticConfigurationManager.AppSetting["PublicNRF:NFbaseAddress"]
                });
            }
            return new IncomeNFDto
            {
                Id = nfId.ToString(),
                Name = nfName,
                Version = nfVersion,
                Location = location,
                Services = services,
                BusyIndex = float.Parse(nfBusyIndex),
                state = nfState,
                SuscriptionApi = nfSuscriptionApi
            };

        }



    }
}

