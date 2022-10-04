using ShapePainter.Canvas;
using ShapePainter.Designer;

namespace ShapePainter;

internal class Client
{
    private readonly ICanvas _canvas;
    private readonly IDesigner _designer;
    private readonly IPainter _painter;

    public Client(ICanvas canvas, IDesigner designer, IPainter painter)
    {
        _canvas = canvas;
        _designer = designer;
        _painter = painter;
    }

    internal void Run()
    {
        Info();
        while (true)
        {
            string command = Console.ReadLine()!;
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
                default:
                    break;
            }
        }
    }

    private void Paint()
    {
        throw new NotImplementedException();
    }

    private void Command(string command)
    {
        throw new NotImplementedException();
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
