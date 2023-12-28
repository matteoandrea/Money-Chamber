using Flunt.Notifications;
using Standard.Core.Shared.Core.Command;

namespace Standard.Core.Features.Users;

public class UserHandler : Notifiable<Notification>, IHandler<CreateUserCommand>
{
	public UserHandler(IUserRepository userRepository)
	{
		_userRepository = userRepository;
	}

	private readonly IUserRepository _userRepository;

	public ICommandResult Handler(CreateUserCommand command)
	{
		command.Validate();
		if (!command.IsValid)
			return new GenericCommandResult(false, "Invalid User", command.Notifications);

		User user = new(command.Name, command.Email);
		_userRepository.SaveAsync(user);

		return new GenericCommandResult(true, $"User {user.Id} successfully created", user);
	}
}
