using System;
using UDRF.Dto.FilterDto;
using UDRF.Models;

namespace UDRF.Services.BcNodeService
{
    public interface IBcNodeService
    {
        public IEnumerable<BcNode> GetBcNodes(BaseFilter filter);
        public Task<Guid> AddOrUpdate(BcNode bcNode);
        public BcNode GeBcNode(Guid? Id);
        public Task DeleteRange(IEnumerable<Guid> ids);
        IEnumerable<BcNode> GetAllBcNodes();

    }
}

