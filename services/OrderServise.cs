using OrderEntityNamespace;
using IOrderRepositoryNamespace;
using IOrderServiceNamespace;

namespace OrderServiceNamespace
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        // Конструктор для ініціалізації залежності
        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        // Отримати всі замовлення
        public IEnumerable<OrderEntity?> GetAllOrders()
        {
            return _orderRepository.GetAll();
        }

        // Отримати конкретне замовлення за його унікальним ідентифікатором
        public OrderEntity? GetOrderById(int orderId)
        {
            return _orderRepository.Read(orderId);
        }

        // Створити нове замовлення
        public int CreateOrder(OrderEntity order)
        {
            return _orderRepository.Create(order);
        }

        // Оновити замовлення
        public void UpdateOrder(OrderEntity order)
        {
            _orderRepository.Update(order);
        }

        // Видалити замовлення за його ідентифікатором
        public void DeleteOrder(int orderId)
        {
            _orderRepository.Delete(orderId);
        }
    }
}
