namespace API.Settings
{
    public class DatabaseSettings
    {
        public string ConnectionString { get; set; }
        public string Server { get; set; }
        public string Database { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string AdminDatabase { get; set; }
        public bool UseSSL { get; set; }
    }
}
