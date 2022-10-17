using Command.Document;
using Command.Document.Item.Paragraph;

namespace Command.Command;

public class ReplaceTextCommand : ICommand
{
    private readonly IDocument _doc;
    private readonly uint _pos;
    private string _text;
    private string? _prevText;

    public ReplaceTextCommand(IDocument doc, uint pos, string text)
    {
        _doc = doc;
        _pos = pos;
        _text = text;
    }

    public void Execute()
    {
        if (_doc.GetItem(_pos) is not IParagraph paragraph)
        {
            throw new ApplicationException("Incorrect item type.");
        }
        _prevText = paragraph.Text;
        paragraph.Text = _text;
        _doc.History.Add(this);
    }

    public void Unexecute()
    {
        IParagraph paragraph = (_doc.GetItem(_pos) as IParagraph)!;
        paragraph.Text = _prevText!;
    }

    public void Dispose()
    {
}
}
