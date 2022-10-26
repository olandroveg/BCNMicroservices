using UDRF.Models;

namespace UDRF.Services.ServicesService
{
    public interface IServicesService
    {
        IEnumerable<ContentServices> GetServices();
        Task<Guid> AddOrUpdate(ContentServices service)
    }
}
