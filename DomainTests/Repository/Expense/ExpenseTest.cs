using core_application.Interfaces.Repository;
using DomainTests.Dependency;
using System.Threading.Tasks;
using Xunit;

namespace DomainTests.Repository.Expense
{
    public class ExpenseTest
    {
        private readonly IExpenseRepository _expense;

        public ExpenseTest()
        {
            _expense = DependencyInjection.GetService<IExpenseRepository>();
        }

        [Fact(DisplayName = "Capturando despesas")]
        public async Task GetDepositsTest()
        {
            var result = await _expense.GetExpenses();

            Assert.NotNull(result);
        }

        [Fact(DisplayName = "Capturando Categorias de usuarios em despesas")]
        public async Task GetCategoryDepositsTest()
        {
            var result = await _expense.GetGetUserExpenseCategories();

            Assert.NotNull(result);
        }
    }
}
