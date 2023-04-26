using core_application.Models.Account;

namespace core_application.Interfaces.Repository
{
    public interface IOldBalanceRepository
    {
        Task<bool> Insert(OldBalance balance);
        Task<List<OldBalance>> GetBalances(Guid id);
    }
}
