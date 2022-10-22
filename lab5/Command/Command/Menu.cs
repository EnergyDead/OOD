using System.Text;

namespace Command;

public class Menu
{
    private readonly List<MenuNode> _menuNodes = new();
    private readonly string _exitCommand = "exit";

    public void AddNode(string name, string description, Action<string> action)
    {
        _menuNodes.Add(new MenuNode(name, description, action));
    }

    internal void Run()
    {
        var isExit = false;
        while (!isExit)
        {
            string command = Console.ReadLine()!;
            if (command.ToLower() == _exitCommand) break;
            try
            {
                Execute(command);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }

    public string GetInfo()
    {
        StringBuilder stringBuilder = new();
        _menuNodes.ForEach(n => stringBuilder.AppendLine(n.ToString()));

        return stringBuilder.ToString();
    }

    private void Execute(string command)
    {
        MenuNode? node = _menuNodes.FirstOrDefault(mn => mn.Name.ToLower() == GetCommandName(command).ToLower());

        if (node == null) throw new ApplicationException("Command not found.");

        node.Executor(GetCommandDescription(command));
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

class MenuNode
{
    public string Name { get; }
    public string Description { get; }
    public Action<string> Executor { get; set; }

    public MenuNode(string name, string description, Action<string> executor)
    {
        Name = name;
        Description = description;
        Executor = executor;
    }

    public override string ToString()
    {
        return $"Command: {Name}. Description {Description}";
    }
}
