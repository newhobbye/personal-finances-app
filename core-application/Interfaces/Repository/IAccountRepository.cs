using core_application.Models.Account;

namespace core_application.Interfaces.Repository
{
    public interface IAccountRepository
    {
        Task<Account> GetAccount();
        Task<bool> InsertAccount(Account account);
        Task<bool> UpdateAccount(Account account);
        Task<bool> DeleteAccount(Account account);

    }
}
