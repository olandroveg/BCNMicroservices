using UDRF.Dto.BcNodeContentDto;
using UDRF.Models;
using UDRF.Services.BcNodeContentService;

namespace UDRF.Adapters.BcNodeContentAdapter
{
    public class BcNodeContentAdapter : IBcNodeContentAdapter
    {
        private readonly IBcNodeContentService _bcNodeContentService;
        public BcNodeContentAdapter(IBcNodeContentService bcNodeContentService)
        {
            _bcNodeContentService = bcNodeContentService;
        }
        public IEnumerable<BcNodeContentDto> ConvertBcNodesContentToDTOs(IEnumerable<BcNodeContent> bcNodeContents)
        {
            return bcNodeContents.Select(x => new BcNodeContentDto
            {
                Id = x.Id,
                BcNodeId = x.BcNodeId,
                ContentId = x.ContentId,
                Service = x.Content != null ? x.Content.Services.Name : null,
                SourceLocation = x.Content != null ? x.Content.SourceLocation : null,
                Bitrate = x.Bitrate,
                Size = x.Size
            });

        }
        public BcNodeContent ConvertDtoToBcNodeContent(BcNodeContentDto bcNodeContentDto)
        {
            return new Models.BcNodeContent
            {
                Id = bcNodeContentDto.Id,
                BcNodeId = bcNodeContentDto.BcNodeId,
                ContentId = bcNodeContentDto.ContentId,
                Bitrate = bcNodeContentDto.Bitrate,
                Size = bcNodeContentDto.Size

            };
        }
        public BcNodeContentDto ConvertBcNodeContentToDto(Models.BcNodeContent bcNodeContent)
        {
            return new BcNodeContentDto
            {
                Id = bcNodeContent.Id,
                BcNodeId = bcNodeContent.BcNodeId,
                ContentId = bcNodeContent.ContentId,
                ServiceId = bcNodeContent.Content.ServicesId,
                Service = bcNodeContent.Content.Services.Name,
                Bitrate = bcNodeContent.Bitrate,
                Size = bcNodeContent.Size,
                SourceLocation = bcNodeContent.Content.SourceLocation,
                Name = bcNodeContent.Content.Name
            };
        }
    }
}
