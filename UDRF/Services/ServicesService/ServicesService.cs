using UDRF.Data;
using UDRF.Models;

namespace UDRF.Services.ServicesService
{
    public class ServicesService : IServicesService
    {
        private readonly ApplicationDbContext _context;
        public ServicesService(ApplicationDbContext context)
        {
            _context = context;
        }
        public IEnumerable<ContentServices> GetServices()
        {
            //get all services
            return _context.ContentServices;
        }

    }
}
