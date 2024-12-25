namespace ITransactionServiceNamespace
{
    public interface ITransactionService
    {
        bool AddBalance(int userId, decimal amount); //* Поповнення балансу
        bool DeductBalance(int userId, decimal amount); //* Зняття коштів з балансу
    }
}