using core_application.Models.Deposits;

namespace core_application.Models.UserCategories
{
    public class UserDepositCategory
    {
        public int Id { get; set; }
        public string Category { get; set; }
        public Deposit Deposit { get; set; }
    }
}
