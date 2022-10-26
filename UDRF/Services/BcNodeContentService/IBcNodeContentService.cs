using System;
using UDRF.Dto.FilterDto;
using UDRF.Models;

namespace UDRF.Services.BcNodeContentService
{
    public interface IBcNodeContentService
    {
        IEnumerable<BcNodeContent> GetBcNodeContents(BaseFilter filter);
        Task<Guid> AddOrUpdate(BcNodeContent bcNodeContent);
        BcNodeContent GetBcNodeContent(Guid Id);
        Task DeleteRange(IEnumerable<Guid> ids);
        BcNodeContent GetBcNodeContentById(Guid bcNodeContentId);

    }
}

