using Core.Core;
using ProjectS.Core.Models;
using ProjectS.Core.Shared.ValueObjects;

namespace Core.HttpsRequest.Users;

public class CreateUser(FullName name, Email email) : Command<User>
{
	public FullName Name { get; init; } = name;
	public Email Email { get; init; } = email;

	public override User Convert()
	{
		return new(Name, Email, []);
	}

	public override void Validate()
	{
		AddNotifications(Name, Email);
	}
}
