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
        public static IServiceCollection AddDependencies(this IServiceCollection services)
        {
            //services.TryAddScoped<ApplicationContext>();
            services.AddDbContext<ApplicationContext>();

            services.TryAdd(new ServiceDescriptor(
                typeof(IAccountRepository), typeof(AccountRepository), ServiceLifetime.Scoped));

            services.TryAdd(new ServiceDescriptor(
                typeof(IDepositRepository), typeof(DepositRepository), ServiceLifetime.Scoped));

            services.TryAdd(new ServiceDescriptor(
                typeof(IExpenseRepository), typeof(ExpenseRepository), ServiceLifetime.Scoped));

            services.TryAdd(new ServiceDescriptor(
                typeof(IOldBalanceRepository), typeof(OldBalanceRepository), ServiceLifetime.Scoped));

            services.TryAdd(new ServiceDescriptor(
                typeof(IHandlerService), typeof(HandlerService), ServiceLifetime.Scoped));

            return services;
        }
    }
}
