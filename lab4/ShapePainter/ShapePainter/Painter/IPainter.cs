using ShapePainter.Canvas;

namespace ShapePainter
{
    internal interface IPainter
    {
        void DrawPicture(PictureDraft pictureDraft, ICanvas canvas);
    }
}
