using System;
using UDRF.Dto.FilterDto;
using UDRF.Models;

namespace UDRF.Services.LocationService
{
    public interface ILocationService
    {
        public IEnumerable<Place> GetLocations(BaseFilter filter);
        public Task<Guid> AddOrUpdate(Place location);
        public Place GetLocation(Guid? Id);
        public Task DeleteRange(IEnumerable<Guid> ids);
        public IEnumerable<Place> GetAllLocations();

    }
}

