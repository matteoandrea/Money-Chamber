using Flunt.Notifications;
using MediatR;

namespace ProjectS.Core.Core.Command;

public abstract class Command<T> : Notifiable<Notification>, ICommand, IMap<T>
{
	public abstract T Convert();

	public abstract void Validate();
}
