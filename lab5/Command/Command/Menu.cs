namespace Command;

public class Menu
{
    private readonly List<MenuNode> _menuNodes = new();
    private readonly string _exitCommand = "exit";

    public void AddNode(MenuNode menuNode)
    {
        _menuNodes.Add(menuNode);
    }
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
            catch (ApplicationException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }

    public string GetInfo()
    {
        return "i cant help.. sry";
    }

    private void Execute(string command)
    {
        MenuNode? node = _menuNodes.FirstOrDefault(mn => mn.Name == GetCommandName(command));

        if (node == null) throw new ApplicationException("Command not found.");

        node.Executor(GetCommandDescription(command));
    }

    private static string GetCommandName(string command)
    {
        return command.Contains(' ') ? command[..command.IndexOf(' ')] : command;
    }

    private static string GetCommandDescription(string command)
    {
        return command.Contains(' ') ? string.Empty : command[(command.IndexOf(' ')+1)..];
    }
}
