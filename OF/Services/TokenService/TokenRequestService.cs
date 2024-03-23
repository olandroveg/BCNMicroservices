﻿using System;
using Newtonsoft.Json;
using System.Text;
using OF.Utility;
using OF.Models;

namespace OF.Services.TokenService
{
    public class TokenRequestService : ITokenRequestService
    {
        private string _aafAddress;
        private string _tokenApi;
        private readonly ITokenEntityService _tokenEntityService;
        public TokenRequestService(ITokenEntityService tokenEntityService)
        {
            _aafAddress = StaticConfigurationManager.AppSetting["ApiAddress:AAF_Address"];
            _tokenApi = StaticConfigurationManager.AppSetting["ApiAddress:AAF_getToken"];
            _tokenEntityService = tokenEntityService;
        }
        private async Task<TokenApi> RequestToken(string username, string password)
        {
            var tokenApi = new TokenApi();
            try
            {
                var dataObj = new TokenRqst(username, password);
                using (var httpClient = new HttpClient())
                {
                    StringContent content = new StringContent(JsonConvert.SerializeObject(dataObj), Encoding.UTF8, "application/json");
                    using (var response = await httpClient.PostAsync(_aafAddress + _tokenApi, content))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        if (response.StatusCode == System.Net.HttpStatusCode.OK)
                        {
                            tokenApi = JsonConvert.DeserializeObject<TokenApi>(apiResponse);
                            if (tokenApi.status == "Success")
                            {
                                var token = new Token
                                {
                                    Id = Guid.Empty,
                                    Value = tokenApi.token,
                                    DateTime = DateTime.Now
                                };
                                await _tokenEntityService.AddOrUpdate(token);
                                return tokenApi;
                            }

                        }
                        else if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                            tokenApi.status = "unauthorized";
                    }
                    return tokenApi;
                }
            }
            catch (Exception)
            {
                tokenApi.status = "exception";
                return tokenApi;
            }
        }
        public async Task<string> ManageToken(string username, string password)
        {

            var token = new Token();
            if (_tokenEntityService.TokenAvailability())
                token = _tokenEntityService.GetToken();
            else
            {
                var tokenApi = await RequestToken(username, password);
                if (tokenApi.status == "Success")
                {
                    token.Value = tokenApi.token;
                }

            }
            return token.Value;

        }
    }
}
