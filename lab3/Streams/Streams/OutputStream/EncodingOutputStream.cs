namespace Streams.OutputStream;

public class EncodingOutputStream : IOutputStream
{
    private readonly IOutputStream _stream;
    private readonly byte[] _encodingBytes;


    public EncodingOutputStream(IOutputStream stream, int key)
    {
        _stream = stream;
        _encodingBytes = ByteShuffle.GetEncodingBytes(key);
    }

    public void Dispose()
    {
        _stream.Dispose();
    }

    public void WriteBlock(byte[] data, uint size)
    {
        var encodedData = new byte[size];
        for (int i = 0; i < size; i++)
        {
            encodedData[i] = _encodingBytes[data[i]];
        }

        _stream.WriteBlock(encodedData, size);
    }

    public void WriteByte(byte data)
    {
        _stream.WriteByte(_encodingBytes[data]);
    }
}
