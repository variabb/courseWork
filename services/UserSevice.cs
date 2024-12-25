using IUserRepositoryNamespace;
using IUserServiceNamespace;
using UserEntityNamespace;
namespace UserServiceNamespace
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public int Create(UserEntity user)
        {
            return _userRepository.Create(user);
        }

        public UserEntity? Get(int userId)
        {
            return _userRepository.Read(userId);
        }

        public UserEntity? GetByUsername(string username)
        {
            return _userRepository.GetAll().FirstOrDefault(u => u.Username == username);
        }

        public void Update(UserEntity user)
        {
            _userRepository.Update(user);
        }

        public void Delete(int userId)
        {
            _userRepository.Delete(userId);
        }

        public bool IsUserExistById(int userId)
        {
            return _userRepository.IsUserExistById(userId);
        }
       public decimal GetBalance(int userId)
        {
            var user = _userRepository.Read(userId);
            return user?.Balance ?? 0; // Якщо користувача немає, повертаємо 0
        }
         public void UpdateBalance(int userId, decimal amount)
        {
            var user = _userRepository.Read(userId);
            if (user != null)
            {
                user.Balance += amount;
                _userRepository.Update(user);
            }
        }
    }
}
