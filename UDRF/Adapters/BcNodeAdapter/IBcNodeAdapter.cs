using UDRF.Dto.BcNodeDto;
using UDRF.Models;

namespace UDRF.Adapters.BcNodeAdapter
{
    public interface IBcNodeAdapter
    {
        public IEnumerable<BcNodeDto> ConvertBcNodesToDTOs(IEnumerable<BcNode> bcNodes);
        public BcNode ConvertDtoToBcNode(BcNodeDto bcNodeDto);
        public BcNodeDto ConvertBcNodeToDTO(BcNode bcnode);
    }
}
