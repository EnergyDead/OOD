namespace Command.Document.Item.Image;

public class Image : IImage
{
    const int _maxWidth = 10000;
    const int _maxHeight = 10000;

    public Image(string tempFileName, string fileExtrension, int width, int height)
    {
        Path = tempFileName;
        FileExtension = fileExtrension;
        Resize(width, height);
    }

    public int Width { get; set; }
    public int Height { get; set; }
    public string Path { get; set; }
    public string FileExtension { get; set; }
    public object Item { get; set; }
    public ItemType Type => ItemType.Image;

    public void Resize(int width, int height)
    {
        Width = width > _maxWidth ? _maxWidth : (width < 0 ? 0 : width);
        Height = height > _maxHeight ? _maxHeight : (height < 0 ? 0 : height);
    }

    public string ToHtml(string? path = null)
    {
        return $"<img src=\"{path}\" width=\"{Width}\" height=\"{Height}\">";
    }

    public override string ToString()
    {
        return $"Image: Width - {Width} Height - {Height} Path - {Path}";
    }
}
