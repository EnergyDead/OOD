namespace Command;

public class MenuNode
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
