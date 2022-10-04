namespace ShapePainter.Shape;

internal interface IShapeFactory
{
    BaseShape CreateShape(string description);
}
