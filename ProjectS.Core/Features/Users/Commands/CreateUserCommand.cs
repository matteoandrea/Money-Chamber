using ProjectS.Core.Features.Accounts.Core;
using ProjectS.Core.Features.Users.Core;
using ProjectS.Core.Shared.Core.Command;
using Standard.Core.Shared.ValueObjects;

namespace ProjectS.Core.Features.Users.Commands;

public class CreateUserCommand : Command<User>
{
	public CreateUserCommand(FullName name, Email email)
	{
		Name = name;
		Email = email;

		Account = new(
			new Name("New Account"),
			new Description("Here goes a description"),
			0);
	}

	public FullName Name { get; init; }
	public Email Email { get; init; }
	public Account Account { get; init; }

	public override User Convert()
	{
		return new(Name, Email, Account);
	}

	public override void Validate()
	{
		AddNotifications(Name, Email, Account);
	}
}
