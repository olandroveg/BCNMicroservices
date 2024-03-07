using System;
using OF.Services.IdNRFService;
using OF.Services.NRFService;
using OF.Services.TokenService;

namespace OF.Utility
{
	public static class ServiceCollectionExtension
	{
		public static void UseInjection(this IServiceCollection services)
        {
            services.AddTransient<ITokenEntityService, TokenEntityService>();
            services.AddTransient<ITokenRequestService, TokenRequestService>();
            services.AddTransient<INRFService, NRFService>();
            services.AddTransient<IIdNRFService, IdNRFService>();
        }
	}
}

