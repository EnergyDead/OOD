using System.Text;

namespace Command.Util;

internal class ArgumentParser
{
    private int _index = 0;

    private string[] _arguments;

    public bool HasNext { get => _index != _arguments.Length; }

    public int ArgCount { get => _arguments.Length; }

    public ArgumentParser(string arguments)
    {
        _arguments = arguments?.Split(' ') ?? Array.Empty<string>();
    }

    public string GetNextAsString()
    {
        return _arguments[_index++];
    }

    public string GetNextsAsString()
    {
        List<string> words = new();
        while(HasNext)
        {
            words.Add(GetNextAsString());
        }
        return string.Join(" ", words);
    }

    public int GetNextAsInt()
    {
        return int.Parse(GetNextAsString());
    }

    public uint? GetNextAsUint()
    {
        string arg = GetNextAsString();
        return arg == "end" ? null : uint.Parse(arg);
    }
}
