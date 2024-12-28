using AuthentificationServiceNamespace;
using IAuthenticationServiceNamespace;
using IOrderProductServiceNamespace;
using IOrderServiceNamespace;
using IProductRepositoryNamespace;
using IProductServiceNamespace;
using ITransactionServiceNamespace;
using IUserRepositoryNamespace;
using IUserServiceNamespace;
using OrderProductServiceNamespace;
using OrderServiceNamespace;
using ProductRepositoryNamespace;
using ProductServiceNamespace;
using TransactionServiceNamespace;
using UserRepositoryNamespace;
using UserServiceNamespace;
using UserUINamespace;
using MenuUINamespace;
using dataBase;
using IOrderRepositoryNamespace;
using OrderRepositoryNamespace;
using DatabaseSeederNamespace;

class Program
{
    static void Main(string[] args)
    {
        // Ініціалізація бази даних
        UserUI user = new UserUI();
        MenuUI menu = new MenuUI();
        var dbContext = new DbContext();
        var databaseSeeder = new DatabaseSeeder(dbContext);
        databaseSeeder.Seed();

        // Ініціалізація репозиторіїв
        var productRepository = new ProductRepository(dbContext);
        IUserRepository userRepository = new UserRepository(dbContext);
        IOrderRepository orderRepository = new OrderRepository(dbContext);

        // Ініціалізація сервісів
        IUserService userService = new UserService(userRepository);
        IProductService productService = new ProductService(productRepository);
        IOrderService orderService = new OrderService(orderRepository);
        ITransactionService transactionService = new TransactionService(userService);

        // Ініціалізація логіки для замовлень та автентифікації
        IOrderProductService orderProductService = new OrderProductService(orderService, productService, transactionService);
        IAuthenticationService authService = new AuthenticationService(userService);

        // Ініціалізація інтерфейсу користувача
        user.Initialize(transactionService);

        // Запуск головного меню
        menu.MainMenu(authService, orderProductService, userService, productService);
    }
}
