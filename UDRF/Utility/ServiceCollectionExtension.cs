using System;
using UDRF.Services.BcNodeService;

namespace UDRF.Utility
{
    public static class ServiceCollectionExtension
    {
        public static void UseInjection(this IServiceCollection services)
        {
            //services.AddTransient<ITokenRequestService, TokenRequestService>();
            //services.AddTransient<ITokenEntityService, TokenEntityService>();
            services.AddTransient<IBcNodeService, BcNodeService>();

        }
    }
}

