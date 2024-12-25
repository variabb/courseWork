using IAuthenticationServiceNamespace;
using IOrderProductServiceNamespace;
using IProductServiceNamespace;
using IUserServiceNamespace;
using ProductUINamespace;
using UserUINamespace;

namespace AuthenticationUINamespace
{
    public static class AuthenticationUI
    {
        public static void Login(IAuthenticationService authService, IOrderProductService orderProductService, IUserService userService, IProductService productService)
{
    Console.Clear();
    Console.WriteLine("Вхід в систему:");
    Console.Write("Ім'я користувача: ");
    string username = Console.ReadLine();
    Console.Write("Пароль: ");
    string password = Console.ReadLine();

    if (authService.Login(username, password))
    {
        Console.WriteLine("Вхід успішний!");
        UserMenu(username, orderProductService, userService, productService); // передаємо productService
    }
    else
    {
        Console.WriteLine("Невірні дані. Спробуйте ще раз.");
    }
}


        public static void Register(IAuthenticationService authService)
        {
            Console.Clear();
            Console.WriteLine("Реєстрація нового користувача:");
            Console.Write("Ім'я користувача: ");
            string username = Console.ReadLine();
            Console.Write("Пароль: ");
            string password = Console.ReadLine();

            if (authService.Register(username, password))
            {
                Console.WriteLine("Реєстрація успішна!");
            }
            else
            {
                Console.WriteLine("Користувач з таким ім'ям вже існує.");
            }
        }

       public static void UserMenu(string username, IOrderProductService orderProductService, IUserService userService, IProductService productService)
{
    var user = userService.GetByUsername(username);  // Отримуємо користувача для використання userId

    if (user == null)
    {
        Console.WriteLine("Користувач не знайдений.");
        return;
    }

    int userId = user.UserId;  // Отримуємо ID користувача

    while (true)
    {
        Console.Clear();
        Console.WriteLine($"Вітаємо, {username}! Оберіть дію:");
        Console.WriteLine("1. Переглянути товари");
        Console.WriteLine("2. Управління балансом");
        Console.WriteLine("3. Історія замовлень");
        Console.WriteLine("4. Вийти");

        string? choice = Console.ReadLine();
        switch (choice)
        {
            case "1":
                var productUI = new ProductUI(orderProductService);
                productUI.ViewProducts(productService, userId);
                break;
            case "2":
                UserUI.ManageBalance(userService);
                break;
            case "3":
                OrderUI.ViewOrderHistory(userId, orderProductService);
                break;
            case "4":
                return; // Вихід до головного меню
            default:
                Console.WriteLine("Некоректний вибір. Натисніть Enter, щоб спробувати ще раз.");
                Console.ReadLine();
                break;
        }
    }
}

    }
}
