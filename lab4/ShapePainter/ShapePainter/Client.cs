using ShapePainter.Canvas;
using ShapePainter.Designer;

namespace ShapePainter;

internal class Client
{
    private readonly ICanvas _canvas;
    private readonly IDesigner _designer;
    private readonly IPainter _painter;
    private readonly List<string> _descriptions;

    public Client(ICanvas canvas, IDesigner designer, IPainter painter)
    {
        _canvas = canvas;
        _designer = designer;
        _painter = painter;
        _descriptions = new();
    }

    internal void Run()
    {
        Info();
        while (true)
        {
            string command = Console.ReadLine()!.ToLower();
            switch (command)
            {
                case "exit":
                    continue;
                case "info":
                    Info();
                    break;
                case "paint":
                    Paint();
                    break;
                case "clear":
                    Clear();
                    break;
                default:
                    Command(command);
                    break;
            }
        }
    }

    private void Clear()
    {
        _descriptions.Clear();
    }

    private void Paint()
    {
        PictureDraft pictureDraft = _designer.CreateDraft(_descriptions);
        _painter.DrawPicture(pictureDraft, _canvas);
    }

    private void Command(string command)
    {
        _descriptions.Add(command);
    }

    private static void Info()
    {
        Console.WriteLine("info - show available commands");
        Console.WriteLine("paint <sketchName> - artist draws according to the sketch of the picture from the designer");
        Console.WriteLine("clear - delete everything from the draft image");
        Console.WriteLine("exit - close the program");
        Console.WriteLine("Provide a design for the designer (The designer has a host size of 1000 by 1000):");
        Console.WriteLine("Triangle <color> <start.X> <start.Y> <vertex1.x> <vertex1.Y> <vertex2.x> <vertex2.Y> <vertex3.x> <vertex3.Y>");
        Console.WriteLine("Rectangle <color> <start.X> <start.Y> <point1.X> <point1.Y> <point2.X> <point2.Y>");
        Console.WriteLine("Ellipse <color> <start.X> <start.Y> <width> <height>");
        Console.WriteLine("RegularPolygon <color> <start.X> <start.Y> <vertexCount> <radius>");
    }
}
