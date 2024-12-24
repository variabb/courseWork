//?  Модель для збереження інформації про замовлення

namespace OrderEntity{
public class OrderEntity {
    public int Id { get; set; } // ID замовлення
    public int UserId { get; set; } // ID користувача
    public List<int> ProductIds { get; set; } = new List<int>(); // список товарів
    public decimal TotalAmount { get; set; } // сума
}
}