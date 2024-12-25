namespace Core
{
    public static class Session
    {
        public static int? UserId { get; set; } = null;
        public static string? Username { get; set; } = null;

        public static void Clear()
        {
            UserId = null;
            Username = null;
        }
    }
}
