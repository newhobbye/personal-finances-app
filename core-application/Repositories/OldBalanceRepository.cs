using core_application.Interfaces.Repository;
using core_application.Models.Account;
using Microsoft.EntityFrameworkCore;

namespace core_application.Repositories
{
    public class OldBalanceRepository: IOldBalanceRepository
    {

        private readonly ApplicationContext _applicationContext;

        public OldBalanceRepository(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }

        public async Task<bool> Insert(OldBalance balance)
        { 
            if(balance == null) { return false; }

            _applicationContext.OldBalances.Add(balance);

            int line = await _applicationContext.SaveChangesAsync();

            return (line > 0);
        }

        public async Task<List<OldBalance>> GetBalancesById(Guid id)
        {
            return await _applicationContext.OldBalances.Where(i => i.AccountId == id).ToListAsync();
        }

        public async Task<List<OldBalance>> GetBalances()
        {
            return await _applicationContext.OldBalances.ToListAsync();
        }
    }
}
