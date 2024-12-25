using IOrderProductServiceNamespace;
using IProductServiceNamespace;
using IUserServiceNamespace;
using UserServiceNamespace;

namespace ProductUINamespace
{
    public class ProductUI
    {
        private readonly IOrderProductService _orderProductService;

        // Конструктор для ін'єкції залежності
        public ProductUI(IOrderProductService orderProductService)
        {
            _orderProductService = orderProductService;
        }

    public void ViewProducts(IProductService productService, IUserService userService, int userId)
{
    Console.Clear();
    Console.WriteLine("Список товарів:");

    var products = productService.GetAllProducts();
    foreach (var product in products)
    {
        Console.WriteLine($"ID: {product.ProductId}, Назва: {product.ProductName}, Ціна: {product.Price}, Кількість: {product.Quantity}");
    }

    decimal totalAmount = 0;

    while (true)
    {
        Console.WriteLine("Оберіть товар для покупки (введіть ID), або натисніть Enter для завершення:");
        string input = Console.ReadLine();
        if (string.IsNullOrEmpty(input)) break;

        if (int.TryParse(input, out int productId))
        {
            var product = productService.GetProductById(productId);
            if (product == null)
            {
                Console.WriteLine("Товар не знайдений.");
                continue;
            }

            Console.Write("Введіть кількість: ");
            if (int.TryParse(Console.ReadLine(), out int quantity) && quantity <= product.Quantity)
            {
                decimal amount = product.Price * quantity;
                totalAmount += amount;

                // Додати товар до кошика або здійснити покупку
                _orderProductService.PurchaseProduct(userId, productId);
                Console.WriteLine($"Товар додано до кошика. Загальна сума: {totalAmount}");

                Console.WriteLine("Бажаєте додати ще товар? (y/n)");
                string addMore = Console.ReadLine();
                if (addMore?.ToLower() != "y") break;
            }
            else
            {
                Console.WriteLine("Некоректна кількість товару.");
            }
        }
        else
        {
            Console.WriteLine("Некоректний ID товару.");
        }
    }

    // Перевірка балансу
    var user = userService.Get(userId); // Використання екземпляра userService
    if (user.Balance >= totalAmount)
    {
        Console.WriteLine($"Ваша сума до сплати: {totalAmount}. Підтвердьте покупку (y/n):");
        string confirm = Console.ReadLine();
        if (confirm?.ToLower() == "y")
        {
            user.Balance -= totalAmount;
            userService.Update(user); // Використання екземпляра userService
            Console.WriteLine("Покупка успішно здійснена!");
        }
        else
        {
            Console.WriteLine("Покупка скасована.");
        }
    }
    else
    {
        Console.WriteLine("Недостатньо коштів на рахунку.");
    }

    Console.WriteLine("Натисніть Enter, щоб повернутися в меню.");
    Console.ReadLine();
}

        }
    }

