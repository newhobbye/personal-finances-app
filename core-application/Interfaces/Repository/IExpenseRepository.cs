using core_application.Models.Expenses;
using core_application.Models.UserCategories;

namespace core_application.Interfaces.Repository
{
    public interface IExpenseRepository
    {
        Task<List<Expense>> GetExpenses();
        Task<Expense> GetExpenseById(Guid id);
        Task<List<UserExpenseCategory>> GetGetUserExpenseCategories();
        Task<bool> InsertExpense(Expense expense);
        Task<bool> UpdateExpense(Expense expense);
        Task<bool> DeleteExpense(Expense expense);
    }
}
