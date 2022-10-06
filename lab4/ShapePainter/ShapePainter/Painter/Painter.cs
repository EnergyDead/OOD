using ShapePainter.Canvas;

namespace ShapePainter.Painter;

internal class Painter : IPainter
{
    public void DrawPicture(PictureDraft pictureDraft, ICanvas canvas)
    {
        pictureDraft.Shapes.ForEach(shape => shape.Draw(canvas));
    }
}
