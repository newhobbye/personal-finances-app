using core_application.Models.Enums;
using core_application.Models.Enums.Categories;
using core_application.Models.UserCategories;

namespace core_application.Models.Deposits
{
    public class Deposit
    {
        public Guid Id { get; set; }
        public double Value { get; set; }
        public CategoryDeposit Category { get; set; }
        public UserDepositCategory UserCategory { get; set; }
        public StatusPayment Status { get; set; }
        public DateTime CreationDate { get; set; }
        public string? Note { get; set; }

        public Deposit()
        {
            Id = new Guid();
            CreationDate = DateTime.Now;
        }
    }
}
