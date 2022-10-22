using Command;

internal class Application
{
    private readonly Menu _menu;
    private readonly string _exitCommand = "exit";

    internal Application(Menu menu)
    {
        _menu = menu;
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
                _menu.Execute(command);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}