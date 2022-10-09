using ShapePainter.Canvas;

namespace ShapePainter.Painter;

internal class Painter : IPainter
{
    public void DrawPicture(PictureDraft pictureDraft, ICanvas canvas)
    {
        foreach (var shape in pictureDraft.Shapes)
        {
            try
            {
                shape.Draw(canvas);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error draw {shape.GetType()}. {ex.Message}");
            }
        }
    }
}
