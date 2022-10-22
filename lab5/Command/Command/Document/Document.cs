using Command.Command;
using Command.Document.Item;
using Command.Document.Item.Image;
using Command.Document.Item.Paragraph;
using System.Text;
using System.Web;

namespace Command.Document;

public class Document : IDocument
{
    private readonly List<IItem> _items = new();
    private string _title = "Title";
    public string Title
    {
        get => _title;
        set => SetTitle(value);
    }

    public bool CanUndo => History.CanUndo;
    public bool CanRedo => History.CanRedo;
    public uint ItemCount => (uint)_items.Count;

    public IHistory History { get; }

    public Document(IHistory history)
    {
        History = history;
    }


    public void DeleteItem(uint index)
    {
        if (index >= _items.Count)
        {
            throw new ApplicationException($"Can not find to delete item in {index} position.");
        }
        _items.RemoveAt((int)index);

        ICommand command = new DeleteItemCommand(this, index);
        History.Add(command);
    }

    public IItem GetItem(uint index)
    {
        if (index >= _items.Count)
        {
            throw new ApplicationException($"Can not find item in {index} position.");
        }
        return _items[(int)index];
    }

    public void InsertImage(string path, int width, int height, uint? pos = null)
    {
        if (pos == null)
        {
            pos = ItemCount;
        }

        string tempFileName = Path.GetTempFileName();
        try
        {
            File.Copy(path, tempFileName, true);
        }
        catch (Exception ex)
        {
            throw new ApplicationException($"File {path} copying is not possible. {ex.Message}");
        }

        IImage image = new Image(tempFileName, Path.GetExtension(path), width, height);
        _items.Insert((int)pos, image);

        ICommand command = new InsertImageCommand(this, path, pos, width, height);
        History.Add(command);
    }

    public void InsertParagraph(string text, uint? pos = null)
    {
        if (pos == null)
        {
            pos = ItemCount;
        }

        IParagraph paragraph = new Paragraph(text);
        _items.Insert((int)pos, paragraph);

        ICommand command = new InsertParagraphCommand(this, pos, text);
        History.Add(command);
    }

    public void Redo()
    {
        History.Redo();
    }

    public void Save(string path)
    {
        path = path.Replace('\\', '/');
        if (!path.Contains('/'))
        {
            path = $"temp\\{path}";
        }
        StringBuilder stringBuilder = new();
        stringBuilder.Append("<!DOCTYPE html>")
            .Append("<html>")
            .Append($"<head><meta charset=\"utf-8\"><title>{HttpUtility.HtmlDecode(Title)}</title></head>")
            .Append("<body>");

        foreach (var item in _items)
        {
            stringBuilder.Append(item.ToHtml(path));
        }

        stringBuilder.Append("</body>")
            .Append("</html>");

        try
        {
            using (var sw = new StreamWriter(path))
            {
                sw.Write(stringBuilder.ToString());
            }
        }
        catch (Exception ex)
        {
            throw new ApplicationException(ex.Message);
        }
    }

    public void Undo()
    {
        History.Undo();
    }

    private void SetTitle(string value)
    {
        _title = value;

        ICommand command = new SetTitleCommand(this, value);
        History.Add(command);
    }
}
