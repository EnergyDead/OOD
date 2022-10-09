using System.Drawing;

namespace ShapePainter.Shape;

public class ShapeFactory : IShapeFactory
{
    private static readonly Dictionary<string, Func<ArgumentParser, BaseShape>> _shapeCreator = new()
    {
        { "ellipse", CreateEllipse },
        { "rectangle", CreateRectangle },
        { "triangle", CreateTriangle },
        { "regularpolygon", CreateRegularPolygon }
    };

    public BaseShape CreateShape(string description)
    {
        List<string> descriptions = description.ToLower().Split(" ").ToList();
        ArgumentParser argumentParser = new(descriptions);
        string shapeType = GetName(argumentParser);
        if (_shapeCreator.ContainsKey(shapeType))
        {
            try
            {
                return _shapeCreator[shapeType].Invoke(argumentParser);
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message);
            }
        }
        throw new ApplicationException("Unknown shape type");
    }

    private string GetName(ArgumentParser argumentParser)
    {
        if (argumentParser.ArgCount > 1)
        {
            return argumentParser.GetNextAsString();
        }

        throw new ApplicationException("Incorrect amount of arguments");
    }

    private static BaseShape CreateEllipse(ArgumentParser parser)
    {
        // "Ellipse <color> <start.X> <start.Y> <width> <height>"
        if (parser.ArgCount != 6)
        {
            throw new ApplicationException("Error when creating Ellipse. Incorrect amount of arguments");
        }

        Color color = parser.GetColor();
        Point startPos = parser.GetNextAsPoint();
        int width = parser.GetNextAsInt();
        int height = parser.GetNextAsInt();

        return new Ellipse(color, startPos, width, height);
    }

    private static BaseShape CreateRegularPolygon(ArgumentParser parser)
    {
        // "RegularPolygon <color> <points> (points - <point.X> <point.Y>)"
        if (parser.ArgCount < 2)
        {
            throw new ApplicationException("Error when creating RegularPolygon. Incorrect amount of arguments");
        }
        Color color = parser.GetColor();
        List<Point> points = new();

        for (int i = 2; i < parser.ArgCount; i+=2)
        {
            points.Add(parser.GetNextAsPoint());
        }

        return new RegularPolygon(color, points.ToArray());
    }

    private static BaseShape CreateTriangle(ArgumentParser parser)
    {
        // "Triangle <color> <vertex1.x> <vertex1.Y> <vertex2.x> <vertex2.Y> <vertex3.x> <vertex3.Y>"
        if (parser.ArgCount != 8)
        {
            throw new ApplicationException("Error when creating Triangle. Incorrect amount of arguments");
        }
        Color color = parser.GetColor();
        Point vertex1 = parser.GetNextAsPoint();
        Point vertex2 = parser.GetNextAsPoint();
        Point vertex3 = parser.GetNextAsPoint();

        return new Triangle(color, vertex1, vertex2, vertex3);
    }

    private static BaseShape CreateRectangle(ArgumentParser parser)
    {
        // "Rectangle <color> <point1.X> <point1.Y> <point2.X> <point2.Y>"
        if (parser.ArgCount != 6)
        {
            throw new ApplicationException("Error when creating Rectangle. Incorrect amount of arguments");
        }
        Color color = parser.GetColor();
        Point point1 = parser.GetNextAsPoint();
        Point point2 = parser.GetNextAsPoint();

        return new Rectangle(color, point1, point2);
    }
}