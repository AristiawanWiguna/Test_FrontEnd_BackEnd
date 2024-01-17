namespace TestMcfAPI
{
    public class User
    {
        public string user_name { get; set; } = string.Empty;

        public byte[] PasswordHash { get; set; }

        public byte[] PasswordSalt { get; set; }
    }
}
