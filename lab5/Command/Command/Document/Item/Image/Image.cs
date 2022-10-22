namespace Command.Document.Item.Image;

public class Image : IImage
{
    const int _maxWidth = 10000;
    const int _maxHeight = 10000;
    const string _referencePath = "Images/";

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
        string fullPath = System.IO.Path.GetDirectoryName(path) + $"/{_referencePath}";
        string newImageName = Guid.NewGuid().ToString() + FileExtension;
        try
        {
           Directory.CreateDirectory(fullPath);
           File.Copy(Path, fullPath + newImageName, overwrite: true);
        }
        catch (Exception ex)
        {
            throw new ApplicationException($"File cant by copy: {ex.Message}");
        }

        return $"<img src=\"{_referencePath + newImageName}\" width=\"{Width}\" height=\"{Height}\">";
    }

    public override string ToString()
    {
        return $"Image: Width - {Width} Height - {Height} Path - {Path}";
    }
}
