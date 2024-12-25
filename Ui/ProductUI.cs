using IOrderProductServiceNamespace;
using IProductServiceNamespace;

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

       public void ViewProducts(IProductService productService, int userId)
{
    Console.Clear();
    Console.WriteLine("Список товарів:");

    var products = productService.GetAllProducts();
    foreach (var product in products)
    {
        Console.WriteLine($"ID: {product.ProductId}, Назва: {product.ProductName}, Ціна: {product.Price}, Кількість: {product.Quantity}");
    }

    Console.WriteLine("Оберіть товар для покупки (введіть ID), або натисніть Enter для виходу:");
    string input = Console.ReadLine();
    if (int.TryParse(input, out int productId))
    {
        // Викликаємо метод через ін'єкцію залежностей
        _orderProductService.PurchaseProduct(userId, productId);
        Console.WriteLine("Покупка успішна!");
    }
}

    }
}
