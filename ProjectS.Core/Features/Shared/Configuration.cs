namespace ProjectS.Core.Features.Shared;

public static class Configuration
{
	public static SecretConfiguration Secrets { get; } = new();


	public class SecretConfiguration
	{
		public string ApiKey { get; } = string.Empty;
		public string JwtPrivateKey { get; } = string.Empty;
		public string PasswordSaltKey { get; } = string.Empty;
	}
}
