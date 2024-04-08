using System;
using Newtonsoft.Json;
using System.Text;
using OF.Utility;

namespace OF.RequestApi
{
	public class SendCategory
	{
        private readonly string _blackBerryBaseIP = StaticConfigurationManager.AppSetting["BlackBerryIP"];
        private readonly string _videoCategApi = "/api/bcNode/VideoCateg";
        private readonly string _nWDAF_IP = StaticConfigurationManager.AppSetting["NWDAF_IP"];
        private readonly string _reqstCategNWDAF = "/api/OFAdv/StartAdvertStats";


        public async Task<string> SendConfig(string videoCateg)
        {
            var responseForm = "";
            try
            {
                using (var httpClient = new HttpClient())
                {
                    StringContent content = new StringContent(JsonConvert.SerializeObject(videoCateg), Encoding.UTF8, "application/json");
                    //no Bearer Header
                    using (var response = await httpClient.PostAsync(_blackBerryBaseIP + _videoCategApi, content))
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


        public async Task<string> ReqstCategory()
        {
            var responseForm = "";
            try
            {
                using (var httpClient = new HttpClient())
                {
                    //StringContent content = new StringContent(JsonConvert.SerializeObject(videoCateg), Encoding.UTF8, "application/json");
                    //no Bearer Header
                    using (var response = await httpClient.GetAsync(_nWDAF_IP + _reqstCategNWDAF))
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

