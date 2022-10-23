using Command.Document.Item;
using ParagraphCalss = Command.Document.Item.Paragraph.Paragraph;
using Xunit;
using Command.Document.Item.Paragraph;

namespace CommandTests.Document.Item.Paragraph;

public class ParagraphTest
{
    [Fact]
    public void Text_Correct()
    {
        // Arrange
        string text = "temp";
        IParagraph item;

        // Act
        item = new ParagraphCalss(text);

        // Assert
        Assert.Equal(text, item.Text);
    }

    [Fact]
    public void Description_GetToString()
    {
        // Arrange
        string expectedDesc = "Paragraph: foo";
        IParagraph item = new ParagraphCalss("foo");

        // Act
        string paragraphDesc = item.ToString()!;

        // Assert
        Assert.Equal(expectedDesc, paragraphDesc);
    }

    [Fact]
    public void ToHtml_Paragraph()
    {
        // Arrange
        string expectedHtml = "<p>temp</p>";
        IItem item = new ParagraphCalss("temp");

        // Act
        string paragraphHtml = item.ToHtml();

        // Assert
        Assert.Equal(expectedHtml, paragraphHtml);
    }
}
