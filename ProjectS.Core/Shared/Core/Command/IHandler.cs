namespace Standard.Core.Shared.Core.Command;

public interface IHandler<T> where T : ICommand
{
    ICommandResult Handler(T command);
}
