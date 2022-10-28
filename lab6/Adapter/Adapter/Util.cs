namespace Adapter;

public static class Util
{
    /// <summary>
    /// Returns a float value between 0 and 1
    /// </summary>
    /// <param name="b"></param>
    /// <returns></returns>
    public static float ToFloat(this byte b)
    {
        return (float)b / 255;
    }
}