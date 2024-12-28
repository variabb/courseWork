namespace Core
{
    public  class Session
    {
        public  int? UserId { get; set; } = null;
        public  string? Username { get; set; } = null;

        public  void Clear()
        {
            UserId = null;
            Username = null;
        }
    }
}
