using System.Text;

namespace Command;

public class Menu
{
    private readonly List<Shortcut> _shortcuts = new();

    public void AddShortcut(string name, string description, Action<string> action)
    {
        _shortcuts.Add(new Shortcut(name, description, action));
    }

    public string GetInfo()
    {
        StringBuilder stringBuilder = new();
        _shortcuts.ForEach(n => stringBuilder.AppendLine(n.ToString()));

        return stringBuilder.ToString();
    }

    public void Execute(string command)
    {
        Shortcut? shortcut = _shortcuts.FirstOrDefault(mn => mn.Name.ToLower() == GetCommandName(command).ToLower());

        if (shortcut == null) throw new ApplicationException("Command not found.");

        shortcut.Executor(GetCommandDescription(command));
    }

    private static string GetCommandName(string command)
    {
        return command.Contains(' ') ? command[..command.IndexOf(' ')] : command;
    }

    private static string GetCommandDescription(string command)
    {
        return command.Contains(' ') ? command[(command.IndexOf(' ') + 1)..] : string.Empty;
    }
}

class Shortcut
{
    public string Name { get; }
    public string Description { get; }
    public Action<string> Executor { get; set; }

    public Shortcut(string name, string description, Action<string> executor)
    {
        Name = name;
        Description = description;
        Executor = executor;
    }

    public override string ToString()
    {
        return $"Command: {Name}. Description: {Description}";
    }
}
