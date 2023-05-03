using core_application.Models.Account;

namespace core_application.Interfaces.Services
{
    public interface IHandlerService
    {
        Task<bool> OperationInBalanceAccount<T>(T operation);
        Task<bool> EditBalanceAccount(double value);
        Task<bool> EditExpenseOrDeposit<T>(T operation);
        Task<bool> CreateAccount(Account account);
        Task<bool> UpdateAccount(Account account);
        Task<Account> GetAccount();
        Task<bool> DeleteAccount(Account account);
    }
}
