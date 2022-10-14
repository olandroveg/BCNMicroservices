using System;
using UDRF.Data;
using UDRF.Dto.FilterDto;
using UDRF.Models;

namespace UDRF.Services.LocationService
{
    public class LocationService : ILocationService
    {
        private readonly ApplicationDbContext _context;
        public LocationService(ApplicationDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Place> GetLocations(BaseFilter filter)
        {
            //get all location and applying paging
            var location = _context.Place.AsEnumerable().Skip(filter.Page * filter.PageSize).Take(filter.PageSize);
            return location;

        }
        public IEnumerable<Place> GetAllLocations()
        {
            return _context.Place.AsEnumerable();
        }
        public async Task<Guid> AddOrUpdate(Place location)
        {
            if (string.IsNullOrEmpty(location.Location) || string.IsNullOrEmpty(location.State) || string.IsNullOrEmpty(location.Country))
                throw new ArgumentNullException("fields cannot be null");
            if (location.Id == Guid.Empty)
                await _context.Place.AddAsync(location);
            else
                _context.Place.Update(location);
            await _context.SaveChangesAsync();
            return location.Id;
        }
        public async Task<int> Delete(Guid id)
        {
            if (id == Guid.Empty)
                return 0;
            var found = await _context.Place.FindAsync(id);
            if (found == null)
                throw new ArgumentNullException("location not found to delete");
            _context.Place.Remove(found);
            await _context.SaveChangesAsync();
            return 1;
        }
        public Place GetLocation(Guid? Id)
        {
            return _context.Place.Find(Id);
        }
        public async Task DeleteRange(IEnumerable<Guid> ids)
        {
            if (ids != null && ids.Any())
            {
                //var founds = _context.Place.AsEnumerable().TakeWhile(x => ids.Contains(x.Id));
                //if (founds.Any())
                //{
                //    _context.Place.RemoveRange(founds);

                //}

                foreach (var item in ids)
                {
                    var found = _context.Place.Find(item);
                    _context.Place.Remove(found);
                }
                await _context.SaveChangesAsync();

            }
        }
    }
}

