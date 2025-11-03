using BloodBank.Application.Commands.DonnorCommands.CreateDonor;
using BloodBank.Application.Commands.DonnorCommands.UpdateDonor;
using BloodBank.Application.Models;
using BloodBank.Application.Validators;
using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace BloodBank.Application
{
    public static class ApplicationModule
    {
        public static IServiceCollection AddApplicationModule(this IServiceCollection services)
        {
            services
                .AddValidation()
                .AddHandlers();

            return services;
        }

        private static IServiceCollection AddHandlers(this IServiceCollection services)
        {
            services
                .AddMediatR(config => config.RegisterServicesFromAssemblyContaining<CreateDonorCommand>());
            services
                .AddTransient<IPipelineBehavior<CreateDonorCommand, ResultViewModel<int>>, ValidateCreateDonorCommand>()
                .AddTransient<IPipelineBehavior<UpdateDonorCommand, ResultViewModel>, ValidateUpdateDonorCommand>();
            return services;
        }

        private static IServiceCollection AddValidation(this IServiceCollection services)
        {
            services
                .AddFluentValidationAutoValidation()
                .AddValidatorsFromAssemblyContaining<CreateDonorValidator>();

            return services;
        }
    }
}
