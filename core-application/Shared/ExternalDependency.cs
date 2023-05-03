using core_application.Interfaces.Repository;
using core_application.Interfaces.Services;
using core_application.Models.Environment;
using core_application.Repositories;
using core_application.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace core_application.Shared
{
    public static class ExternalDependency
    {
        public static IServiceCollection AddDependencies(this IServiceCollection services,
            string databaseFilename, string databasePath)
        {
            services.TryAdd(new ServiceDescriptor(
                typeof(ApplicationContext),
                serviceProvider => new ApplicationContext(new ConstantsInjectionModel(databaseFilename, databasePath)), ServiceLifetime.Scoped));

            services.TryAdd(new ServiceDescriptor(
                typeof(AccountRepository), typeof(IAccountRepository), ServiceLifetime.Scoped));

            services.TryAdd(new ServiceDescriptor(
                typeof(DepositRepository), typeof(IDepositRepository), ServiceLifetime.Scoped));

            services.TryAdd(new ServiceDescriptor(
                typeof(ExpenseRepository), typeof(IExpenseRepository), ServiceLifetime.Scoped));

            services.TryAdd(new ServiceDescriptor(
                typeof(OldBalanceRepository), typeof(IOldBalanceRepository), ServiceLifetime.Scoped));

            services.TryAdd(new ServiceDescriptor(
                typeof(HandlerService), typeof(IHandlerService), ServiceLifetime.Scoped));

            return services;
        }
    }
}
