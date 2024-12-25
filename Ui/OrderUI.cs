using IOrderProductServiceNamespace;

public static class OrderUI
{
    public static void ViewOrderHistory(int userId, IOrderProductService orderProductService)
    {
        var orders = orderProductService.GetUserOrders(userId);
        Console.Clear();
        Console.WriteLine("Історія замовлень:");

        foreach (var order in orders)
        {
            Console.WriteLine($"Замовлення ID: {order.OrderId}, Загальна сума: {order.TotalAmount}");
            foreach (var product in order.Products)
            {
                Console.WriteLine($"Продукт: {product.ProductName}, Ціна: {product.Price}");
            }
        }

        Console.WriteLine("Натисніть Enter, щоб повернутися в меню.");
        Console.ReadLine();
    }
}
