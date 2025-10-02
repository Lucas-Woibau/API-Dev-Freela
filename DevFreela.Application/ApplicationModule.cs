using DevFreela.Application.Services;
using Microsoft.Extensions.DependencyInjection;
using MediatR;
using Microsoft.EntityFrameworkCore;
using DevFreela.Application.Commands.InsertProject;

namespace DevFreela.Application
{
    public static class ApplicationModule
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services
                .AddServices()
                .AddHandlers();

            return services;
        }

        private static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IProjectService, ProjectService>();

            return services;
        }

        private static IServiceCollection AddHandlers(this IServiceCollection services)
        {
            services
                .AddMediatR(config => config.RegisterServicesFromAssemblyContaining<InsertProjectCommand>());

            return services;
        }
    }
}
