namespace Command;

public static class MenuBilder
{
    public static Menu Build (this Menu menu)
    {
        menu.AddNode("Help", "Print <Help> to show command info", _ => Console.WriteLine(menu.GetInfo()));

        return menu;
    }
}
