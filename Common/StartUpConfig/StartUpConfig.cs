using Data.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Common.StartUpConfiguration
{
    public class StartUpConfig
    {
        public static IServiceCollection SetDependencyInjection(IServiceCollection services, IConfiguration configuration)
        {
            // Configure common repositories
            ConfigureRepositories(services);

            // Configure common services
            ConfigureServices(services, configuration);

            return services;
        }

        private static void ConfigureServices(IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.AddDbContext<BillingDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("MyDbConnection")));


        }

        private static void ConfigureRepositories(IServiceCollection serviceCollection)
        {
        }
    }
}
