using Command.Document;

namespace Command.Command;

public class InsertParagraphCommand : ICommand
{
    private readonly IDocument _doc;
    private uint? _position;
    private string _text;

    public InsertParagraphCommand(IDocument doc, uint? pos, string text)
    {
        _doc = doc;
        _position = pos;
        _text = text;
    }

    public void Execute()
    {
        _doc.InsertParagraph(_text, _position);
        if (_position == null)
        {
            _position = _doc.ItemCount - 1;
        }
    }

    public void Unexecute()
    {
        _doc.DeleteItem(_position!.Value);
    }

    public void Dispose()
    {
    }
}
