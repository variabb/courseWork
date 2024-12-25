using OrderEntityNamespace;

namespace IOrderProductServiceNamespace
{
    public interface IOrderProductService
    {
        bool PurchaseProduct(int userId, int productId); //* Купівля товару користувачем
        IEnumerable<OrderEntity?> GetUserOrders(int userId); //* Перегляд історії покупок користувача
    }
}