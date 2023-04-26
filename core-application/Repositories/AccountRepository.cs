using core_application.Models.Account;
using Microsoft.EntityFrameworkCore;

namespace core_application.Repositories
{
    public class AccountRepository
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

            if (GenericValidation(account) == false)
            {
                return false;
            }

            _applicationContext.Accounts.Add(account);
            _applicationContext.SaveChanges();

            return true;
        }

        public async Task<bool> UpdateAccount(Account account)
        {
            if (GenericValidation(account) == false)
            {
                return false;
            }

            _applicationContext.Accounts.Update(account);

            return true;
        }

        public async Task<bool> DeleteAccount(Account account)
        {
            if (GenericValidation(account) == false)
            {
                return false;
            }

            foreach (var oldBalance in account.OldBalances)
            {
                _applicationContext.OldBalances.Remove(oldBalance);
            }
            _applicationContext.Accounts.Remove(account);

            return true;
        }




        private bool GenericValidation(Account account)
        {
            var accountExist = GetAccount();

            if (account == null || accountExist != null)
            {
                return false;
            }
            else return true;
        }
    }
}
