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

            return builder.Services;
        }


    }
}
