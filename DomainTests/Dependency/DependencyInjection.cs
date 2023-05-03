using core_application.Shared;
using DomainTests.Constants;
using Microsoft.Extensions.DependencyInjection;

namespace DomainTests.Dependency
{
    public class DependencyInjection
    {
        public T GetService<T>()
        {
            var serviceCollection = new ServiceCollection();

            serviceCollection.AddDependencies(EnviromentConstant.DatabaseFilename, EnviromentConstant.DatabasePath);

            var serviceProvider = serviceCollection.BuildServiceProvider();

            T? getService = serviceProvider.GetService<T>();

            return getService;
        }
    }
}
