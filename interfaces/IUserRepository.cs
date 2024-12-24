using UserEntityNamespace;

namespace IUserRepositoryNamespace
{
    public interface IUserRepository
    {
        int Create(UserEntity account); //* Створює нового користувача. Параметр account — це об'єкт типу UserEntity, який містить інформацію про користувача
        IEnumerable<UserEntity?> GetAll(); //* Повертає всіх користувачів
        UserEntity? Read(int UserId); //* Повертає інформацію про конкретного користувача за його унікальним ідентифікатором UserId
        void Update(UserEntity account); //* Оновлює дані користувача. Параметр account — це об'єкт UserEntity, що містить нові дані для користувача.
        void Delete(int UserId); //* Видаляє користувача за його ідентифікатором UserId.
        bool IsUserExistById(int UserId); //* Перевіряє, чи існує користувач з вказаним UserId. Повертає true, якщо користувач існує, і false, якщо ні.
    }
}