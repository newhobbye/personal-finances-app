using core_application.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace core_application.Shared
{
    public static class ExternalDependency
    {
        public static IServiceCollection AddDependencies(this IServiceCollection services)
        {
            services.TryAdd(new ServiceDescriptor(
                typeof(ApplicationContext),
                serviceProvider => new ApplicationContext(), ServiceLifetime.Scoped));
            
            return services;
        }
    }
}
