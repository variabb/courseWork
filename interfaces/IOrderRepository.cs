using  OrderEntityNamespace;

namespace IOrderRepositoryNamespace
{
    public interface IOrderRepository
    {
        int Create(OrderEntity account); //* Створює нове замовлення. account — це об'єкт типу OrderEntity
        IEnumerable<OrderEntity?> GetAll(); //* Метод повертає колекцію об'єктів типу OrderEntity, що дозволяє отримати список усіх продуктів.
        OrderEntity? Read(int OrderId); //* Повертає замовлення за його унікальним ідентифікатором OrderId
        void Update(OrderEntity account); //* Оновлює існуюче замовлення. Параметр account — це об'єкт OrderEntity з новими даними для замовлення.
        void Delete(int OrderId); //* Видаляє замовлення за його унікальним ідентифікатором OrderId.
        bool IsOrderExistById(int OrderId); //* Перевіряє, чи існує замовлення з вказаним OrderId. Повертає true, якщо замовлення існує, і false, якщо ні.
    }
}