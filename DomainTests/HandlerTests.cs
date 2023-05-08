using core_application.Interfaces.Services;
using core_application.Models.Account;
using DomainTests.Dependency;
using System.Threading.Tasks;
using Xunit;

namespace DomainTests
{
    public class HandlerTests
    {

        private readonly IHandlerService _handlerService;

        public HandlerTests()
        {
            _handlerService = DependencyInjection.GetService<IHandlerService>();
        }

        [Fact(DisplayName = "Criando conta")]
        public async Task CreateAccountTest()
        {
            var account = new Account
            {
                Balance = 1000,
            };
            //code danto pau sem estar na entidade do db
            var result = await _handlerService.CreateAccount(account);

            Assert.True(result);
        }

        [Fact(DisplayName = "Pegando conta")]
        public async Task GetAccountTest()
        {
            var result = await _handlerService.GetAccount();

            Assert.NotNull(result);
        }

        [Fact(DisplayName = "Removendo uma conta")]
        public async Task DeleteAccountTest()
        {
            var account = await _handlerService.GetAccount();
            var result = await _handlerService.DeleteAccount(account);

            Assert.NotNull(result);
        }

        [Fact(DisplayName = "Editando uma conta")]
        public async Task UpdateAccountTest()
        {
            var account = await _handlerService.GetAccount();
            account.Balance = 1500;

            var result = await _handlerService.UpdateAccount(account);

            Assert.NotNull(result);
        }
    }
}