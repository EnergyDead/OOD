using ImageClass = Command.Document.Item.Image.Image;
using Command.Document.Item.Image;
using Xunit;

namespace CommandTests.Document.Item.Image;

public class ImageTest
{
    [Fact]
    public void Resize_Correct()
    {
        // Arrange
        IImage image = new ImageClass("", "", 1, 1);
        int width = 300;
        int height = 300;
        
        // Act
        image.Resize(width, height);

        // Assert
        Assert.Equal(height, image.Height);
        Assert.Equal(width, image.Width);
    }

    [Fact]
    public void Resize_ValueMoreMax_SetMaxSizes()
    {
        // Arrange
        int maxWidth = 10000;
        int maxHeight = 10000;

        IImage image = new ImageClass("", "", 1, 1);
        int width = 30000;
        int height = 30000;

        // Act
        image.Resize(width, height);

        // Assert
        Assert.Equal(maxHeight, image.Height);
        Assert.Equal(maxWidth, image.Width);
    }

    [Fact]
    public void Description_GetToString()
    {
        // Arrange
        string expectedDesc = "Image: Width - 1 Height - 1 Path - foo";
        IImage image = new ImageClass("foo", "png", 1, 1);

        // Act
        string imageDesc = image.ToString()!;

        // Assert
        Assert.Equal(expectedDesc, imageDesc);
    }
}
