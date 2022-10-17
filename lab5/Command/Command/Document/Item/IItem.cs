using Command.Document.Item.Image;
using Command.Document.Item.Paragraph;

namespace Command.Document.Item;

public interface IItem
{
    ItemType Type { get; }
    string ToHtml(string? path = null);
}
