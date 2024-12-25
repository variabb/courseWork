namespace IAuthenticationServiceNamespace
{
    public interface IAuthenticationService
    {
        bool Register(string username, string password); //* Реєстрація нового користувача
        bool Login(string username, string password); //* Вхід в систему для існуючого користувача
        bool UserExistsByUsername(string username); //* Перевірка існування користувача
    }
}