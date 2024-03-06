using System;
namespace OF.Services.TokenService
{
    public interface ITokenRequestService
    {

        public Task<string> ManageToken(string username, string password);
    }
}

