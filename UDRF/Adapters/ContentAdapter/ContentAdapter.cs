using UDRF.Adapters.ServicesAdapter;
using UDRF.Dto.ContentDto;
using UDRF.Dto.ServiceDto;
using UDRF.Models;
using UDRF.Services.ContentService;
using UDRF.Services.ServicesService;

namespace UDRF.Adapters.ContentAdapter
{
    public class ContentAdapter : IContentAdapter
    {
        private readonly IContentService _contentService;
        private readonly IServicesService _servicesService;
        private readonly IServicesAdapter _servicesAdapter;

        public ContentAdapter(IContentService contentService, IServicesService servicesServices, IServicesAdapter servicesAdapter)
        {
            _contentService = contentService;
            _servicesService = servicesServices;
            _servicesAdapter = servicesAdapter;
        }
        public IEnumerable<ServiceDto> ConvertContentToServiceDto(IEnumerable<Content> contents)
        {
            return contents.Select(x => new ServiceDto
            {
                Id = x.ServicesId,
                Name = x.Services.Name
            });
        }
        public IEnumerable<ContentDto> ConvertContentsToDtos(IEnumerable<Content> contents)
        {
            return contents.Select(x => new ContentDto
            {
                Id = x.Id,
                SourceLocation = x.SourceLocation,
                ServicesId = x.ServicesId,
                services = _servicesAdapter.ConvertServiceToDto(_servicesService.GetServices()),
                ServiceName = x.Services.Name,
                Name = x.Name
            });

        }
        public IEnumerable<ContentTableDto> ConvertContentsToTableDtos(IEnumerable<Content> contents)
        {
            return contents.Select(x => new ContentTableDto
            {
                Id = x.Id,
                Name = x.Name,
                SourceLocation = x.SourceLocation,
                Service = x.Services.Name
            });
        }
        public Content ConvertDtoToContent(ContentDto contentDto)
        {
            return new Content
            {
                ServicesId = contentDto.ServicesId,
                Id = contentDto.Id,
                SourceLocation = contentDto.SourceLocation,
                Name = contentDto.Name
            };
        }
        public ContentDto ConvertContentToDto(Content content)
        {
            return new ContentDto
            {
                Id = content.Id,
                ServicesId = content.ServicesId,
                services = _servicesAdapter.ConvertServiceToDto(_servicesService.GetServices()),
                SourceLocation = content.SourceLocation,
                Name = content.Name
            };
        }
        //public CreateEditContentViewModel ConvertDtoToViewModel(ContentDto contentDto)
        //{
        //    return new CreateEditContentViewModel
        //    {
        //        Id = contentDto.Id.ToString(),
        //        SelectedServiceId = contentDto.ServicesId,
        //        Services = contentDto.services,
        //        SourceLocation = contentDto.SourceLocation,
        //        Name = contentDto.Name
        //    };
        //}

    }
}
