using Command.Document;
using Command.Document.Item.Image;

namespace Command.Command;

public class ResizeImageCommand : ICommand
{
    private readonly IDocument _doc;
    private uint _pos;
    private int _w;
    private int _h;
    private int _prevW;
    private int _prevH;

    public ResizeImageCommand(IDocument doc, uint pos, int w, int h)
    {
        _doc = doc;
        _pos = pos;
        _w = w;
        _h = h;
    }

    public void Execute()
    {
        if (_doc.GetItem(_pos) is not IImage image)
        {
            throw new ApplicationException("Incorrect item type.");
        }
        _prevW = image.Width;
        _prevH = image.Height;
        image.Resize(_w, _h);
        _doc.History.Add(this);
    }

    public void Unexecute()
    {
        IImage image = (_doc.GetItem(_pos) as IImage)!;
        image.Resize(_prevW, _prevH);
    }

    public void Dispose()
    {
    }
}
