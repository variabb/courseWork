using Core;
using IAuthenticationServiceNamespace;
using IOrderProductServiceNamespace;
using IProductServiceNamespace;
using IUserServiceNamespace;
using ProductUINamespace;
using UserServiceNamespace;
using UserUINamespace;

namespace AuthenticationUINamespace
{
    public  class AuthenticationUI
    {
        Session session = new Session();
   public  void Login(IAuthenticationService authService, IOrderProductService orderProductService, IUserService userService, IProductService productService)
{
          
    Console.Clear();
    Console.WriteLine("Вхід в систему:");
    Console.Write("Ім'я користувача: ");
    string username = Console.ReadLine();
    Console.Write("Пароль: ");
    string password = Console.ReadLine();

    if (authService.Login(username, password))
    {
        // Отримуємо дані користувача
        var user = userService.GetByUsername(username);
        if (user != null)
        {
            // Оновлюємо Session
            session.UserId = user.UserId;
            session.Username = user.Username;

            Console.WriteLine("Вхід успішний!");
            UserMenu(username, orderProductService, userService, productService); // передаємо userService та productService
        }
        else
        {
            Console.WriteLine("Помилка: користувача не знайдено.");
        }
    }
    else
    {
        Console.WriteLine("Невірні дані. Спробуйте ще раз.");
    }

    Console.WriteLine("Натисніть Enter, щоб повернутися до головного меню...");
    Console.ReadLine();
}

      public  void Register(IAuthenticationService authService)
{
    Console.Clear();
    Console.WriteLine("Реєстрація нового користувача:");
    Console.Write("Ім'я користувача: ");
    string username = Console.ReadLine();
    Console.Write("Пароль: ");
    string password = Console.ReadLine();

        if (authService.UserExistsByUsername(username))
    {

        Console.WriteLine("Користувач з таким ім'ям вже існує.");
    }
    else if (authService.Register(username, password))
    {
        Console.WriteLine("Реєстрація успішна!");
    }
    else
    {
        Console.WriteLine("Сталася помилка при реєстрації.");
    }

    Console.WriteLine("Натисніть Enter, щоб продовжити...");
    Console.ReadLine();
}


    public  void UserMenu(string username, IOrderProductService orderProductService, IUserService userService, IProductService productService)
            {
            var user = userService.GetByUsername(username);
            OrderUI order = new OrderUI();
            UserUI userObj = new UserUI();
                if (user == null)
                {
                    Console.WriteLine("Користувач не знайдений.");
                    Console.WriteLine("Натисніть Enter, щоб повернутися до головного меню...");
                    Console.ReadLine();
                    return;
                }

                int userId = user.UserId;

                while (true)
                {
                    Console.Clear();
                    Console.WriteLine($"Вітаємо, {username}! Оберіть дію:");
                    Console.WriteLine("1. Переглянути товари");
                    Console.WriteLine("2. Управління балансом");
                    Console.WriteLine("3. Історія замовлень");
                    Console.WriteLine("4. Переглянути баланс");
                    Console.WriteLine("5. Вийти");

                    string? choice = Console.ReadLine();
                    switch (choice)
                    {
                        case "1":
                            var productUI = new ProductUI(orderProductService);
                            productUI.ViewProducts(productService, userService, userId);
                            break;
                        case "2":
                            userObj.ManageBalance(userService);
                            break;
                        case "3":
                            order.ViewOrderHistory(userId, orderProductService);
                            break;
                        case "4":
                            // Перегляд поточного балансу
                            decimal balance = userService.GetBalance(userId);
                            Console.WriteLine($"Ваш поточний баланс: {balance} грн.");
                            Console.WriteLine("Натисніть Enter, щоб повернутися до меню...");
                            Console.ReadLine();
                            break;
                        case "5":
                            // Очищення сесії
                            session.Clear();
                            Console.WriteLine("Ви вийшли з системи.");
                            return;
                        default:
                            Console.WriteLine("Некоректний вибір. Натисніть Enter, щоб спробувати ще раз.");
                            Console.ReadLine();
                            break;
                    }
                }
            }



    }
}
