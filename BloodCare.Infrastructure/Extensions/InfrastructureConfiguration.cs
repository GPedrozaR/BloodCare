using BloodCare.Domain.Entities;
using BloodCare.Domain.Interfaces;
using BloodCare.Domain.Repositories;
using BloodCare.Infrastructure.Mappers;
using BloodCare.Infrastructure.MongoDbEntities.Entities;
using BloodCare.Infrastructure.Persistence;
using BloodCare.Infrastructure.Persistence.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace BloodCare.Infrastructure.Extensions
{
    public static class InfrastructureConfiguration
    {
        public static IServiceCollection ConfigureInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.ConfigureDatabase(configuration);
            services.ConfigureDependecyInjection();

            return services;
        }

        private static IServiceCollection ConfigureDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<MongoConfig>(options =>
            {
                options.ConnectionString = configuration.GetSection("MongoDB:ConnectionString").Value;
                options.DataBase = configuration.GetSection("MongoDB:DataBase").Value;
            });

            services.AddSingleton<IMongoClient>(sp =>
            {
                var settings = sp.GetRequiredService<IOptions<MongoConfig>>().Value;
                return new MongoClient(settings.ConnectionString);
            });

            services.AddSingleton(sp =>
            {
                var settings = sp.GetRequiredService<IOptions<MongoConfig>>().Value;
                var client = sp.GetRequiredService<IMongoClient>();
                return client.GetDatabase(settings.DataBase);
            });

            return services;
        }


        private static IServiceCollection ConfigureDependecyInjection(this IServiceCollection services)
        {
            services.AddScoped<IDonorRepository, DonorRepository>();
            services.AddScoped<IDonationRepository, DonationRepository>();
            services.AddScoped<IBloodStockRepository, BloodStockRepository>();
            
            services.AddSingleton<IMapper<Donor, DonorMongoDb>, DonorMapper>();
            services.AddSingleton<IMapper<Donation, DonationMongoDb>, DonationMapper>();
            services.AddSingleton<IMapper<BloodStock, BloodStockMongoDb>, BloodStockMapper>();

            return services;
        }
    }
}
