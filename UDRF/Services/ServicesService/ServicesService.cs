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
        
        public async Task<Guid> AddOrUpdate(ContentServices service)
        {
            if (service == null || service.Name == String.Empty)
                throw new ArgumentNullException("fields cannot be null");
            if (service.Id == Guid.Empty )
                await _context.ContentServices.AddAsync(service);
            else
                _context.ContentServices.Update(service);
            await _context.SaveChangesAsync();
            return service.Id;
        }

    }
}
