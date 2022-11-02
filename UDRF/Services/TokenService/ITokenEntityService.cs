using UDRF.Models;

namespace UDRF.Services.TokenService
{
    public interface ITokenEntityService
    {
        Task<Models.Token> AddOrUpdate(Models.Token token);
        void Delete(Models.Token token);
        bool TokenAvailability();
        Token GetToken();
    }
}
