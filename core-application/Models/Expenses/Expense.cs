using core_application.Models.Enums;
using core_application.Models.Enums.Categories;
using core_application.Models.UserCategories;

namespace core_application.Models.Expenses
{
    public class Expense
    {
        public Guid Id { get; set; }
        public double Value { get; set; }
        public CategoryExpense Category { get; set; }
        public UserExpenseCategory UserCategory { get; set; }
        public StatusPayment Status { get; set; }
        public DateTime CreationDate { get; set; } 
        public string? Note { get; set; }

        public Expense()
        {
            Id = new Guid();
            CreationDate = DateTime.Now;
        }
    }
}
