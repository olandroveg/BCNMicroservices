using System;
using Microsoft.EntityFrameworkCore;
using UDRF.Data;
using UDRF.Dto.FilterDto;
using UDRF.Models;

namespace UDRF.Services.BcNodeContentService
{
    public class BcNodeContentService : IBcNodeContentService
    {
        private readonly ApplicationDbContext _context;

        public BcNodeContentService(ApplicationDbContext context)
        {
            _context = context;
        }
        public IEnumerable<BcNodeContent> GetBcNodeContents(BaseFilter filter)
        {
            //get all BcNodeContent and applying paging

            return _context.BcNodeContents.Include(x => x.Content)
                     .ThenInclude(e => e.Services)
                     .Where(x => x.BcNodeId == filter.RefenceId).Skip(filter.Page * filter.PageSize).Take(filter.PageSize);

        }

        public BcNodeContent GetBcNodeContentById(Guid bcNodeContentId)
        {
            return _context.BcNodeContents.Include(x => x.Content).ThenInclude(e => e.Services)
                .Where(x => x.Id == bcNodeContentId).FirstOrDefault();
        }
        public async Task<Guid> AddOrUpdate(BcNodeContent bcNodeContent)
        {
            if (bcNodeContent.Id == Guid.Empty)
                await _context.BcNodeContents.AddAsync(bcNodeContent);

            else
            {
                _context.BcNodeContents.Update(bcNodeContent);
                //var bcNContent = _context.BcNodeContents.Find(bcNodeContent.Id);
                //if (bcNContent != null)
                //{
                //    _context.Entry(bcNContent).CurrentValues.SetValues(bcNodeContent);
                //}
            }

            await _context.SaveChangesAsync();


            return bcNodeContent.Id;

        }
        public BcNodeContent GetBcNodeContent(Guid Id)
        {
            return _context.BcNodeContents.Find(Id);
        }
        public async Task DeleteRange(IEnumerable<Guid> ids)
        {
            if (ids != null && ids.Any())
            {
                foreach (var item in ids)
                {
                    var found = _context.BcNodeContents.Find(item);
                    _context.BcNodeContents.Remove(found);
                }
                await _context.SaveChangesAsync();
            }
        }
    }
}

