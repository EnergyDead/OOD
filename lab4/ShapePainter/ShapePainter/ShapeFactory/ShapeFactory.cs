using System.Drawing;

namespace ShapePainter.Shape;

internal class ShapeFactory : IShapeFactory
{
    private static readonly Dictionary<string, Func<List<string>, BaseShape>> _shapeCreator = new()
    {
        { "ellipse", CreateEllipse },
        { "rectangle", CreateRectangle },
        { "triangle", CreateTriangle },
        { "regularpolygon", CreateRegularPolygon }
    };

    public BaseShape CreateShape(string description)
    {
        List<string> descriptions = description.Split(" ").ToList();
        string shapeType = GetNameByDescription(descriptions);
        if (_shapeCreator.ContainsKey(shapeType))
        {
            try
            {
                return _shapeCreator[shapeType].Invoke(descriptions);
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message);
            }
        }
        throw new ApplicationException("Unknown shape type");
    }

    private string GetNameByDescription(List<string> descriptions)
    {
        if (descriptions.Count > 1)
        {
            return descriptions[0];
        }

        throw new ApplicationException("Incorrect amount of arguments");
    }

    private static BaseShape CreateEllipse(List<string> arg)
    {
        // "Ellipse <color> <start.X> <start.Y> <width> <height>"
        if (arg.Count != 6)
        {
            throw new ApplicationException("Error when creating Ellipse. Incorrect amount of arguments");
        }

        Color color = ParseColor(arg[1]);
        Point startPos = new Point(int.Parse(arg[2]), int.Parse(arg[3]));
        int width = int.Parse(arg[4]);
        int height = int.Parse(arg[5]);

        return new Ellipse(color, startPos, width, height);
    }

    private static BaseShape CreateRegularPolygon(List<string> arg)
    {
        // "RegularPolygon <color> <start.X> <start.Y> <vertexCount> <radius>"
        if (arg.Count != 6)
        {
            throw new ApplicationException("Error when creating RegularPolygon. Incorrect amount of arguments");
        }
        Color color = ParseColor(arg[1]);
        Point startPos = new Point(int.Parse(arg[2]), int.Parse(arg[3]));
        int vertexCount = int.Parse(arg[4]);
        int radius = int.Parse(arg[5]);

        return new RegularPolygon(color, startPos, vertexCount, radius);
    }

    private static BaseShape CreateTriangle(List<string> arg)
    {
        // "Triangle <color> <start.X> <start.Y> <vertex1.x> <vertex1.Y> <vertex2.x> <vertex2.Y> <vertex3.x> <vertex3.Y>"
        if (arg.Count != 10)
        {
            throw new ApplicationException("Error when creating Triangle. Incorrect amount of arguments");
        }

        throw new NotImplementedException();
    }

    private static BaseShape CreateRectangle(List<string> arg)
    {
        // "Rectangle <color> <start.X> <start.Y> <point1.X> <point1.Y> <point2.X> <point2.Y>"
        if (arg.Count != 8)
        {
            throw new ApplicationException("Error when creating Rectangle. Incorrect amount of arguments");
        }

        throw new NotImplementedException();
    }

    private static Color ParseColor(string v)
    {
        Color color = new Color();
        switch (v)
        {
            case "green":
                color = Color.Green;
                break;
            case "red":
                color = Color.Red;
                break;
            case "blue":
                color = Color.Blue;
                break;
            case "yellow":
                color = Color.Yellow;
                break;
            case "pink":
                color = Color.Pink;
                break;
            case "black":
                color = Color.Black;
                break;
            default:
                throw new ApplicationException("Unknown color");
        }
        return color;
    }
}