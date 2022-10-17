using Command.Document;

namespace Command.Command;

public class InsertImageCommand : ICommand
{
    private readonly IDocument _doc;
    private string _path;
    private uint? _pos;
    private int _w;
    private int _h;

    public InsertImageCommand(IDocument doc, string path, uint? pos, int w, int h)
    {
        _doc = doc;
        _path = path;
        _pos = pos;
        _w = w;
        _h = h;
    }

    public void Execute()
    {
        _doc.InsertImage(_path, _w, _h, _pos);
        if (_pos == null)
        {
            _pos = _doc.ItemCount - 1;
        }
    }

    public void Unexecute()
    {
        _doc.DeleteItem(_pos!.Value);
    }
    public void Dispose()
    {
    }
}
