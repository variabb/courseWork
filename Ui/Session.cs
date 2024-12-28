namespace Core
{
    public  class Session
    {
        public  int? UserId { get; set; } = null;
        public  string? Username { get; set; } = null;
// Метод для очищення сесії
        public  void Clear()
        {
            UserId = null;
            Username = null;
        }
    }
}
