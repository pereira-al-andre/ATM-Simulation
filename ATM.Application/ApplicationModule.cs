using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace ATM.Application
{
    public static class ApplicationModule
    {
        public static readonly Assembly Assembly = typeof(ApplicationModule).Assembly;
        public static IServiceCollection ApplicationDependencyInjection(this IServiceCollection services)
        {
            services.AddMediatR(cf => cf.RegisterServicesFromAssembly(typeof(ApplicationModule).Assembly));

            return services;
        }
    }
}
