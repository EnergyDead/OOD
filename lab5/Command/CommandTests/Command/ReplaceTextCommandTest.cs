using Command.Document;
using Moq;
using Xunit;
using System;
using Command.Document.Item.Paragraph;
using Command.Command;

namespace CommandTests.Command;

public class ReplaceTextCommandTest
{
    readonly Mock<IDocument> _documentMock;
    private readonly Mock<History> _historyMock;

    public ReplaceTextCommandTest()
    {
        _historyMock = new Mock<History>();
        _historyMock.Setup(h => h.Add(It.IsAny<ICommand>()));
        _documentMock = new Mock<IDocument>();
        _documentMock.SetupGet(d => d.History).Returns(_historyMock.Object);
    }

    [Fact]
    public void Execute_GetItemAndReplaceText()
    {
        // Arrange
        string text = "foo";
        Paragraph paragraph = new("");

        _documentMock.Setup(d => d.GetItem(It.IsAny<uint>())).Returns(paragraph);
        ICommand command = new ReplaceTextCommand(_documentMock.Object, 1, text);

        // Act
        command.Execute();

        // Assert
        Assert.Equal(text, paragraph.Text);
    }

    [Fact]
    public void Unexecute_ReturnOriginTextValue()
    {
        // Arrange
        var paragraph = new Paragraph("");

        _documentMock.Setup(d => d.GetItem(It.IsAny<uint>())).Returns(paragraph);
        ICommand command = new ReplaceTextCommand(_documentMock.Object, 1, "foo");
        command.Execute();

        // Act
        command.Unexecute();

        // Assert
        Assert.Equal("", paragraph.Text);
    }
}
