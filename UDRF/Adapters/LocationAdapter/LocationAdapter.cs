using UDRF.Dto.LocationDto;
using UDRF.Models;
using UDRF.Services.LocationService;

namespace UDRF.Adapters.LocationAdapter
{
    public class LocationAdapter : ILocationAdapter
    {
        private readonly ILocationService _locationService;
        public LocationAdapter(ILocationService locationService)
        {
            _locationService = locationService;
        }
        public IEnumerable<LocationDto> ConvertLocationsToDTOs(IEnumerable<Place> locations)
        {
            return locations.Select(x => new LocationDto
            {
                Name = x.Location,
                Id = x.Id,
                State = x.State,
                Country = x.Country
            });

        }
        public Place ConvertDtoToLocation(LocationDto locationDto)
        {
            return new Place
            {
                Id = locationDto.Id,
                Longitude = locationDto.Longitude,
                Latitude = locationDto.Latitude,
                Location = locationDto.Name,
                State = locationDto.State,
                Country = locationDto.Country
            };
        }
        public LocationDto ConvertLocationToDTO(Place location)
        {
            return new LocationDto
            {
                Id = location.Id,
                Latitude = location.Latitude,
                Longitude = location.Longitude,
                State = location.State,
                Name = location.Location,
                Country = location.Country
            };
        }
        public IEnumerable<LocationListDto> ConvertListDto(IEnumerable<Place> places)
        {
            return places.Select(x => new LocationListDto
            {
                Location = x.Location,
                Id = x.Id
            });
        }
    }
}
