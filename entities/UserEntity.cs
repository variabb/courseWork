//? Модель для збереження інформації про користувачів
namespace UserEntityNamespace{
public class UserEntity {
    public int UserId { get; set; } // id користувача
    public string Username { get; set; } // ім'я користувача
       public string Password { get; set; } // пароль
    public decimal Balance { get; set; } // баланс
}
}