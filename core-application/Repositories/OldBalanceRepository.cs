using core_application.Models.Account;

namespace core_application.Repositories
{
    public class OldBalanceRepository
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
            return true;
        }

        public async Task<List<OldBalance>> GetBalances(Guid id)
        {
            return _applicationContext.OldBalances.Where(i => i.AccountId == id).ToList();
        }
    }
}
