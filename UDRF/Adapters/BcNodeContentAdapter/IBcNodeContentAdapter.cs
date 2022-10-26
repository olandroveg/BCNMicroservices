using UDRF.Dto.BcNodeContentDto;
using UDRF.Models;

namespace UDRF.Adapters.BcNodeContentAdapter
{
    public interface IBcNodeContentAdapter
    {
        IEnumerable<BcNodeContentDto> ConvertBcNodesContentToDTOs(IEnumerable<BcNodeContent> bcNodeContents);
        BcNodeContent ConvertDtoToBcNodeContent(BcNodeContentDto bcNodeContentDto);
        BcNodeContentDto ConvertBcNodeContentToDto(Models.BcNodeContent bcNodeContent);
    }
}
