using System;
using Microsoft.EntityFrameworkCore;
using UDRF.Data;
using UDRF.Models;

namespace UDRF.Services.ContentService
{
    public class ContentService : IContentService
    {
        private readonly ApplicationDbContext _context;
        public ContentService(ApplicationDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Content> GetAllContents()
        {
            return _context.Content.Include(x => x.Services);
        }
        public async Task<Guid> AddOrUpdate(Content content)
        {
            if (content.ServicesId == Guid.Empty)
                throw new ArgumentNullException("fields cannot be null");
            if (content.Id == Guid.Empty)
                await _context.Content.AddAsync(content);
            else
                _context.Content.Update(content);
            await _context.SaveChangesAsync();
            return content.Id;
        }
        public Content GetContentById(Guid? Id)
        {
            return _context.Content.Find(Id);
        }
        public async Task DeleteRange(IEnumerable<Guid> ids)
        {
            if (ids != null && ids.Any())
            {
                foreach (var item in ids)
                {
                    var found = _context.Content.Find(item);
                    _context.Content.Remove(found);
                }
                await _context.SaveChangesAsync();

            }
        }
        public async Task<int> Delete(Guid id)
        {
            if (id == Guid.Empty)
                return 0;
            var found = await _context.Content.FindAsync(id);
            if (found == null)
                throw new ArgumentNullException("content not found to delete");
            _context.Content.Remove(found);
            await _context.SaveChangesAsync();
            return 1;
        }
    }
}

