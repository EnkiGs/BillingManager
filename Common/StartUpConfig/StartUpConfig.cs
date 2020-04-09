using Data.DataAccess;
using Data.DataAccess.Repositories;
using DataAccessInterfaces.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Professional.Business.Services;
using Professional.BusinessInterfaces.Services.Interfaces;
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

            serviceCollection.AddScoped<IBillService, BillService>();
            serviceCollection.AddScoped<IEstimateService, EstimateService>();
            serviceCollection.AddScoped<IClientService, ClientService>();
        }

        private static void ConfigureRepositories(IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IBillRepository, BillRepository>();
            serviceCollection.AddScoped<IClientRepository, ClientRepository>();
            serviceCollection.AddScoped<IEstimateRepository, EstimateRepository>();
        }
    }
}
