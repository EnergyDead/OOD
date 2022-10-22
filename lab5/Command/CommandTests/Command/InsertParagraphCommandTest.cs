using Command.Document;
using Moq;
using Xunit;
using System;
using Command.Command;
using Command.Document.Item.Paragraph;

namespace CommandTests.Command;

public class InsertParagraphCommandTest
{
    readonly Mock<IDocument> _documentMock;

    public InsertParagraphCommandTest()
    {
        _documentMock = new Mock<IDocument>();
    }

    [Fact]
    public void Execute()
    {
        // Arrange
        bool isInvoked = false;
        var paragrpah = new Paragraph("");

        _documentMock.Setup(d => d.InsertParagraph(It.IsAny<string>(), It.IsAny<uint>())).Callback(() => isInvoked = true);
        _documentMock.Setup(d => d.GetItem(It.IsAny<uint>())).Returns(paragrpah);

        ICommand command = new InsertParagraphCommand( _documentMock.Object, 1, "");

        // Act
        command.Execute();

        // Assert
        Assert.True(isInvoked);
    }

    [Fact]
    public void Unexecute()
    {
        // Arrange
        bool isDeleteItemInvoked = false;
        _documentMock.Setup(d => d.DeleteItem(It.IsAny<uint>())).Callback(() => isDeleteItemInvoked = true);
        ICommand command = new InsertParagraphCommand(_documentMock.Object, 1, "");

        // Act
        command.Unexecute();

        // Assert
        Assert.True(isDeleteItemInvoked);
    }
}
