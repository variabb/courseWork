using System.Transactions;
using ITransactionServiceNamespace;
using IUserServiceNamespace;
using UserEntityNamespace;

namespace TransactionServiceNamespace
{
    public class TransactionService : ITransactionService
    {
        private readonly IUserService _userService;

        // Конструктор для ініціалізації залежностей
        public TransactionService(IUserService userService)
        {
            _userService = userService;
        }

        // Метод для списання коштів з балансу користувача
        public bool DeductBalance(int userId, decimal amount)
        {
            // Перевірка чи існує користувач
            if (!_userService.IsUserExistById(userId))
            {
                return false;
            }

            // Отримання користувача
            var user = _userService.Get(userId);
            if (user == null || user.Balance < amount)
            {
                return false; // Недостатньо коштів або користувач не знайдений
            }

            // Оновлення балансу
            _userService.UpdateBalance(userId, -amount);
            return true;
        }

        // Метод для поповнення балансу користувача
        public bool AddBalance(int userId, decimal amount)
        {
            // Перевірка чи існує користувач
            if (!_userService.IsUserExistById(userId))
            {
                return false;
            }

            // Перевірка валідності суми
            if (amount <= 0)
            {
                return false;
            }

            // Оновлення балансу
            _userService.UpdateBalance(userId, amount);
            return true;
        }
    }
}