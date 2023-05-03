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

        public async Task<bool> OperationInBalanceAccount<T>(T operation)
        {
            //tratar validações pois mesmo que de erro, vai considerar só a operação final
            var account = await _accountRepository.GetAccount();

            if (account == null) return false;
            

            if (operation is Deposit deposit)
            {
                var balance = OldBalance.CreateOldBalance(account);
                if (!await _oldBalanceRepository.Insert(balance)) return false;

                account.OldBalances.Add(balance);
                account.UpdateAccount(deposit);
                if (!await _depositRepository.InsertDeposit(deposit)) return false;
            }
            else if (operation is Expense expense)
            {
                var balance = OldBalance.CreateOldBalance(account);
                if (!await _oldBalanceRepository.Insert(balance)) return false;

                account.OldBalances.Add(balance);
                account.UpdateAccount(expense);
                if (!await _expenseRepository.InsertExpense(expense)) return false;
            }

            if (!await _accountRepository.UpdateAccount(account)) return false; 

            return true;

        }

        public async Task<bool> EditBalanceAccount(double value)
        {
            var account = await _accountRepository.GetAccount();

            if (account == null) return false;
            
            var oldBalance = OldBalance.CreateOldBalance(account);
            if(!await _oldBalanceRepository.Insert(oldBalance)) return false;

            account.Balance = value;
            account.OldBalances.Add(oldBalance);

            if (!await _accountRepository.UpdateAccount(account)) return false;

            return true;

        }

        public async Task<bool> EditExpenseOrDeposit<T>(T operation)
        {
            var account = await _accountRepository.GetAccount();

            if (account == null) return false;

            var oldBalance = OldBalance.CreateOldBalance(account);

            if (!await _oldBalanceRepository.Insert(oldBalance)) return false;

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

                if (!await _depositRepository.UpdateDeposit(deposit)) return false;
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

                if(!await _expenseRepository.UpdateExpense(expense)) return false;
            }

            if (!await _accountRepository.UpdateAccount(account)) return false;

            return true;

        }

    }
}
