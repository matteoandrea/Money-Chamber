using MediatR;
using ProjectS.Core.Models;

namespace ProjectS.Core.Events.Users;

public class UserCreatedFailEvent : INotification
{
	public UserCreatedFailEvent(Guid userId)
	{
		UserId = userId;
	}

	public Guid UserId { get; init; }
}
