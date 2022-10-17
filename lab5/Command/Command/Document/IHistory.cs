using Command.Command;

namespace Command.Document;

public interface IHistory
{
    bool CanUndo { get; }
    bool CanRedo { get; }
    void Undo();
    void Redo();
    void Add(ICommand command);
}
