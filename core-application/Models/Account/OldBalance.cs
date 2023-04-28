using Microsoft.Identity.Client;

namespace core_application.Models.Account
{
    public class OldBalance
    {
        public Guid Id { get; set; }
        public Guid AccountId { get; set; }
        public double OldBalanceValue { get; set; }
        public Account Account { get; set; }
        public DateTime BalanceDate { get; set; }

        public OldBalance()
        {
            Id = new Guid();
            BalanceDate = DateTime.Now;
        }

        public static OldBalance CreateOldBalance(Account account)
        {
            var balance = new OldBalance
            {
                AccountId = account.Id,
                OldBalanceValue = account.Balance,
            };

            return balance;
        }
    }
}
