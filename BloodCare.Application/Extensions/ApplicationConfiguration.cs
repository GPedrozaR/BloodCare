using BloodCare.Application.Commands.Donors.CreateDonor;
using Microsoft.Extensions.DependencyInjection;

namespace BloodCare.Application.Extensions
{
    public static class ApplicationConfiguration
    {
        public static IServiceCollection ConfigureApplication(this IServiceCollection services)
        {
            services.AddMediatR(op => op.RegisterServicesFromAssemblyContaining(typeof(CreateDonorCommand)));
            return services;
        }
    }
}
