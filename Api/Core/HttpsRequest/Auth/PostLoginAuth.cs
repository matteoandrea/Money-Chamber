using Core.Core;
using Core.ValueObjects;
using ProjectS.Core.Shared.ValueObjects;

namespace Core.HttpsRequest.Auth;

public class PostLoginAuth(Email emailAdress, PasswordRequest password) : Command
{
	public Email EmailAdress { get; init; } = emailAdress;
	public PasswordRequest Password { get; init; } = password;

	public override void Validate()
	{
		AddNotifications(EmailAdress, Password);
	}
}
