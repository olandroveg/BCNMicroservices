using System;
using UDRF.Services.BcNodeContentService;
using UDRF.Services.BcNodeService;
using UDRF.Services.ContentService;

namespace UDRF.Utility
{
    public static class ServiceCollectionExtension
    {
        public static void UseInjection(this IServiceCollection services)
        {
            services.AddTransient<IContentService, ContentService>();
            services.AddTransient<IBcNodeContentService, BcNodeContentService>();
            services.AddTransient<IBcNodeService, BcNodeService>();

        }
    }
}

