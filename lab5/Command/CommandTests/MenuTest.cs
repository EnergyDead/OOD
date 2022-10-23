using Command;
using System;
using Xunit;

namespace CommandTests;

public class MenuTest
{
    private readonly Menu _menu;

    public MenuTest()
    {
        _menu = new Menu();
    }

    [Fact]
    public void Execute_CorrectExecute()
    {
        // Arrange
        string command = "foo";
        bool isExecute = false;

        _menu.AddShortcut(command, "", (e) => isExecute = true);

        // Act
        _menu.Execute(command);

        // Assert
        Assert.True(isExecute);
    }

    [Fact]
    public void Execute_CommandNotFound_ThrowException()
    {
        // Arrange
        string command = "foo";

        // Assert
        Assert.Throws<ApplicationException>(() => _menu.Execute(command));
    }

    [Fact]
    public void Execute_CommandThrowException_ThrowException()
    {
        // Arrange
        string command = "foo";
        _menu.AddShortcut(command, "", (_) => { throw new ApplicationException(); });

        // Act
        // Assert
        Assert.Throws<ApplicationException>(() => _menu.Execute(command));
    }

    [Fact]
    public void GetInfo_MenuHasCommand()
    {
        // Arrange
        string expectedInfo = "Command: foo1. Description: foo1 desc\r\nCommand: foo2. Description: foo2 desc\r\n";
        _menu.AddShortcut("foo1", "foo1 desc", (_) => { });
        _menu.AddShortcut("foo2", "foo2 desc", (_) => { });

        // Act
        string info = _menu.GetInfo();

        // Assert
        Assert.Equal(expectedInfo, info);
    }
}
