using ProjectS.Core.Core.Command;
using ProjectS.Core.Models;
using ProjectS.Core.Shared.ValueObjects;

namespace ProjectS.Core.Requests;

public class CreateUserRequest : Command<User>
{
	public CreateUserRequest() { }

	public CreateUserRequest(FullName name, Email email)
	{
		Name = name;
		Email = email;
	}

	public FullName Name { get; init; }
	public Email Email { get; init; }

	public override User Convert()
	{
		return new(Name, Email, []);
	}

	public override void Validate()
	{
		AddNotifications(Name, Email);
	}
}
