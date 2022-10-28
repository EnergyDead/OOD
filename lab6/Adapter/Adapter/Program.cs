using Adapter;

Console.WriteLine("Should we use new API (y)?");
if (Console.ReadKey().Key == ConsoleKey.Y)
{
    Application.PaintPictureOnModernGraphicsRenderer();
}
else
{
    Application.PaintPictureOnCanvas();
}