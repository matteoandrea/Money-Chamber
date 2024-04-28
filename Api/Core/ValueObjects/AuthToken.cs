using Core.Auth;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using ProjectS.Core.Core.Objects;
using ProjectS.Core.Shared.ValueObjects;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Core.ValueObjects;

public class AuthToken : ValueObject
{
	#region Constructors

	public AuthToken(string emailAddress, IOptions<AuthSettings> _options)
	{
		_key = _options.Value.SecretKey;
		Token = Authenticate(emailAddress);
		RefreshToken = Guid.NewGuid().ToString();

	}

	#endregion

	#region Propreties

	private readonly string _key;

	public string Token { get; init; }
	public string RefreshToken { get; init; }

	#endregion

	#region Functions

	private string Authenticate(string email)
	{
		byte[] key = Encoding.ASCII.GetBytes(_key);

		SigningCredentials credentials = new(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256);

		SecurityTokenDescriptor tokenDescriptor = new()
		{
			SigningCredentials = credentials,
			Expires = DateTime.UtcNow.AddHours(2),
			Subject = new ClaimsIdentity(new Claim[]
			{
				new(ClaimTypes.Email, email)
			}),
		};

		JwtSecurityTokenHandler handler = new();
		SecurityToken token = handler.CreateToken(tokenDescriptor);
		return handler.WriteToken(token);
	}

	//public string RefreshAccessToken(s)
	//{
	//	var tokenValidationParameters = new TokenValidationParameters
	//	{
	//		ValidateIssuerSigningKey = true,
	//		IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_key)),
	//		ValidateIssuer = false,
	//		ValidateAudience = false,
	//		ValidateLifetime = false
	//	};

	//	SecurityToken validatedToken;
	//	ClaimsPrincipal principal;
	//	try
	//	{
	//		JwtSecurityTokenHandler handler = new();
	//		principal = handler.ValidateToken(refreshToken, tokenValidationParameters, out validatedToken);
	//	}
	//	catch (Exception)
	//	{
	//		return null;
	//	}

	//	var expiryUnixTimestamp = principal.FindFirst(ClaimTypes.Expiration)?.Value;
	//	if (string.IsNullOrEmpty(expiryUnixTimestamp) || !long.TryParse(expiryUnixTimestamp, out long expiryTime))
	//	{
	//		// Expiry claim not found or invalid
	//		return null;
	//	}

	//	// Check if the refresh token has expired
	//	if (DateTime.UtcNow > DateTimeOffset.FromUnixTimeSeconds(expiryTime).UtcDateTime)
	//	{
	//		// Refresh token has expired
	//		return null;
	//	}

	//	// Generate new access token
	//	var username = principal.FindFirst(ClaimTypes.Name)?.Value;
	//	var user = new User { Username = username }; // Fetch user details from database or other source if necessary
	//	return GenerateToken(user);


	//}

	#endregion

}
