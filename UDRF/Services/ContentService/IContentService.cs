using System;
using UDRF.Models;

namespace UDRF.Services.ContentService
{
    public interface IContentService
    {
        IEnumerable<Content> GetAllContents();
        Task<Guid> AddOrUpdate(Content content);
        Content GetContentById(Guid? Id);
        Task DeleteRange(IEnumerable<Guid> ids);
        Task<int> Delete(Guid id);

    }
}

