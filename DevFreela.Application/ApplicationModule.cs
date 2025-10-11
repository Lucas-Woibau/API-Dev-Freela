using DevFreela.Application.Commands.ProjectCommands.InsertProject;
using DevFreela.Application.Commands.UserCommands.InsertUser;
using DevFreela.Application.Models;
using DevFreela.Application.Services;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

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
            services.AddScoped<IUserSkillService, UserSkillService>();

            return services;
        }

        private static IServiceCollection AddHandlers(this IServiceCollection services)
        {
            services
                .AddMediatR(config => config.RegisterServicesFromAssemblyContaining<InsertProjectCommand>());
            services
                .AddTransient<IPipelineBehavior<InsertProjectCommand, ResultViewModel<int>>, ValidateInsertProjectCommandBehavior>();
            services
                .AddTransient<IPipelineBehavior<InsertUserCommand, ResultViewModel<int>>, ValidateInsertUserCommandBehavior>();

            return services;
        }
    }
}


