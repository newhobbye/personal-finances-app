using core_application.Interfaces.Repository;
using core_application.Models.Expenses;
using core_application.Models.UserCategories;
using Microsoft.EntityFrameworkCore;

namespace core_application.Repositories
{
    public class ExpenseRepository: IExpenseRepository
    {
        private readonly ApplicationContext _applicationContext;

        public ExpenseRepository(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }

        public async Task<List<Expense>> GetExpenses()
        {
            return await _applicationContext.Expenses.Include(c => c.UserCategory).ToListAsync();
        }

        public async Task<List<UserExpenseCategory>> GetGetUserExpenseCategories()
        {
            return await _applicationContext.UserExpenseCategories.ToListAsync();
        }

        public async Task<Expense> GetExpenseById(Guid id)
        {
            return await _applicationContext.Expenses.Include(c => c.UserCategory).Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<bool> InsertExpense(Expense expense)
        {
            if (expense == null) { return false; }

            _applicationContext.Expenses.Add(expense);

            if (expense.UserCategory != null)
            {
                _applicationContext.UserExpenseCategories.Add(expense.UserCategory);
            }

            int line = await _applicationContext.SaveChangesAsync();

            return (line > 0) ? true : false;
        }

        public async Task<bool> UpdateExpense(Expense expense)
        {
            if (expense == null) { return false; }

            _applicationContext.Expenses.Update(expense);

            int line = await _applicationContext.SaveChangesAsync();

            return (line > 0) ? true : false;
        }

        public async Task<bool> DeleteExpense(Expense expense)
        {
            if (expense == null) { return false; }

            _applicationContext.Expenses.Remove(expense);

            int line = await _applicationContext.SaveChangesAsync();

            return (line > 0) ? true : false;
        }
    }
}
