using System;
using UDRF.Adapters.BcNodeAdapter;
using UDRF.Adapters.BcNodeContentAdapter;
using UDRF.Adapters.ContentAdapter;
using UDRF.Adapters.LocationAdapter;
using UDRF.Adapters.ServicesAdapter;
using UDRF.Services.BcNodeContentService;
using UDRF.Services.BcNodeService;
using UDRF.Services.ContentService;
using UDRF.Services.LocationService;
using UDRF.Services.ServicesService;

namespace UDRF.Utility
{
    public static class ServiceCollectionExtension
    {
        public static void UseInjection(this IServiceCollection services)
        {
            services.AddTransient<IServicesService, ServicesService>();
            services.AddTransient<IContentService, ContentService>();
            services.AddTransient<ILocationService, LocationService>();
            services.AddTransient<IBcNodeService, BcNodeService>();
            services.AddTransient<IBcNodeContentService, BcNodeContentService>();
            services.AddTransient<ILocationAdapter, LocationAdapter>();
            services.AddTransient<IBcNodeAdapter, BcNodeAdapter>();
            services.AddTransient<IBcNodeContentAdapter, BcNodeContentAdapter>();
            services.AddTransient<IContentAdapter, ContentAdapter>();
            services.AddTransient<IServicesAdapter, ServicesAdapter>();


        }
    }
}

