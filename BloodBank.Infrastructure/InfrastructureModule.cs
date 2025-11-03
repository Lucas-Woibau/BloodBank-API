using BloodBank.Domain.Repositories;
using BloodBank.Infrastructure.Persistence;
using BloodBank.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BloodBank.Infrastructure
{
    public static class InfrastructureModule
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,
            IConfiguration configuration)
        {
            services
                .AddRepositories()
                .AddData(configuration);

            return services;
        }

        public static IServiceCollection AddData(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("BloodBankCs");

            services.AddDbContext<BloodBankDbContext>(options =>
                options.UseSqlServer(connectionString));

            return services;
        }

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IDonorRepository, DonorRepository>();
            services.AddScoped<IDonationRepository, DonationRepository>();
            services.AddScoped<IBloodStockRepository, BloodStockRepository>();

            return services;
        }
    }
}
