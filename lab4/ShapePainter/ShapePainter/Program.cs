using ShapePainter;
using ShapePainter.Canvas;
using ShapePainter.Designer;
using ShapePainter.Painter;

IPainter painter = new Painter();
IDesigner designer = new Designer();
ICanvas canvas = new Canvas();

var client = new Client(canvas, designer, painter);
client.Run();