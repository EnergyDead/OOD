using Command.Document;
using Moq;
using Xunit;
using System;
using ImageClass = Command.Document.Item.Image.Image;
using Command.Command;

namespace CommandTests.Command;

public class InsertImageCommandTest
{
    readonly Mock<IDocument> _documentMock;

    public InsertImageCommandTest()
    {
        _documentMock = new Mock<IDocument>();
    }

    [Fact]
    public void Execute()
    {
        // Arrange
        var image = new ImageClass("", "", 1, 1);

        bool isInvoked = false;
        _documentMock
            .Setup(d => d.InsertImage(It.IsAny<string>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<uint>()))
            .Callback(() => isInvoked = true);

        _documentMock.Setup(d => d.GetItem(It.IsAny<uint>())).Returns(image);
        ICommand command = new InsertImageCommand(_documentMock.Object, "", 1, 1, 1);

        // Act
        command.Execute();

        // Assert
        Assert.True(isInvoked);
    }

    [Fact]
    public void Unexecute()
    {
        // Arrange
        bool isInvoked = false;
        _documentMock.Setup(d => d.DeleteItem(It.IsAny<uint>())).Callback(() => isInvoked = true);
        ICommand command = new InsertImageCommand(_documentMock.Object,"", 1, 1, 1);

        // Act
        command.Unexecute();

        // Assert
        Assert.True(isInvoked);
    }
}
