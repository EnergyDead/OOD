using Command.Document;
using Moq;
using Xunit;
using System;
using ImageClass = Command.Document.Item.Image.Image;
using Command.Command;

namespace CommandTests.Command;

public class ResizeImageCommandTest
{
    readonly Mock<IDocument> _documentMock;
    private readonly Mock<History> _historyMock;

    public ResizeImageCommandTest()
    {
        _historyMock = new Mock<History>();
        _historyMock.Setup(h => h.Add(It.IsAny<ICommand>()));
        _documentMock = new Mock<IDocument>();
        _documentMock.SetupGet(d => d.History).Returns(_historyMock.Object);
    }

    [Fact]
    public void Execute()
    {
        // Arrange
        var image = new ImageClass("", "", 5, 5);

        _documentMock.Setup(d => d.GetItem(It.IsAny<uint>())).Returns(image);
        ICommand command = new ResizeImageCommand(_documentMock.Object, 1, 1, 1);

        // Act
        command.Execute();

        // Assert
        Assert.Equal(1, image.Width);
        Assert.Equal(1, image.Height);
    }

    [Fact]
    public void Unexecute()
    {
        // Arrange
        var image = new ImageClass("", "", 1, 1);

        _documentMock.Setup(d => d.GetItem(It.IsAny<uint>())).Returns(image);
        ICommand command = new ResizeImageCommand(_documentMock.Object, 1, 5, 5);
        command.Execute();

        // Act
        command.Unexecute();

        // Assert
        Assert.Equal(1, image.Width);
        Assert.Equal(1, image.Height);
    }
}
