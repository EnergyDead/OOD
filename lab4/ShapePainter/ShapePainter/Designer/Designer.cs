using ShapePainter.Shape;

namespace ShapePainter.Designer;

internal class Designer : IDesigner
{
    private readonly IShapeFactory _shapeFactory;

    public Designer(IShapeFactory shapeFactory)
    {
        _shapeFactory = shapeFactory;
    }

    public PictureDraft CreateDraft(List<string> descriptions)
    {
        List<BaseShape> shapes = new List<BaseShape>();
        foreach (var description in descriptions)
        {
            try
            {
                shapes.Add(_shapeFactory.CreateShape(description));
            }
            catch (ApplicationException ex)
            {
                Console.WriteLine($"Error shape description `{description}`. {ex.Message}");
            }
        }

        return new PictureDraft(shapes);

    }
}
