using IUserServiceNamespace;
using UserEntityNamespace;
using IAuthenticationServiceNamespace;

namespace AuthentificationServiceNamespace
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IUserService _userService;

        // Конструктор для ініціалізації залежностей
        public AuthenticationService(IUserService userService)
        {
            _userService = userService;
        }

        // Метод для реєстрації нового користувача
        public bool Register(string username, string password)
        {
            // Перевірка, чи існує користувач з таким ім'ям
            if (_userService.GetByUsername(username) != null)
            {
                return false; // Користувач вже існує
            }

            // Створення нового користувача
            var user = new UserEntity
            {
                Username = username,
                Password = password,
                Balance = 0 // Початковий баланс
            };

            // Додавання користувача через сервіс
            int userId = _userService.Create(user);
            return userId > 0; // Повертає true, якщо створення успішне
        }

        // Метод для входу в систему
        public bool Login(string username, string password)
        {
            // Отримання користувача за іменем
            var user = _userService.GetByUsername(username);
            if (user == null || user.Password != password)
            {
                return false; // Невірний логін або пароль
            }

            return true; // Вхід успішний
        }
         public bool UserExistsByUsername(string username)
        {
            return _userService.GetByUsername(username) != null;
        }
    }
}
