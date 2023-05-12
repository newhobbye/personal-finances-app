using core_application.Interfaces.Services;
using core_application.Models.Account;
using core_application.Models.Deposits;
using core_application.Models.Enums;
using core_application.Models.Enums.Categories;
using core_application.Models.Expenses;
using core_application.Models.UserCategories;
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

        #region[Operations of Account]

        [Fact(DisplayName = "Criando conta")]
        public async Task CreateAccountTest()
        {
            var account = new Account
            {
                Balance = 1000,
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

        #endregion

        [Fact(DisplayName = "Deposito e despesas")]
        public async Task OperationInBalanceAccountTest()
        {
            //var deposit = new Deposit
            //{
            //    Value = 150,
            //    Category = CategoryDeposit.Salary,
            //    Status = StatusPayment.Paid,
            //    Note = "Salario",
            //    UserCategory = new UserDepositCategory
            //    {
            //        Category = "Teste"
            //    }
            //};

            var expense = new Expense
            {
                Value = 100,
                Category = CategoryExpense.Investiment,
                Status = StatusPayment.Paid,
                Note = "Despesa de investimento",
                UserCategory = new UserExpenseCategory
                {
                    Category = "Teste despeza"
                }
            };


            var result = await _handlerService.OperationInBalanceAccount(expense);

            Assert.True(result);
        }
    }
}