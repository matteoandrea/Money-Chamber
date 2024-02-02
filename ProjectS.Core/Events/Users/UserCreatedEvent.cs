using MediatR;

namespace ProjectS.Core.Events.Users;

public class UserCreatedEvent : INotification
{
	public UserCreatedEvent(Guid userId)
	{
		UserId = userId;
	}

	public Guid UserId { get; init; }
}
