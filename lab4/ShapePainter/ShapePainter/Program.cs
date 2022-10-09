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