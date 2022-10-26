using UDRF.Dto.ServiceDto;
using UDRF.Models;

namespace UDRF.Adapters.ServicesAdapter
{
    public interface IServicesAdapter
    {
        IEnumerable<ServiceDto> ConvertServiceToDto(IEnumerable<ContentServices> services);
    }
}
