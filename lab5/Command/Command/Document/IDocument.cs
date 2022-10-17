using Command.Document.Item;
using Command.Document.Item.Image;

namespace Command.Document;

public interface IDocument
{
    string Title { get; set; }
    bool CanUndo { get; }
    bool CanRedo { get; }
    uint ItemCount { get; }
    void Undo();
    void Redo();
    IItem GetItem(uint index);
    void InsertParagraph(string text, uint? pos = null);
    void InsertImage(string path,int width, int height, uint? pos = null);
    void DeleteItem(uint index);
    void Save(string path);
    IHistory History { get; }
}
