using Core;
using ITransactionServiceNamespace;
using IUserServiceNamespace;

namespace UserUINamespace
{
    public static class UserUI
    {
        private static ITransactionService _transactionService;

        // Додаємо конструктор для ініціалізації залежності
        public static void Initialize(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        public static void ManageBalance(IUserService userService)
        {
            Console.Clear();
            Console.WriteLine("Управління балансом:");
            Console.WriteLine("1. Поповнити баланс");
            Console.WriteLine("2. Вийти");

            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    Console.Write("Введіть суму для поповнення: ");
                    decimal amount;
                    if (decimal.TryParse(Console.ReadLine(), out amount))
                    {
                        // Викликаємо метод через екземпляр _transactionService
                        _transactionService.AddBalance(Session.UserId.Value, amount);
                        Console.WriteLine("Баланс успішно поповнено!");
                    }
                    break;
                case "2":
                    return;
                default:
                    Console.WriteLine("Некоректний вибір.");
                    break;
            }
        }
    }
}
