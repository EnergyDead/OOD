using Command.Document;
using Command.Document.Item;
using Command.Document.Item.Image;
using Command.Document.Item.Paragraph;

namespace Command.Command;

public class DeleteItemCommand : ICommand
{
    private readonly IDocument _doc;
    private readonly uint _pos;
    IItem? _deletedItem;

    public DeleteItemCommand(IDocument doc, uint pos)
    {
        _doc = doc;
        _pos = pos;
    }

    public void Execute()
    {
        _deletedItem = _doc.GetItem(_pos);
        _doc.DeleteItem(_pos);
    }

    public void Unexecute()
    {
        if (_deletedItem is IParagraph paragraph)
        {
            _doc.InsertParagraph(paragraph.Text, _pos);
        }
        else if (_deletedItem is IImage image)
        {
            _doc.InsertImage(image.Path, image.Width, image.Height, _pos);
        }
        else
        {
            throw new InvalidOperationException();
        }
    }

    public void Dispose()
    {
    }
}
