using System.Web;

namespace Command.Document.Item.Paragraph;

public class Paragraph : IParagraph
{
    public string Text { get; set; }
    public object Item { get; set; }
    public ItemType Type => ItemType.Paragraph;

    public Paragraph(string text)
    {
        Text = text;
    }

    public override string ToString()
    {
        return $"Paragraph: {Text}";
    }

    public string ToHtml(string? path = null)
    {
        return $"<p>{HttpUtility.HtmlDecode(Text)}</p>";
    }
}
