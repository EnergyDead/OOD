namespace Streams;

public class Option
{
    public OptionType Type { get; set; }
    public string Argument { get; set; }
    public int? Key { get; set; }

    public Option(OptionType optionType, string argument, int? key = null)
    {
        Type = optionType;
        Argument = argument;
        Key = key;
    }
}

public enum OptionType
{
    input,
    output
}
