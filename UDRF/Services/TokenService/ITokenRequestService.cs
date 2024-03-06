using UDRF.Models;

namespace UDRF.Services.TokenService
{
    public interface ITokenRequestService
    {
       
       public Task<string> ManageToken(string username, string password);
    }
}
