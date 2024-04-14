using Flunt.Validations;
using ProjectS.Core.Core.Objects;
using ProjectS.Core.Shared.ValueObjects;

namespace Core.ValueObjects;

public class PasswordRequest : ValueObject
{
	public PasswordRequest() { }

	public PasswordRequest(string password)
	{
		Password = password;
		AddNotifications(new PasswordRequestValidationContract(this));
	}

	public string Password { get; init; }
}

public class PasswordRequestValidationContract : Contract<PasswordRequest>
{
	public PasswordRequestValidationContract(PasswordRequest password)
	{
		Requires()
			.IsNotNullOrEmpty(password.Password, "EmptyPassword", "Invalid password")
			.IsGreaterThan(password.Password, 3, "ShortPassword", "Password too short");
	}
}