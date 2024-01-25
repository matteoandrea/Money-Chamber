namespace Standard.Core.Shared.Core.Command;

public interface IHandler<T> where T : ICommand
{
	Task<ICommandResult> Handler(T command);
}
