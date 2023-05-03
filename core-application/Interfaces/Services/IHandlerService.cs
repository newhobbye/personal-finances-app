namespace core_application.Interfaces.Services
{
    public interface IHandlerService
    {
        Task<bool> OperationInBalanceAccount<T>(T operation);
        Task<bool> EditBalanceAccount(double value);
        Task<bool> EditExpenseOrDeposit<T>(T operation);
    }
}
