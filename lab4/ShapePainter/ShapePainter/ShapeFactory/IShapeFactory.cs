namespace ShapePainter.Shape;

public interface IShapeFactory
{
    BaseShape CreateShape(string description);
}
