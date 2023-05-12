using core_application.Interfaces.Repository;
using core_application.Models.Deposits;
using core_application.Models.UserCategories;
using Microsoft.EntityFrameworkCore;

namespace core_application.Repositories
{
    public class DepositRepository: IDepositRepository
    {
        private readonly ApplicationContext _applicationContext;

        public DepositRepository(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }

        public async Task<List<Deposit>> GetDeposits()
        {
            return await _applicationContext.Deposits.Include(c => c.UserCategory).ToListAsync();
        }

        public async Task<Deposit> GetDepositById(Guid id)
        {
            return await _applicationContext.Deposits.Include(c => c.UserCategory).Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<List<UserDepositCategory>> GetUserDepositCategories()
        {
            return await _applicationContext.UserDepositCategories.ToListAsync();
        } 

        public async Task<bool> InsertDeposit(Deposit deposit)
        {
            if (deposit == null) { return false; }

            _applicationContext.Deposits.Add(deposit);

            if (deposit.UserCategory != null)
            {
                _applicationContext.UserDepositCategories.Add(deposit.UserCategory);
            }

            int line = await _applicationContext.SaveChangesAsync();

            return (line > 0) ? true : false;
        }

        public async Task<bool> UpdateDeposit(Deposit deposit)
        {
            if (deposit == null) { return false; }

            _applicationContext.Deposits.Update(deposit);

            int line = await _applicationContext.SaveChangesAsync();

            return (line > 0) ? true : false;
        }

        public async Task<bool> DeleteDeposit(Deposit deposit)
        {
            if (deposit == null) { return false; }

            _applicationContext.Deposits.Remove(deposit);

            int line = await _applicationContext.SaveChangesAsync();

            return (line > 0) ? true : false;
        }
    }
}
