namespace Streams;

public static class ByteShuffle
{
    public static byte[] GetEncodingBytes(int key)
    {
        byte[] shuffledBytes = new byte[256];
        for (int i = 0; i < shuffledBytes.Length; i++)
        {
            shuffledBytes[i] = (byte)i;
        }
        shuffledBytes.Shuffle(key);

        return shuffledBytes;
    }

    public static byte[] GetDecodingBytes(int key)
    {
        byte[] encodingShuffledBytes = GetEncodingBytes(key);

        byte[] decodingShuffledBytes = new byte[256];
        for (int i = 0; i < decodingShuffledBytes.Length; i++)
        {
            decodingShuffledBytes[encodingShuffledBytes[i]] = (byte)i;
        }

        return decodingShuffledBytes;
    }

    private static void Shuffle(this IList<byte> list, int key)
    {
        Random random = new(key);
        int maxRandomValue = list.Count;
        while (maxRandomValue > 1)
        {
            maxRandomValue--;
            int i = random.Next(maxRandomValue + 1);
            (list[maxRandomValue], list[i]) = (list[i], list[maxRandomValue]);
        }
    }
}
