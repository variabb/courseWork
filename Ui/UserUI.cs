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
                   // Перевіряємо, чи існує активний користувач
            if (!Session.UserId.HasValue)
            {
                Console.WriteLine("Помилка: користувач не авторизований.");
                Console.WriteLine("Натисніть Enter, щоб повернутися до меню...");
                Console.ReadLine();
                return;
            }

            Console.Write("Введіть суму для поповнення: ");
            decimal amount;
            if (decimal.TryParse(Console.ReadLine(), out amount))
            {
                // Викликаємо метод через екземпляр _transactionService
                bool success = _transactionService.AddBalance(Session.UserId.Value, amount);

                if (success)
                {
                    Console.WriteLine("Баланс успішно поповнено!");
                }
                else
                {
                    Console.WriteLine("Помилка: не вдалося поповнити баланс. Перевірте введену суму.");
                }
            }
            else
            {
                Console.WriteLine("Некоректне значення. Спробуйте ще раз.");
            }

            Console.WriteLine("Натисніть Enter, щоб повернутися до меню...");
            Console.ReadLine();
            break;
                case "2":
                    return;
                default:
            Console.WriteLine("Некоректний вибір. Натисніть Enter, щоб спробувати ще раз.");
            Console.ReadLine();
            break;
            }
        }
    }
}
