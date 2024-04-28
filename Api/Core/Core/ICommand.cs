using Flunt.Notifications;
using MassTransit.Mediator;

namespace Core.Core;

public interface IMap<T> { T Convert(); }

public interface ICommandResult { }

public interface IHttpsRequest : Request<GenericCommandResult> { }

public interface ICommand : IHttpsRequest { void Validate(); }


public abstract class Command<T> : Notifiable<Notification>, ICommand, IMap<T>
{
	public abstract T Convert();

	public abstract void Validate();
}

public abstract class Command : Notifiable<Notification>, ICommand
{

	public abstract void Validate();
}

public record GenericCommandResult(string Message, int Status, object? Data = null, IEnumerable<Notification>? Notifications = null) : ICommandResult
{
	public bool Success => Status >= 200 && Status <= 299;
}