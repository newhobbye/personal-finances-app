using core_application.Models.Deposits;
using core_application.Models.Expenses;

namespace core_application.Models.Account
{
    public class Account
    {
        public Guid Id { get; set; }
        public double Balance { get; set; }
        //public int Code { get; set; } = 1;
        public virtual ICollection<OldBalance> OldBalances { get; set; }

        public Account()
        {
            Id = new Guid();
            OldBalances = new List<OldBalance>();
        }
    }

    public static class AccountUpdate
    {
        public static Account UpdateAccount<T>(this Account account, T operation)
        {
            if (operation is Deposit deposit)
            {
                account.Balance += deposit.Value;
            }
            else if(operation is Expense expense)
            {
                account.Balance -= expense.Value;
            }

            return account;
        }
    }
}
