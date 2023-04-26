using core_application.Models.Deposits;

namespace core_application.Interfaces.Repository
{
    public interface IDepositRepository
    {
        Task<List<Deposit>> GetDeposits();
        Task<bool> InsertDeposit(Deposit deposit);
        Task<bool> UpdateDeposit(Deposit deposit);
        Task<bool> DeleteDeposit(Deposit deposit);
    }
}
