namespace Command.Document.Item.Image;

public interface IImage : IItem
{
    int Width { get; set; }
    int Height { get; set; }
    string Path { get; set; }
    string FileExtension { get; set; }
    void Resize(int width, int height);
}
