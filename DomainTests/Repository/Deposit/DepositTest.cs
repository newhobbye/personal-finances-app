using core_application.Interfaces.Repository;
using DomainTests.Dependency;
using System.Threading.Tasks;
using Xunit;

namespace DomainTests.Repository.Deposit
{
    public class DepositTest
    {
        private readonly IDepositRepository _deposit;

        public DepositTest()
        {
            _deposit = DependencyInjection.GetService<IDepositRepository>();
        }

        [Fact(DisplayName = "Capturando depositos")]
        public async Task GetDepositsTest()
        {
            var result = await _deposit.GetDeposits();

            Assert.NotNull(result);
        }

        [Fact(DisplayName = "Capturando Categorias de usuarios em depositos")]
        public async Task GetCategoryDepositsTest()
        {
            var result = await _deposit.GetUserDepositCategories();

            Assert.NotNull(result);
        }

    }
}
