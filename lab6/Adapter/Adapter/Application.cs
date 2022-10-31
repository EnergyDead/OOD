using Adapter.Adapter;
using Adapter.GraphicsLib;
using Adapter.ModernGrapicsLib;
using Adapter.ShapeDrawingLib;

namespace Adapter;

internal static class Application
{
    private static void PaintPicture(CanvasPainter painter)
    {
        Triangle triangle = new(new(10, 15), new(100, 200), new(150, 200), 0xAAAAAA);
        Rectangle rectangle = new(new(30, 40), 18, 24, 0xFF3300);
        
        painter.Draw(triangle);
        painter.Draw(rectangle);
    }

    public static void PaintPictureOnModernGraphicsRenderer()
    {
        ModernGraphicsRenderer renderer = new (Console.Out);
        ModernGrapicsObjectAdapter objectAdapter = new (renderer);
        CanvasPainter painter = new(objectAdapter);

        // todo использовать у ModernGraphicsRenderer
        renderer.BeginDraw();
        PaintPicture(painter);
        renderer.EndDraw();
    }

    public static void PaintPictureOnModernGraphicsRendererWithClassAdapter()
    {
        ModernGrapicsClassAdapter modernGrapicsClassAdapter = new (Console.Out);
        CanvasPainter painter = new (modernGrapicsClassAdapter);

        modernGrapicsClassAdapter.BeginDraw();
        PaintPicture(painter);
        modernGrapicsClassAdapter.EndDraw();
    }

    public static void PaintPictureOnCanvas()
    {
        ICanvas canvas = new Canvas();
        CanvasPainter painter = new(canvas);

        PaintPicture(painter);
    }
}
