using DevFreela.Application.Commands.ProjectCommands.InsertProject;
using DevFreela.Application.Commands.UserCommands.InsertUser;
using DevFreela.Application.Models;
using DevFreela.Application.Services;
using DevFreela.Application.Validators;
using FluentValidation;
using FluentValidation.AspNetCore;
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
                .AddHandlers()
                .AddValidation();

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

        private static IServiceCollection AddValidation(this IServiceCollection services)
        {
            services
                .AddFluentValidationAutoValidation()
                .AddValidatorsFromAssemblyContaining<InsertUserValidator>();

            return services;
        }
    }
}


