using Command.Command;

namespace Command.Document;

public class History : IHistory
{
    const int _maxCommandsQuantity = 10;
    private readonly List<ICommand> _commands = new();
    private readonly List<ICommand> _cancelledCommands = new();
    private bool _isLocked = false;

    public bool CanUndo => _commands.Any();
    public bool CanRedo => _cancelledCommands.Any();

    public virtual void Add(ICommand command)
    {
        if (_isLocked)
        {
            return;
        }

        RemoveOldHistory();
        _commands.Add(command);
        RemoveOverrideCommand();
    }

    public virtual void Redo()
    {
        if (!CanRedo)
        {
            throw new ApplicationException("Redo can not be executed");
        }
        ICommand command = _cancelledCommands.Last();
        _isLocked = true;
        command.Execute();
        _isLocked = false;

        _cancelledCommands.RemoveLast();
        _commands.Add(command);
    }

    public virtual void Undo()
    {
        if (!CanUndo)
        {
            throw new ApplicationException("Undo can not be executed");
        }
        ICommand command = _commands.Last();
        _isLocked = true;
        command.Unexecute();
        _isLocked = false;

        _commands.RemoveLast();
        _cancelledCommands.Add(command);
    }

    private void RemoveOldHistory()
    {
        while (_cancelledCommands.Count > 0)
        {
            _cancelledCommands[^1].Dispose();
            _cancelledCommands.RemoveLast();
        }
    }

    private void RemoveOverrideCommand()
    {
        while (_commands.Count > _maxCommandsQuantity)
        {
            _commands[0].Dispose();
            _commands.RemoveAt(0);
        }
    }
}

static class Util
{
    internal static void RemoveLast(this List<ICommand> commands)
    {
        commands.RemoveAt(commands.Count - 1);
    }
}
