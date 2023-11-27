using Microsoft.Extensions.DependencyInjection;

namespace ATM.Domain
{
    public static class DomainModule
    {
        public static IServiceCollection DomainDependencyInjection(this IServiceCollection services)
        {
            return services;
        }
    }
}
