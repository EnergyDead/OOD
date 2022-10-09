using System.Drawing;

namespace ShapePainter;

public class ArgumentParser
{
    private int _index = 0;

    private List<string> _arguments;

    public bool HasNext { get => _index != _arguments.Count; }

    public int ArgCount { get => _arguments.Count; }

    public ArgumentParser(List<string> arguments)
    {
        _arguments = arguments;
    }

    public string GetNextAsString()
    {
        return _arguments[_index++];
    }

    public int GetNextAsInt()
    {
        return int.Parse(GetNextAsString());
    }
    public Point GetNextAsPoint()
    {
        return new Point(GetNextAsInt(), GetNextAsInt());
    }

    public Color GetColor()
    {
        string color = GetNextAsString();
        switch (color)
        {
            case "green":
                return Color.Green;
            case "red":
                return Color.Red;
            case "blue":
                return Color.Blue;
            case "yellow":
                return Color.Yellow;
            case "pink":
                return Color.Pink;
            case "black":
                return Color.Black;
            default:
                throw new ApplicationException("Unknown color");
        }
    }
}
