namespace Streams;

public static class Utils
{

   public static int? TryToInt(this string data)
    {
        if (int.TryParse(data, out int result))
        {
            return result;
        }

        return null;
    }
}
