using core_application.Interfaces.Repository;
using core_application.Models.Account;
using Microsoft.EntityFrameworkCore;

namespace core_application.Repositories
{
    public class AccountRepository: IAccountRepository
    {
        private readonly ApplicationContext _applicationContext;

        public AccountRepository(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }

        public async Task<Account> GetAccount()
        {
            return _applicationContext.Accounts
                .Include(old => old.OldBalances)
                .ToList().FirstOrDefault()!;
        }

        public async Task<bool> InsertAccount(Account account)
        {

            if (await GenericValidation(account) == false)
            {
                return false;
            }

            _applicationContext.Accounts.Add(account);
            int line = await _applicationContext.SaveChangesAsync();

            return (line > 0)? true: false;
        }

        public async Task<bool> UpdateAccount(Account account)
        {
            if (await GenericValidation(account) == false)
            {
                return false;
            }

            _applicationContext.Accounts.Update(account);
            int line = await _applicationContext.SaveChangesAsync();

            return (line > 0) ? true : false;
        }

        public async Task<bool> DeleteAccount(Account account)
        {
            if (await GenericValidation(account) == false)
            {
                return false;
            }

            foreach (var oldBalance in account.OldBalances)
            {
                _applicationContext.OldBalances.Remove(oldBalance);
            }
            _applicationContext.Accounts.Remove(account);

            int line = await _applicationContext.SaveChangesAsync();

            return (line > 0) ? true : false;
        }




        private async Task<bool> GenericValidation(Account account)
        {
            var accountExist = await GetAccount();

            if (account == null || accountExist != null)
            {
                return false;
            }
            else return true;
        }
    }
}
