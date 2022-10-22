using Command.Document;
using DocumentClass = Command.Document.Document;
using Moq;
using Xunit;
using Command.Command;

namespace CommandTests.Command;

public class SetTitleCommandTest
{
    readonly IDocument _document;

    public SetTitleCommandTest()
    {
        _document = new DocumentClass(new Mock<History>().Object);
    }

    [Fact]
    public void Execute()
    {
        // Arrange
        string newTitle = "foo";
        ICommand command = new SetTitleCommand(_document, newTitle);

        // Act
        command.Execute();

        // Assert
        Assert.Equal(newTitle, _document.Title);
    }

    [Fact]
    public void Unexecute()
    {
        // Arrange
        string oldTitle = "not foo";
        _document.Title = oldTitle;
        string newTitle = "foo";
        ICommand command = new SetTitleCommand(_document, newTitle);
        command.Execute();

        // Act
        command.Unexecute();

        // Assert
        Assert.Equal(oldTitle, _document.Title);
    }
}
