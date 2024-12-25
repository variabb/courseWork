using OrderEntityNamespace;
using IOrderRepositoryNamespace;
using dataBase;


namespace OrderRepositoryNamespace
{
    public class OrderRepository : IOrderEntity
    {
         private DbContext _dbContext; 

        public OrderRepository(DbContext dbContext)
        {
            _dbContext = dbContext; 
        }

        public int Create(OrderEntity order)
        {
            order.OrderId = _dbContext.Orders.Count;
            _dbContext.Orders.Add(order);
            return order.OrderId; // Повертаємо ID нового користувача
        }


      
        public IEnumerable<OrderEntity?> GetAll()
        {
            return _dbContext.Orders!;
        }


       
        public OrderEntity? Read(int orderId)
        {
          return _dbContext.Orders.FirstOrDefault(ord => ord?.OrderId == orderId);
        }

        public void Update(OrderEntity order)
        {

            if (IsOrderExistById(order.OrderId)) {
                _dbContext.Orders[order.OrderId] = order; // Оновлюємо товар
            }
        }

     public void Delete(int orderId)
        {
            var order = Read(orderId);
            if(IsOrderExistById(orderId)){
                 _dbContext.Orders.Remove(order);
            }
        }

     
       
        public bool IsOrderExistById(int orderId)
        {
            return _dbContext.Orders.Any(ord => ord?.OrderId == orderId); //* != null ? true : false; Перевіряє, чи є елемент із заданим ID
        }
    }
}
