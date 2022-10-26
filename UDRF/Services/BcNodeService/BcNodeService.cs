using System;
using Microsoft.EntityFrameworkCore;
using UDRF.Data;
using UDRF.Dto.FilterDto;
using UDRF.Models;

namespace UDRF.Services.BcNodeService
{
    public class BcNodeService : IBcNodeService
    {
        private readonly ApplicationDbContext _context;
        public BcNodeService(ApplicationDbContext context)
        {
            _context = context;
        }
        public IEnumerable<BcNode> GetBcNodes(BaseFilter filter)
        {
            //get all bcNode and applying paging
            //var bcNode = _context.BcNode.AsEnumerable().Skip(filter.Page * filter.PageSize).Take(filter.PageSize);
            return filter.IsAdmin ? _context.BcNode.AsEnumerable().Skip(filter.Page * filter.PageSize).Take(filter.PageSize)
                : _context.BcNode.AsEnumerable().Where(x => x.UserId == filter.Userid).Skip(filter.Page * filter.PageSize).Take(filter.PageSize);

        }
        public IEnumerable<BcNode> GetAllBcNodes()
        {
            return _context.BcNode.AsEnumerable();
        }
        public async Task<Guid> AddOrUpdate(BcNode bcNode)
        {
            if (string.IsNullOrEmpty(bcNode.Name) || string.IsNullOrEmpty(bcNode.Description) || Guid.Empty == bcNode.PlaceId)
                throw new ArgumentNullException("fields cannot be null");
            if (bcNode.Id == Guid.Empty)
                await _context.BcNode.AddAsync(bcNode);
            else
                _context.BcNode.Update(bcNode);
            await _context.SaveChangesAsync();
            return bcNode.Id;
        }
        public BcNode GeBcNode(Guid? Id)
        {
            return _context.BcNode.Include(x => x.Place).Where(x => x.Id == Id).FirstOrDefault();

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
                    var found = _context.BcNode.Find(item);
                    _context.BcNode.Remove(found);
                }
                await _context.SaveChangesAsync();

            }
        }

    }
}

