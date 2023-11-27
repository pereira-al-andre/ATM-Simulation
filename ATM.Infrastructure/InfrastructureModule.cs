using ATM.Domain.Repositories;
using ATM.Infrastructure.Repositories;
using ATM.Infrastructure.Repositories.Common;
using Microsoft.Extensions.DependencyInjection;

namespace ATM.Infrastructure
{
    public static class InfrastructureModule
    {
        public static IServiceCollection InfrastructureDependencyInjection(this IServiceCollection services)
        {
            services.AddScoped(typeof(Repository<>), typeof(Repository<>));
            services.AddScoped<IMachineRepository, MachineRepository>();
            services.AddScoped<IBanknoteRepository, BanknoteRepository>();
            return services;
        }
    }
}
