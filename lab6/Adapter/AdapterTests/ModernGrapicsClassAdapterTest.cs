using Adapter.Adapter;
using Moq;
using System.Collections.Generic;
using System.IO;
using Xunit;

namespace AdapterTests;

public class ModernGrapicsClassAdapterTest
{
    [Fact]
    public void LineTo_ColorAndStartPositionUndefined_DrawLineWithDefaultColorAndStartPosition()
    {
        // Arrange
        string[] expected = { "<draw>", "<line fromX=0 fromY=0 toX=1 toY=1>", "  <color r=\"0\" g=\"0\" b=\"0\" a=\"0\" />", "</line>", "</draw>" };
        List<string> writtenLines = new();

        Mock<TextWriter> mock = new();
        mock.Setup(s => s.WriteLine(It.IsAny<string>()))
            .Callback((string str) => writtenLines.Add(str));
        var modernGrapics = new ModernGrapicsClassAdapter(mock.Object);

        // Act
        modernGrapics.BeginDraw();
        modernGrapics.LineTo(1, 1);
        modernGrapics.EndDraw();

        // Assert
        Assert.Equal(expected.Length, writtenLines.Count);
        for (int i = 0; i < expected.Length; i++)
        {
            Assert.Equal(expected[i], writtenLines[i]);
        }
    }

    [Fact]
    public void LineTo_SetStartPosition_DrawLineWithDefaultColorAndStartPosition()
    {

        // Arrange
        string expected = "<line fromX=5 fromY=5 toX=1 toY=1>";
        List<string> writtenLines = new();

        Mock<TextWriter> mock = new();
        mock.Setup(s => s.WriteLine(It.IsAny<string>()))
            .Callback((string str) => writtenLines.Add(str));
        var modernGrapics = new ModernGrapicsClassAdapter(mock.Object);

        // Act
        modernGrapics.BeginDraw();
        modernGrapics.MoveTo(5, 5);
        modernGrapics.LineTo(1, 1);
        modernGrapics.EndDraw();

        // Assert
        Assert.Equal(5, writtenLines.Count);
        Assert.Equal(expected, writtenLines[1]);
    }

    [Fact]
    public void SetColor_DrawSetColor()
    {// Arrange
        string expected = "  <color r=\"1\" g=\"0\" b=\"1\" a=\"1\" />";
        List<string> writtenLines = new();

        Mock<TextWriter> mock = new();
        mock.Setup(s => s.WriteLine(It.IsAny<string>()))
            .Callback((string str) => writtenLines.Add(str));
        var modernGrapics = new ModernGrapicsClassAdapter(mock.Object);

        // Act
        modernGrapics.BeginDraw();
        modernGrapics.SetColor(0xFF00FF);
        modernGrapics.LineTo(1, 1);
        modernGrapics.EndDraw();

        // Assert
        Assert.Equal(5, writtenLines.Count);
        Assert.Equal(expected, writtenLines[2]);
    }
}
