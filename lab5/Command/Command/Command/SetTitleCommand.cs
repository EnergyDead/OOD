using Command.Document;

namespace Command.Command;

public class SetTitleCommand : ICommand
{
    readonly IDocument _doc;
    readonly string _title;
    string _prevTitle;

    public SetTitleCommand(IDocument doc, string title)
    {
        _doc = doc;
        _title = title;
        _prevTitle = doc.Title;
    }

    public void Execute()
    {
        _prevTitle = _doc.Title;
        _doc.Title = _title;
    }

    public void Unexecute()
    {
        _doc.Title = _prevTitle;
    }

    public void Dispose()
    {
    }
}
