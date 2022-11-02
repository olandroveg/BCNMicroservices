using UDRF.Models;

namespace UDRF.Services.TokenService
{
    public interface ITokenRequestService
    {
        Task<TokenApi> RequestToken(string username, string password);
        Task<string> ManageToken(string username, string password);
    }
}
