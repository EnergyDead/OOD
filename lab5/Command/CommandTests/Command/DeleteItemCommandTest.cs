using Command.Document;
using Moq;
using Xunit;
using System;
using Command.Command;
using ImageClass = Command.Document.Item.Image.Image;

namespace CommandTests.Command;

public class DeleteItemCommandTest
{
    readonly Mock<IDocument> _documentMock;

    public DeleteItemCommandTest()
    {
        _documentMock = new Mock<IDocument>();
    }

    [Fact]
    public void Execute()
    {
        // Arrange
        bool isDeleteItemInvoked = false;
        _documentMock.Setup(d => d.DeleteItem(It.IsAny<uint>())).Callback(() => isDeleteItemInvoked = true);
        ICommand command = new DeleteItemCommand( _documentMock.Object, 1);

        // Act
        command.Execute();

        // Assert
        Assert.True(isDeleteItemInvoked);
    }

    [Fact]
    public void Unexecute()
    {
        // Arrange
        var image = new ImageClass("", "", 1, 1);

        bool isInsertItemInvoked = false;
        _documentMock
            .Setup(d => d.InsertImage(It.IsAny<string>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<uint>()))
            .Callback(() => isInsertItemInvoked = true);
        _documentMock.Setup(d => d.GetItem(It.IsAny<uint>())).Returns(image);
        ICommand command = new DeleteItemCommand(_documentMock.Object, 1);
        command.Execute();

        // Act
        command.Unexecute();

        // Assert
        Assert.True(isInsertItemInvoked);
    }
}
