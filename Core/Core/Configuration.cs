namespace ProjectS.Core.Core;

public static class Configuration
{
    public static SecretConfiguration Secrets { get; } = new();
    public static DatabaseConfiguration Database { get; } = new();

    public class DatabaseConfiguration
    {
        public string ConnectionString { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;

    }

    public class SecretConfiguration
    {
        public string ApiKey { get; set; } = string.Empty;
        public string JwtPrivateKey { get; set; } = string.Empty;
        public string PasswordSaltKey { get; set; } = string.Empty;
    }
}
