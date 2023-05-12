using core_application.Models.Expenses;

namespace core_application.Models.UserCategories
{
    public class UserExpenseCategory
    {
        public int Id { get; set; }
        public string Category { get; set; }
        public Expense Expense { get; set; }
        public Guid ExpenseId { get; set; }
    }
}
