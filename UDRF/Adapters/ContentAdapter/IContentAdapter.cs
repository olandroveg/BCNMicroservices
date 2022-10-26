using UDRF.Dto.ContentDto;
using UDRF.Dto.ServiceDto;
using UDRF.Models;

namespace UDRF.Adapters.ContentAdapter
{
    public interface IContentAdapter
    {
        IEnumerable<ServiceDto> ConvertContentToServiceDto(IEnumerable<Content> contents);
        Content ConvertDtoToContent(ContentDto contentDto);
        IEnumerable<ContentDto> ConvertContentsToDtos(IEnumerable<Content> contents);
        ContentDto ConvertContentToDto(Content content);
        //CreateEditContentViewModel ConvertDtoToViewModel(ContentDto contentDto);
        IEnumerable<ContentTableDto> ConvertContentsToTableDtos(IEnumerable<Content> contents);
    }
}
