namespace Command.Command;

public interface ICommand : IDisposable
{
    void Execute();
    void Unexecute();
}
