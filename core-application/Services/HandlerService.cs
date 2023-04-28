using core_application.Interfaces.Repository;
using core_application.Models.Account;
using core_application.Models.Deposits;
using core_application.Models.Expenses;

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

        //terminar service, ver se o banco vai precisar de migrations e ver mais sobre o path do db

        //deposito e despesas
        public async Task<bool> OperationInBalanceAccount<T>(T operation)
        {
            //tratar validações pois mesmo que de erro, vai considerar só a operação final
            var account = await GetAccount();
            bool success = false;

            if (account == null)
            {
                return success;
            }

            if (operation is Deposit deposit)
            {
                var balance = OldBalance.CreateOldBalance(account);
                success = await _oldBalanceRepository.Insert(balance);

                account.OldBalances.Add(balance);
                account.UpdateAccount(deposit);
                success = await _depositRepository.InsertDeposit(deposit);
            }
            else if (operation is Expense expense)
            {
                var balance = OldBalance.CreateOldBalance(account);
                success = await _oldBalanceRepository.Insert(balance);

                account.OldBalances.Add(balance);
                account.UpdateAccount(expense);
                success = await _expenseRepository.InsertExpense(expense);
            }

            success = await UpdateAccount(account);

            return success;

        }

        public async Task<bool> EditBalanceAccount(double value)
        {
            //tratar validações pois mesmo que de erro, vai considerar só a operação final
            var account = await GetAccount();
            bool success = false;

            if (account == null)
            {
                return success;
            }

            var oldBalance = OldBalance.CreateOldBalance(account);
            success = await _oldBalanceRepository.Insert(oldBalance);

            account.Balance = value;
            account.OldBalances.Add(oldBalance);

            success = await _accountRepository.UpdateAccount(account);

            return success;

        }

        public async Task<bool> EditExpenseOrDeposit<T>(T operation)
        {
            //tratar validações pois mesmo que de erro, vai considerar só a operação final
            var account = await GetAccount();
            bool success = false;

            if (account == null)
            {
                return success;
            }

            var oldBalance = OldBalance.CreateOldBalance(account);
            success = await _oldBalanceRepository.Insert(oldBalance);
            account.OldBalances.Add(oldBalance);

            if (operation is Deposit deposit)
            {
                var depositInDB = await _depositRepository.GetDepositById(deposit.Id);
                var oldValue = depositInDB.Value;
                var diferenceValue = 0.0;

                if(oldValue > deposit.Value)
                {
                    //diferença negativa
                    diferenceValue = oldValue - deposit.Value;
                    account.Balance -= diferenceValue; 
                }
                else
                {
                    //diferença positiva
                    diferenceValue = deposit.Value - oldValue;
                    account.Balance += diferenceValue;
                }

                success = await _depositRepository.UpdateDeposit(deposit);
            }
            else if (operation is Expense expense)
            {
                var expenseInDb = await _expenseRepository.GetExpenseById(expense.Id);
                var oldValue = expenseInDb.Value;
                var diferenceValue = 0.0;

                if (oldValue > expense.Value)
                {
                    //diferença positiva
                    diferenceValue = oldValue - expense.Value;
                    account.Balance += diferenceValue;
                }
                else
                {
                    //diferença negativa
                    diferenceValue = expense.Value - oldValue;
                    account.Balance -= diferenceValue;
                }

                success = await _expenseRepository.UpdateExpense(expense);
            }

            success = await _accountRepository.UpdateAccount(account);

            return success;

        }

        #region[Manipulação de conta]

        public async Task<bool> CreateAccount(Account account) =>
            await _accountRepository.InsertAccount(account);

        public async Task<bool> UpdateAccount(Account account) =>
            await _accountRepository.UpdateAccount(account);

        public async Task<Account> GetAccount() =>
            await _accountRepository.GetAccount();

        public async Task<bool> DeleteAccount(Account account) =>
            await _accountRepository.DeleteAccount(account);

        #endregion


    }
}
