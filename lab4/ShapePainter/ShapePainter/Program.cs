using ShapePainter;
using ShapePainter.Canvas;
using ShapePainter.Designer;
using ShapePainter.Painter;
using ShapePainter.Shape;
using System.Drawing;

IPainter painter = new Painter();
IDesigner designer = new Designer(new ShapeFactory());
ICanvas canvas = new Canvas();

var client = new Client(canvas, designer, painter);
client.Run();

return;

Image img = new Bitmap(1000, 1000);
Graphics graphics = Graphics.FromImage(img);
Pen pen = new Pen(Color.Red);
graphics.DrawLine(pen, new Point(50, 50), new Point(100, 100));
img.Save("123.png");