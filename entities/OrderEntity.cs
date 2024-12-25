//?  Модель для збереження інформації про замовлення
using ProductEntityNamespace;
using UserEntityNamespace;

namespace OrderEntityNamespace{
public class OrderEntity {
    public int OrderId { get; set; } // ID замовлення
    public int UserId { get; set; } // ID користувача
    public List<ProductEntity> Products { get; set; } = new List<ProductEntity>(); // список товарів
    public int Quantity { get; set; }
 
    public decimal TotalAmount { get; set; } // сума
}
}