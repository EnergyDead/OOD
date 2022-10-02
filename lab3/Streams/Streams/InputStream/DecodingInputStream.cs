namespace Streams.InputStream;

public class DecodingInputStream : IInputStream
{
    private readonly IInputStream _stream;
    private readonly byte[] _decodingBytes;
    public bool IsEof => _stream.IsEof;

    public DecodingInputStream(IInputStream inputStream, int key)
    {
        _stream = inputStream;
        _decodingBytes = ByteShuffle.GetDecodingBytes(key);
    }

    public void Dispose()
    {
        _stream.Dispose();
    }

    public int ReadBlock(byte[] buffer, uint count)
    {
        int readSize = _stream.ReadBlock(buffer, count);

        for (int i = 0; i < readSize; i++)
        {
            buffer[i] = _decodingBytes[buffer[i]];
        }

        return readSize;
    }

    public int ReadByte()
    {
        int value = _stream.ReadByte();
        return value != -1 ? _decodingBytes[value] : -1;
    }
}
