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
                Code = 1
            };

            var result = await _handlerService.CreateAccount(account);

            Assert.True(result);
        }

        [Fact(DisplayName = "Pegando conta")]
        public async Task GetAccountTest()
        {
            var result = await _handlerService.GetAccount();

            Assert.NotNull(result);
        }
    }
}