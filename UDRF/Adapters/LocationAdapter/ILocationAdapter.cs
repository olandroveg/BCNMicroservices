using UDRF.Dto.LocationDto;
using UDRF.Dto.NRFDto;
using UDRF.Models;

namespace UDRF.Adapters.LocationAdapter
{
    public interface ILocationAdapter
    {
        public IEnumerable<LocationDto> ConvertLocationsToDTOs(IEnumerable<Place> locations);
        public Place ConvertDtoToLocation(LocationDto locationDto);
        public LocationDto ConvertLocationToDTO(Place location);
        public IEnumerable<LocationListDto> ConvertListDto(IEnumerable<Place> places);
        public IncomeLocationDto ConvertToIncomeLocationDto(Place location);
    }
}
