//?  Модель для збереження інформації про товари

namespace ProductEntityNamespace
{
    public class ProductEntity
    {
        public int ProductId { get; set; } // id продукту
        public string ProductName { get; set; } // назва продукту
        public decimal Price { get; set; } // ціна
        public int Quantity { get; set; } // доступна кількість
    }
}