using MediatR;
using ProjectS.Core.Events.Users;
using ProjectS.Core.Repositories;

namespace ProjectS.Core.Handlers.Users;

public class UserCreatedEventFailHandler : INotificationHandler<UserCreatedFailEvent>
{
	#region Contructors

	public UserCreatedEventFailHandler(IUserRepository repository)
	{
		_repository = repository;
	}

	#endregion

	#region Propreties

	private readonly IUserRepository _repository;

	#endregion

	#region Functions

	public async Task Handle(UserCreatedFailEvent notification, CancellationToken cancellationToken)
	{
		await _repository.DeleteAsync(notification.UserId);
	}

	#endregion
}
