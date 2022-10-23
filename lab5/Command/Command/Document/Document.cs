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
    private string _title = string.Empty;
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

        IImage image = CreateImage(path, width, height);
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

    public void Undo()
    {
        History.Undo();
    }

    public void Save(string path)
    {
        ToCorrectPath(ref path);
        string html = GenerateHtml(path);
        SaveFile(html, path);
    }

    private static IImage CreateImage(string path, int width, int height)
    {
        string tempFileName = Path.GetTempFileName();
        try
        {
            File.Copy(path, tempFileName, true);
        }
        catch (Exception ex)
        {
            throw new ApplicationException($"File {path} copying is not possible. {ex.Message}");
        }

        return new Image(tempFileName, Path.GetExtension(path), width, height);
    }

    private static void SaveFile(string value, string path)
    {
        try
        {
            using (var sw = new StreamWriter(path))
            {
                sw.Write(value);
            }
        }
        catch (Exception ex)
        {
            throw new ApplicationException(ex.Message);
        }
    }

    private string GenerateHtml(string path)
    {
        StringBuilder stringBuilder = new();
        stringBuilder.Append("<!DOCTYPE html>")
            .Append("<html>")
            .Append($"<head><meta charset=\"utf-8\"><title>{HttpUtility.HtmlDecode(Title)}</title></head>")
            .Append("<body>");

        foreach (var item in _items)
        {
            if (item is IImage image)
            {
                string newPath = image.CopyTo(path);
                stringBuilder.Append(item.ToHtml(newPath));
            }
            else
            {
                stringBuilder.Append(item.ToHtml());
            }

        }

        stringBuilder.Append("</body>")
            .Append("</html>");

        return stringBuilder.ToString();
    }

    private static void ToCorrectPath(ref string path)
    {
        path = path.Replace('\\', '/');
        if (!path.Contains('/'))
        {
            Directory.CreateDirectory("temp");
            path = $"temp/{path}";
        }
    }

    private void SetTitle(string value)
    {
        ICommand command = new SetTitleCommand(this, value);
        History.Add(command);

        _title = value;
    }
}

static class DocumentUtil
{
    const string _referencePath = "images/";

    internal static string CopyTo(this IImage image, string from)
    {
        string fullPath = Path.GetDirectoryName(from) + $"/{_referencePath}";
        string newImageName = Guid.NewGuid().ToString() + image.FileExtension;
        try
        {
            Directory.CreateDirectory(fullPath);
            File.Copy(image.Path, fullPath + newImageName, overwrite: true);
        }
        catch (Exception ex)
        {
            throw new ApplicationException($"File cant by copy: {ex.Message}");
        }

        return _referencePath + newImageName;
    }
}