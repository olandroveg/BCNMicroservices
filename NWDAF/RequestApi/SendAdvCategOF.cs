using System;
using Newtonsoft.Json;
using System.Text;
using NWDAF.Utility;
using System.Threading.Tasks;

namespace NWDAF.RequestApi
{
	public class SendAdvCategOF
	{
        private readonly string _OFBaseIP = StaticConfigurationManager.AppSetting["OF_IP"];
        private readonly string _videoCategApi = "/api/Nwdaf/VideoCateg";

        public async Task<string> SendConfig(string videoCateg)
        {
            var responseForm = "";
            try
            {
                using (var httpClient = new HttpClient())
                {
                    StringContent content = new StringContent(JsonConvert.SerializeObject(videoCateg), Encoding.UTF8, "application/json");
                    //no Bearer Header
                    using (var response = await httpClient.PostAsync(_OFBaseIP + _videoCategApi, content))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        if (response.StatusCode == System.Net.HttpStatusCode.OK)
                        {
                            //responseForm = JsonConvert.DeserializeObject<string>(apiResponse);
                            responseForm = apiResponse;
                            if (responseForm == "Success")
                            {
                                return responseForm;
                            }
                        }
                        else if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                            responseForm = "unauthorized";

                    }
                    return responseForm;
                }
            }
            catch (Exception e)
            {
                responseForm = "exception";
                return responseForm;
            }
        }
    }
}

