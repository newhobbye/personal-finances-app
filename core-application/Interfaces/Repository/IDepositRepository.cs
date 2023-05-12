using core_application.Models.Deposits;
using core_application.Models.UserCategories;

namespace core_application.Interfaces.Repository
{
    public interface IDepositRepository
    {
        Task<List<Deposit>> GetDeposits();
        Task<Deposit> GetDepositById(Guid id);
        Task<List<UserDepositCategory>> GetUserDepositCategories();
        Task<bool> InsertDeposit(Deposit deposit);
        Task<bool> UpdateDeposit(Deposit deposit);
        Task<bool> DeleteDeposit(Deposit deposit);
    }
}
