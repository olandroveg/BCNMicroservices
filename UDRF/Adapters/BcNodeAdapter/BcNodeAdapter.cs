using UDRF.Dto.BcNodeDto;
using UDRF.Models;
using UDRF.Services.BcNodeService;

namespace UDRF.Adapters.BcNodeAdapter
{
    public class BcNodeAdapter : IBcNodeAdapter
    {
        private readonly IBcNodeService _bcNodeService;
        public BcNodeAdapter(IBcNodeService bcNodeService)
        {
            _bcNodeService = bcNodeService;
        }
        public IEnumerable<BcNodeDto> ConvertBcNodesToDTOs(IEnumerable<BcNode> bcNodes)
        {
            var tmp = bcNodes.Select(x => new BcNodeDto
            {
                Name = x.Name,
                Id = x.Id,
                Description = x.Description,
                PlaceId = x.PlaceId != null ? x.PlaceId : Guid.Empty,
                TopBcNode = x.TopBcNodeId != null ? (Guid)x.TopBcNodeId : Guid.Empty,
                Group = x.Group.ToString()

            });
            return tmp;

        }
        public BcNode ConvertDtoToBcNode(BcNodeDto bcNodeDto)
        {
            return new BcNode
            {
                Id = bcNodeDto.Id,
                Name = bcNodeDto.Name,
                Description = bcNodeDto.Description,
                PlaceId = bcNodeDto.PlaceId,
                UserId = bcNodeDto.UserId,
                TopBcNodeId = bcNodeDto.TopBcNode,
                Group = int.Parse(bcNodeDto.Group)
            };
        }
        public BcNodeDto ConvertBcNodeToDTO(BcNode bcnode)
        {
            return new BcNodeDto
            {
                Id = bcnode.Id,
                Description = bcnode.Description,
                Name = bcnode.Name,
                PlaceId = bcnode.PlaceId,
                UserId = bcnode.UserId,
                Latitude = bcnode.Place.Latitude,
                Longitude = bcnode.Place.Longitude,
                Group = bcnode.Group.ToString(),
                TopBcNode = bcnode.TopBcNodeId != Guid.Empty ? (Guid)bcnode.TopBcNodeId : Guid.Empty
            };
        }
    }
}
