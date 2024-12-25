using OrderEntityNamespace;
using IOrderProductServiceNamespace;
using IOrderServiceNamespace;
using IProductServiceNamespace;
using ITransactionServiceNamespace;
using UserEntityNamespace;
using ProductEntityNamespace;

namespace OrderProductServiceNamespace
{
    public class OrderProductService : IOrderProductService
    {
        private readonly IOrderService _orderService;
        private readonly IProductService _productService;
        private readonly ITransactionService _transactionService;

        public OrderProductService(IOrderService orderService, IProductService productService, ITransactionService transactionService)
        {
            _orderService = orderService;
            _productService = productService;
            _transactionService = transactionService;
        }

        public bool PurchaseProduct(int userId, int productId)
        {
            var product = _productService.GetProductById(productId);
            if (product == null || product.Quantity <= 0) 
            {
                return false; // Продукт не знайдено або він недоступний для покупки
            }

            // Перевірка балансу користувача та списання коштів
            if (!_transactionService.DeductBalance(userId, product.Price))
            {
                return false; // Недостатньо коштів
            }

            // Створення нового замовлення
            var order = new OrderEntity
            {
                UserId = userId,
                Products = new List<ProductEntity> { product },
                TotalAmount = product.Price
            };

            _orderService.CreateOrder(order);

            // Оновлення кількості товару
            product.Quantity -= 1;
            _productService.UpdateProduct(product); // Оновлюємо продукт

            return true; // Успішна покупка
        }

        public IEnumerable<OrderEntity?> GetUserOrders(int userId)
        {
            return _orderService.GetAllOrders().Where(order => order.UserId == userId);
        }
    }
}
