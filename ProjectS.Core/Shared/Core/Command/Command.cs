using Flunt.Notifications;
using Standard.Core.Shared.Core.Command;

namespace ProjectS.Core.Shared.Core.Command;

public abstract class Command<T> : Notifiable<Notification>, ICommand, IMap<T>
{
	public abstract T Convert();

	public abstract void Validate();
}
