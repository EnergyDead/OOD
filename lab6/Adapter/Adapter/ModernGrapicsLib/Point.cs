namespace Adapter.ModernGrapicsLib;

public class Point
{
    public Point(int v1, int v2)
    {
        X = v1;
        Y = v2;
    }

    public int X { get; private set; }
    public int Y { get; private set; }
}
