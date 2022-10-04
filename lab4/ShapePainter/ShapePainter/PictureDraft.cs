using ShapePainter.Shape;

namespace ShapePainter;

internal class PictureDraft
{
    public List<BaseShape> Shapes { get; private set; }

    public PictureDraft(List<BaseShape> shapes)
    {
        Shapes = shapes;
    }
}
