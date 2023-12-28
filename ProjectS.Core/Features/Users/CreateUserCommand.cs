using Flunt.Notifications;
using Flunt.Validations;
using Standard.Core.Shared.Core.Command;
using Standard.Core.Shared.ValueObjects;

namespace Standard.Core.Features.Users;

public class CreateUserCommand(Name name, Email email) : Notifiable<Notification>, ICommand
{
	public Name Name { get; private set; } = name;
	public Email Email { get; private set; } = email;

	public void Validate()
	{
		AddNotifications(Name, Email);
	}
}
