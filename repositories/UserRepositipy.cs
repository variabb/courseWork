using UserEntityNamespace;
using IUserRepositoryNamespace;
using dataBase;

namespace UserRepositoryNamespace
{
    public class UserRepository : IUserRepository
    {
        private DbContext _dbContext; 

        public UserRepository(DbContext dbContext)
        {
            _dbContext = dbContext; 
        }

        public int Create(UserEntity user)
        {
            user.UserId = _dbContext.Users.Count;
            _dbContext.Users.Add(user);
            return user.UserId; // Повертаємо ID нового користувача
        }

        public IEnumerable<UserEntity?> GetAll()
        {
            return _dbContext.Users!;
        }

        public UserEntity? Read(int userId)
        {
            return _dbContext.Users.FirstOrDefault(user => user?.UserId == userId);
        }

        public void Update(UserEntity user)
        {

            if (IsUserExistById(user.UserId)) {
                _dbContext.Users[user.UserId] = user; // Оновлюємо дані користувача
            }
        }
    
        

        public void Delete(int userId)
        {
             var user = Read(userId);
            if(IsUserExistById(userId)){
                 _dbContext.Users.Remove(user);
            }
        }

        public bool IsUserExistById(int userId)
        {
            return _dbContext.Users.Any(user => user?.UserId == userId); // Перевіряє, чи є елемент із заданим ID
        }
    }
}
