using UDRF.Models;

namespace UDRF.Services.ServicesService
{
    public interface IServicesService
    {
        IEnumerable<ContentServices> GetServices();
    }
}
