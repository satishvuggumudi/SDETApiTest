using SolidToken.SpecFlow.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using APIServices;

namespace SDETApiTest
{
    public static class Startup
    {
        /// <summary>
        /// Creates the service collection.
        /// </summary>
        /// <returns>Collection of service dependices</returns>
        [ScenarioDependencies]
        public static IServiceCollection CreateServiceCollection()
        {
            var configurationBuilder = new ConfigurationBuilder().AddJsonFile("appSettings.json");
            
            var config = configurationBuilder.Build();

            var services = new ServiceCollection();

            var clientConfig = new ClientConfig();
            config.Bind("api", clientConfig);
            services.AddApiServices(clientConfig);

            return services;
        }

    }
}
