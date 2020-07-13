using System;
using Microsoft.Extensions.DependencyInjection;
using Refit;

namespace APIServices
{
    public static class Registrantions
    {
        /// <summary>
        /// Adds the API services.
        /// </summary>
        /// <param name="services">The services.</param>
        /// <param name="config">The configuration.</param>
        /// <returns>return service dependices for request resouce</returns>
        public static IServiceCollection AddApiServices(this IServiceCollection services, ClientConfig config)
        {
            services.AddRefitClient<IApiClientResources>()
                .ConfigureHttpClient(c => c.BaseAddress = new Uri(config.BaseUrl));
            return services;
        }
    }
}
