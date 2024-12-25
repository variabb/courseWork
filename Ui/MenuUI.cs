using AuthenticationUINamespace;
using IAuthenticationServiceNamespace;
using IOrderProductServiceNamespace;
using IProductServiceNamespace;
using IUserServiceNamespace;

namespace MenuUINamespace
{
    public static class MenuUI
    {
          public static void MainMenu(IAuthenticationService authService, IOrderProductService orderProductService, IUserService userService, IProductService productService)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Головне меню:");
                Console.WriteLine("1. Увійти");
                Console.WriteLine("2. Зареєструватися");
                Console.WriteLine("3. Вийти");

                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        AuthenticationUI.Login(authService, orderProductService, userService, productService); // передаємо productService
                        break;
                    case "2":
                        AuthenticationUI.Register(authService);
                        break;
                    case "3":
                        Console.WriteLine("До побачення!");
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
