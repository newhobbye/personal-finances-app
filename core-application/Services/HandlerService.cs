using core_application.Interfaces.Repository;
using core_application.Models.Account;

namespace core_application.Services
{
    public class HandlerService
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IOldBalanceRepository _oldBalanceRepository;
        private readonly IExpenseRepository _expenseRepository;
        private readonly IDepositRepository _depositRepository;

        public HandlerService(IAccountRepository accountRepository, IOldBalanceRepository oldBalanceRepository,
            IExpenseRepository expenseRepository, IDepositRepository depositRepository)
        {
            _accountRepository = accountRepository;
            _oldBalanceRepository = oldBalanceRepository;
            _expenseRepository = expenseRepository;
            _depositRepository = depositRepository;
        }


        public async Task<bool> CreateAccount(Account account)
        {
            bool valid = await _accountRepository.InsertAccount(account);
            return valid;
        }
    }
}
