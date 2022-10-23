using AngleSharp.Html.Parser;
using DocumentClass = Command.Document.Document;
using Command.Document;
using Command.Document.Item;
using Command.Document.Item.Image;
using Moq;
using System;
using System.IO;
using Xunit;

namespace CommandTests.Document;

public class DocumentTest
{
    private readonly Mock<History> _documentHistoryMock = new();
    private readonly IDocument _document;

    public DocumentTest()
    {
        _document = new DocumentClass(_documentHistoryMock.Object);
    }

    [Fact]
    public void InsertParagraph_PositionOverflowDocumentCount_ThrowException()
    {
        // Arrange
        // Act
        // Assert
        Assert.Equal<uint>(0, _document.ItemCount);
        Assert.Throws<ArgumentOutOfRangeException>(() => _document.InsertParagraph("Text", 1));
    }

    [Fact]
    public void InsertParagraph_CorectInsert()
    {
        // Arrange
        string text = "foo foo";

        // Act
        _document.InsertParagraph(text, 0);

        // Assert
        Assert.Equal<uint>(1, _document.ItemCount);
        Assert.Equal(ItemType.Paragraph, _document.GetItem(0).Type);
    }

    [Fact]
    public void InsertImage_CorectInsert()
    {
        // Arrange
        string path = Path.GetTempFileName();

        // Act
        _document.InsertImage(path, 1, 1, 0);

        // Assert
        Assert.Equal<uint>(1, _document.ItemCount);
        Assert.Equal(ItemType.Image, _document.GetItem(0).Type);
    }

    [Fact]
    public void InsertImage_WidhthAndHeightMoreMax_CorectInsert()
    {
        // Arrange
        int maxSize = 10000;
        string path = Path.GetTempFileName();

        // Act
        _document.InsertImage(path, 100000, 10001, 0);

        // Assert
        Assert.Equal<uint>(1, _document.ItemCount);
        Assert.Equal(ItemType.Image, _document.GetItem(0).Type);
        IImage image = (IImage)_document.GetItem(0);
        Assert.Equal(maxSize, image.Width);
        Assert.Equal(maxSize, image.Height);
    }

    [Fact]
    public void InsertImage_InsertMoreMaxHistory_ImageDoesNotDeleted()
    {
        // Arrange
        string filePath = Path.GetTempFileName();
        _document.InsertImage(filePath, 1, 1);
        string tempPath = ((IImage)_document.GetItem(0)).Path;
        int maxHistory = 10;

        // Act
        for (int i = 0; i <= maxHistory; i++)
        {
            _document.InsertImage(filePath, 1, 1);
        }

        // Assert
        Assert.True(File.Exists(tempPath));
    }

    [Fact]
    public void SetTitle_GetTitle()
    {
        // Arrange
        string title = "newTitle";

        // Act
        _document.Title = title;

        // Assert
        Assert.Equal(title, _document.Title);
    }

    [Fact]
    public void DeleteItem()
    {
        // Arrange
        _document.InsertImage(Path.GetTempFileName(), 1, 1);

        // Act
        _document.DeleteItem(0);

        // Assert
        Assert.Equal<uint>(0, _document.ItemCount);
    }

    [Fact]
    public void Undo_CorrectResult()
    {
        // Arrange
        bool isUndoInvoked = false;
        _documentHistoryMock.Setup(h => h.Undo()).Callback(() => isUndoInvoked = true);

        // Act
        _document.Undo();

        // Assert
        Assert.True(isUndoInvoked);
    }

    [Fact]
    public void Redo_CorrectResult()
    {
        // Arrange
        bool isRedoInvoked = false;
        _documentHistoryMock.Setup(h => h.Redo()).Callback(() => isRedoInvoked = true);

        // Act
        _document.Redo();

        // Assert
        Assert.True(isRedoInvoked);
    }

    [Fact]
    public void CanUndo_False()
    {
        // Arrange
        // Act
        // Assert
        Assert.False(_document.CanUndo, "history has not command to undo");
    }

    [Fact]
    public void CanRedo_False()
    {
        // Arrange
        // Act
        // Assert
        Assert.False(_document.CanRedo, "history has not command to redo");
    }

    [Fact]
    public void Save_SaveCorrect()
    {
        // Arrange
        _document.InsertParagraph("foo");
        string path = Path.Combine(Path.GetTempPath(), "InsertParagraph.html");

        // Act
        _document.Save(path);

        // Assert
        Assert.True(File.Exists(path));
    }

    [Fact]
    public void Save_SaveImageHasReferencePath()
    {
        // Arrange
        string expectedImagePathBegining = "images/";
        _document.InsertImage(Path.GetTempFileName(), 1, 1);
        string path = Path.Combine(Path.GetTempPath(), "1.html");

        // Act
        _document.Save(path);

        // Assert
        Assert.True(File.Exists(path));
        string imagePath = GetImagePath(path)!;
        Assert.StartsWith(expectedImagePathBegining, imagePath);
    }

    private static string? GetImagePath(string path)
    {
        var document = new HtmlParser().ParseDocument(File.ReadAllText(path));
        var image = document.QuerySelector("img");
        return image?.Attributes.GetNamedItem("src")?.Value;
    }
}
