using OrderEntityNamespace;
using UserEntityNamespace;
namespace IUserServiceNamespace
{
    public interface IUserService
    {
        int Create(UserEntity user); //* Створення нового користувача
        UserEntity? Get(int userId); //* Отримання користувача за ID
        UserEntity? GetByUsername(string username); //* Отримання користувача за ім'ям користувача
        void Update(UserEntity user); //* Оновлення даних користувача
        void Delete(int userId); //* Видалення користувача
        bool IsUserExistById(int userId); //* Перевірка існування користувача за ID
        decimal GetBalance(int userId); //* метод для отримання балансу
        void UpdateBalance(int userId, decimal amount); //* Оновлення балансу користувача
    }
}

