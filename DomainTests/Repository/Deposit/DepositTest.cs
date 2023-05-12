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

        [Fact(DisplayName = "Inserindo depositos")]
        public async Task InsertDepositsTest()
        {
            var deposit = new core_application.Models.Deposits.Deposit
            {
                Value = 150,
                Category = core_application.Models.Enums.Categories.CategoryDeposit.Salary,
                Note = "Teste sem categoria de usuario"
            };

            var result = await _deposit.InsertDeposit(deposit);

            Assert.True(result);
        }

    }
}
