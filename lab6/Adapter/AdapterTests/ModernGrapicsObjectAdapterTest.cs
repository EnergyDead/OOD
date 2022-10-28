using Adapter.Adapter;
using Adapter.ModernGrapicsLib;
using Moq;
using System.Collections.Generic;
using System.IO;
using Xunit;

namespace AdapterTests;

public class ModernGrapicsObjectAdapterTest
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
        Mock<ModernGraphicsRenderer> rendererMock = new(mock.Object);
        var modernGrapics = new ModernGrapicsObjectAdapter(rendererMock.Object);

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
    public void EndDraw_DrawEndDrawBlock()
    {
        // Arrange
        string[] expected = { "<draw>", "</draw>" };
        List<string> writtenLines = new();

        Mock<TextWriter> mock = new();
        mock.Setup(s => s.WriteLine(It.IsAny<string>()))
            .Callback((string str) => writtenLines.Add(str));
        Mock<ModernGraphicsRenderer> rendererMock = new(mock.Object);
        var modernGrapicsObjectAdapter = new ModernGrapicsObjectAdapter(rendererMock.Object);

        // Act
        modernGrapicsObjectAdapter.BeginDraw();
        rendererMock.Object.Dispose();

        // Assert
        Assert.Equal(expected.Length, writtenLines.Count);
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
        Mock<ModernGraphicsRenderer> rendererMock = new(mock.Object);
        var modernGrapicsObjectAdapter = new ModernGrapicsObjectAdapter(rendererMock.Object);

        // Act
        modernGrapicsObjectAdapter.BeginDraw();
        modernGrapicsObjectAdapter.MoveTo(5, 5);
        modernGrapicsObjectAdapter.LineTo(1, 1);
        modernGrapicsObjectAdapter.EndDraw();

        // Assert
        Assert.Equal(5, writtenLines.Count);
        Assert.Equal(expected, writtenLines[1]);
    }

    [Fact]
    public void SetColor_DrawSetColor()
    {
        // Arrange
        string expected = "  <color r=\"170\" g=\"170\" b=\"170\" a=\"0\" />";
        List<string> writtenLines = new();

        Mock<TextWriter> mock = new();
        mock.Setup(s => s.WriteLine(It.IsAny<string>()))
            .Callback((string str) => writtenLines.Add(str));
        Mock<ModernGraphicsRenderer> rendererMock = new(mock.Object);
        var modernGrapicsObjectAdapter = new ModernGrapicsObjectAdapter(rendererMock.Object);

        // Act
        modernGrapicsObjectAdapter.BeginDraw();
        modernGrapicsObjectAdapter.SetColor(0xAAAAAA);
        modernGrapicsObjectAdapter.LineTo(1, 1);
        modernGrapicsObjectAdapter.EndDraw();

        // Assert
        Assert.Equal(5, writtenLines.Count);
        Assert.Equal(expected, writtenLines[2]);
    }
}
