namespace Composite.Command;

public class CommandManager
{
    private readonly Stack<ICommand> _commands = new();

    public void ExecuteCommand(ICommand command)
    {
        command.Execute();
        _commands.Push(command);
    }

    public void UndoLastCommand()
    {
        if (_commands.Count <= 0) return;
        var command = _commands.Pop();
        command.Undo();
    }
}