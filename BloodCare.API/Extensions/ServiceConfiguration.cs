using BloodCare.Application.Commands.Donors.CreateDonor;
using BloodCare.Domain.Entities;
using BloodCare.Domain.Interfaces;
using BloodCare.Domain.Repositories;
using BloodCare.Infrastructure.Mappers;
using BloodCare.Infrastructure.MongoDbEntities.Entities;
using BloodCare.Infrastructure.Persistence;
using BloodCare.Infrastructure.Persistence.Repositories;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using MongoDB.Driver;

namespace BloodCare.API.Extensions
{
    public static class ServiceConfiguration
    {
        public static WebApplicationBuilder ConfigureServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddControllers();

            builder.Services.AddEndpointsApiExplorer();

            builder.Services.AddSwaggerGen(s =>
            {
                s.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "BloodCare.API",
                    Version = "v1",
                    Contact = new OpenApiContact
                    {
                        Name = "Gabriel Pedroza",
                        Email = "gpedrozarodrigues@gmail.com",
                        Url = new Uri("https://github.com/GPedrozaR")
                    }
                });
            });

            return builder;
        }

        public static IServiceCollection ConfigureDataBase(this WebApplicationBuilder builder)
        {
            var section = builder.Configuration.GetSection("MongoDB");
            builder
                .Services
                .Configure<MongoConfig>(section);

            builder.Services.AddSingleton<IMongoClient, MongoClient>(sp =>
            {
                var settings = sp.GetRequiredService<IOptions<MongoConfig>>().Value;
                return new MongoClient(settings.ConnectionString);
            });

            builder.Services.AddSingleton(sp =>
            {
                var settings = sp.GetRequiredService<IOptions<MongoConfig>>().Value;
                var client = sp.GetRequiredService<IMongoClient>();
                return client.GetDatabase(settings.DataBase);
            });

            return builder.Services;
        }

        public static IServiceCollection ConfigureDependecyInjection(this WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<IDonorRepository, DonorRepository>();
            builder.Services.AddScoped<IDonationRepository, DonationRepository>();
            builder.Services.AddScoped<IBloodStockRepository, BloodStockRepository>();

            builder.Services.AddMediatR(op => op.RegisterServicesFromAssemblyContaining(typeof(CreateDonorCommand)));

            builder.Services.AddSingleton<IMapper<Donor, DonorMongoDb>, DonorMapper>();
            builder.Services.AddSingleton<IMapper<Donation, DonationMongoDb>, DonationMapper>();
            builder.Services.AddSingleton<IMapper<BloodStock, BloodStockMongoDb>, BloodStockMapper>();

            return builder.Services;
        }
    }
}
