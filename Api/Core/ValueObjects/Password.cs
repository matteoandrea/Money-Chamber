using ProjectS.Core.Core.Objects;
using System.Security.Cryptography;

namespace ProjectS.Core.Shared.ValueObjects;

public class Password : ValueObject
{

	#region Constructors
	public Password(string? text = null)
	{
		if (string.IsNullOrEmpty(text) || string.IsNullOrWhiteSpace(text))
			text = Generate();

		Hash = HashPassword(text);
		ResetCode = Guid.NewGuid().ToString("N")[..8].ToUpper();
	}

	#endregion

	#region Propreties

	private readonly string _validChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
	private readonly string _specialChars = "!@#$%ˆ&*(){}[];";

	public string Hash { get; init; }
	public string ResetCode { get; init; }


	#endregion

	#region Functions

	public bool Verify(string passwordToCheck)
	{
		var parts = Hash.Split('.');
		if (parts.Length != 3)
			return false;

		var iterations = int.Parse(parts[0]);
		var salt = Convert.FromBase64String(parts[1]);
		var key = Convert.FromBase64String(parts[2]);

		using Rfc2898DeriveBytes algorithm = new(passwordToCheck, salt, iterations, HashAlgorithmName.SHA256);
		byte[] keyToCheck = algorithm.GetBytes(key.Length);

		return keyToCheck.SequenceEqual(key);
	}


	private string Generate(short length = 16, bool includeSpecialChars = true, bool upperCase = false)
	{
		string chars = _validChars + (includeSpecialChars ? _specialChars : "");
		Random random = new();
		string password = new(Enumerable.Repeat(chars, length)
		  .Select(x => x[random.Next(x.Length)]).ToArray());

		return upperCase ? password.ToUpper() : password;
	}

	private string HashPassword(string password, int saltSize = 16, int keySize = 32, int iterations = 10000)
	{
		if (string.IsNullOrEmpty(password))
			throw new ArgumentNullException(nameof(password), "Password should not be null or empty");

		byte[] salt = GenerateSalt(saltSize);
		using Rfc2898DeriveBytes algorithm = new(password, salt, iterations, HashAlgorithmName.SHA256);
		string key = Convert.ToBase64String(algorithm.GetBytes(keySize));

		return $"{iterations}.{Convert.ToBase64String(salt)}.{key}";
	}

	private byte[] GenerateSalt(int saltSize)
	{
		byte[] salt = new byte[saltSize];
		using (var rng = RandomNumberGenerator.Create())
		{
			rng.GetBytes(salt);
		}
		return salt;
	}



	#endregion
}
