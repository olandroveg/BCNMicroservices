using UDRF.Dto.ServiceDto;
using UDRF.Models;

namespace UDRF.Adapters.ServicesAdapter
{
    public class ServicesAdapter : IServicesAdapter
    {
        //private readonly IServicesService _servicesService;
        //public ServicesAdapter (IServicesService servicesServices)
        //{
        //    _servicesService = servicesServices;
        //}
        public IEnumerable<ServiceDto> ConvertServiceToDto(IEnumerable<ContentServices> services)
        {
            return services.Select(x => new ServiceDto
            {
                Id = x.Id,
                Name = x.Name
            });
        }
    }
}
