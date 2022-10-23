using Command.Command;
using Command.Document;
using Command.Util;
using System.Text;

namespace Command;

public static class MenuBilder
{
    public static Menu Build(this Menu menu, IDocument doc)
    {
        Setup menuSetup = new(doc);
        menu.AddNode("Help", "Print <Help> to show commands info", _ => Console.WriteLine(menu.GetInfo()));
        menu.AddNode("List", "Print <List> to show info about names and a list of document elements", menuSetup.ListCommandExecutor);
        menu.AddNode("Undo", "Print <Undo> to undo previous command", menuSetup.UndoCommandExecutor);
        menu.AddNode("Redo", "Print <Redo> to redo command", menuSetup.RedoCommandExecutor);
        menu.AddNode("Save", "Print <Save> <path> to save document", menuSetup.SaveCommandExecutor);
        menu.AddNode("SetTitle", "Print <SetTitle> <title> to determine the name of your document", menuSetup.SetTitleCommandExecutor);
        menu.AddNode("InsertParagraph", "Print <InsertParagraph> <position|end> <text> to add a paragraph to a document", menuSetup.InsertParagraphCommandExecutor);
        menu.AddNode("ReplaceText", "Print <ReplaceText> <position> <text> to replace selected text from paragraph", menuSetup.ReplaceTextCommandExecutor);
        menu.AddNode("InsertImage", "Print <InsertImage> <position|end> <weight> <height> <path> to insert image to document", menuSetup.InsertImageCommandExecutor);
        menu.AddNode("ResizeImage", "Print <ResizeImage> <position> <weight> <height> to resize image", menuSetup.ResizeImageCommandExecutor);
        menu.AddNode("DeleteItem", "Print <DeleteItem> <position> to delete item on position", menuSetup.DeleteItemCommandExecutor);
        menu.AddNode("Exit", "Print <Exit> to close program", _ => { });

        return menu;
    }
}

class Setup
{
    private readonly IDocument _doc;
    internal Setup(IDocument doc)
    {
        _doc = doc;
    }

    internal void ListCommandExecutor(string cmdParams)
    {
        if (cmdParams.Contains(' ')) throw new ApplicationException("Incorrect command. Type <Help> to help");
        StringBuilder stringBuilder = new($"Title: {_doc.Title}\n\r");
        for (uint i = 0; i < _doc.ItemCount; i++)
        {
            stringBuilder.AppendLine($"{_doc.GetItem(i)}");
        }
        Console.WriteLine(stringBuilder.ToString());
    }

    internal void DeleteItemCommandExecutor(string cmdParams)
    {
        ArgumentParser parser = new(cmdParams);
        if (parser.ArgCount != 2)
        {
            throw new ApplicationException();
        }

        uint? pos = parser.GetNextAsUint();
        if (!pos.HasValue)
        {
            throw new ApplicationException();
        }
        ICommand command = new DeleteItemCommand(_doc, pos.Value);
        command.Execute();
    }

    internal void InsertImageCommandExecutor(string cmdParams)
    {
        ArgumentParser parser = new(cmdParams);
        if (parser.ArgCount != 4)
        {
            throw new ApplicationException();
        }
        uint? pos = parser.GetNextAsUint();
        int w = parser.GetNextAsInt();
        int h = parser.GetNextAsInt();
        string path = parser.GetNextAsString();
        ICommand command = new InsertImageCommand(_doc, path, pos, w, h);
        command.Execute();
    }

    internal void InsertParagraphCommandExecutor(string cmdParams)
    {
        ArgumentParser parser = new(cmdParams);
        if (parser.ArgCount < 2) throw new ApplicationException();

        uint? pos = parser.GetNextAsUint();
        string text = parser.GetNextsAsString();

        ICommand command = new InsertParagraphCommand(_doc, pos, text);
        command.Execute();
    }

    internal void RedoCommandExecutor(string cmdParams)
    {
        if (cmdParams.Contains(' ')) throw new ApplicationException();

        _doc.Redo();
    }

    internal void ReplaceTextCommandExecutor(string cmdParams)
    {
        ArgumentParser parser = new(cmdParams);
        if (parser.ArgCount < 2)
        {
            throw new ApplicationException();
        }
        uint? pos = parser.GetNextAsUint();
        if (!pos.HasValue)
        {
            throw new ApplicationException();
        }
        string text = parser.GetNextsAsString();
        ICommand command = new ReplaceTextCommand(_doc, pos.Value, text);
        command.Execute();
    }

    internal void ResizeImageCommandExecutor(string cmdParams)
    {
        ArgumentParser parser = new ArgumentParser(cmdParams);
        if (parser.ArgCount != 3)
        {
            throw new ArithmeticException();
        }
        uint? pos = parser.GetNextAsUint();
        if (!pos.HasValue)
        {
            throw new ApplicationException();
        }
        int w = parser.GetNextAsInt();
        int h = parser.GetNextAsInt();
        ICommand command = new ResizeImageCommand(_doc, pos.Value, w, h);
        command.Execute();
    }

    internal void SaveCommandExecutor(string cmdParams)
    {
        ArgumentParser parser = new(cmdParams);
        if (parser.ArgCount != 1) throw new ApplicationException();

        _doc.Save($"{parser.GetNextAsString()}.html");
    }

    internal void SetTitleCommandExecutor(string cmdParams)
    {
        ArgumentParser parser = new(cmdParams);
        if (parser.ArgCount < 1) throw new ApplicationException();

        ICommand command = new SetTitleCommand(_doc, parser.GetNextsAsString());
        command.Execute();
    }

    internal void UndoCommandExecutor(string cmdParams)
    {
        if (cmdParams.Contains(' ')) throw new ApplicationException();

        _doc.Undo();
    }
}

