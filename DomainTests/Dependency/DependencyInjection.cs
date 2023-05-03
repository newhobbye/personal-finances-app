using core_application.Models.Environment;
using core_application.Shared;
using DomainTests.Constants;
using Microsoft.Extensions.DependencyInjection;

namespace DomainTests.Dependency
{
    public static class DependencyInjection
    {
        public static T GetService<T>()
        {
            var serviceCollection = new ServiceCollection();

            serviceCollection.AddDependencies();

            var serviceProvider = serviceCollection.BuildServiceProvider();

            T? getService = serviceProvider.GetService<T>();

            return getService;
        }
    }
}
