using Flunt.Notifications;

namespace Standard.Core.Shared.Core.Command;

public class GenericCommandResult(string message, int status, object? data = null, IEnumerable<Notification>? notifications = null) : ICommandResult
{
	public string Message { get; init; } = message;
	public int Status { get; init; } = status;
	public bool Success => Status is >= 200 and <= 299;
	public object? Data { get; init; } = data;
	public IEnumerable<Notification>? Notifications { get; init; } = notifications;

}
