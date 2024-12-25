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

class Program
{
    static void Main(string[] args)
    {
        // Створення контексту бази даних (припустимо, DbContext реалізовано у вашому проєкті)
        DbContext dbContext = new DbContext();

        // Ініціалізація репозиторіїв з передачею DbContext
        IUserRepository userRepository = new UserRepository(dbContext);
        IProductRepository productRepository = new ProductRepository(dbContext);
        IOrderRepository orderRepository = new OrderRepository(dbContext); // Додано репозиторій для замовлень

        // Ініціалізація сервісів
        IUserService userService = new UserService(userRepository);
        IProductService productService = new ProductService(productRepository);

        // OrderService і TransactionService також можуть вимагати залежностей
        IOrderService orderService = new OrderService(orderRepository); // Використовуємо orderRepository
        ITransactionService transactionService = new TransactionService(userService);

        // Ініціалізація OrderProductService і AuthenticationService
        IOrderProductService orderProductService = new OrderProductService(orderService, productService, transactionService);
        IAuthenticationService authService = new AuthenticationService(userService);

        // Ініціалізація залежностей для UserUI
        UserUI.Initialize(transactionService);

        // Запуск головного меню
        MenuUI.MainMenu(authService, orderProductService, userService, productService);
    }
}
