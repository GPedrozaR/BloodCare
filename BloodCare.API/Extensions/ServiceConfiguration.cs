﻿using Microsoft.OpenApi.Models;

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
                s.SwaggerDoc("v2", new OpenApiInfo
                {
                    Title = "BloodCare.API",
                    Version = "v2",
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

    }
}
