using Core.Core;
using Core.ValueObjects;
using ProjectS.Core.Shared.ValueObjects;

namespace Core.HttpsRequest.Users;

public class PostCreateUser(FullName name,
						Email email,
						PasswordRequest password) : Command
{
	public FullName Name { get; init; } = name;
	public Email Email { get; init; } = email;
	public PasswordRequest Password { get; init; } = password;

	public override void Validate()
	{
		AddNotifications(Name, Email, Password);
	}
}

