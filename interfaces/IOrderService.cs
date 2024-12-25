using OrderEntityNamespace;
using IOrderRepositoryNamespace;
namespace IOrderServiceNamespace
{
    public interface IOrderService
    {
        // Отримати всі замовлення
        IEnumerable<OrderEntity?> GetAllOrders();

        // Отримати конкретне замовлення за його унікальним ідентифікатором
        OrderEntity? GetOrderById(int orderId);

        // Створити нове замовлення
        int CreateOrder(OrderEntity order);

        // Оновити замовлення
        void UpdateOrder(OrderEntity order);

        // Видалити замовлення за його ідентифікатором
        void DeleteOrder(int orderId);
    }
}
