namespace Streams.OutputStream;

public class MemoryOutputStream : IOutputStream
{
    private readonly MemoryStream _stream;

    public MemoryOutputStream(byte[] bytes)
    {
        _stream = new MemoryStream(bytes);
    }


    public void WriteBlock(byte[] data, uint size)
    {
        _stream.Write(data, 0, (int)size);
    }

    public void WriteByte(byte data)
    {
        _stream.WriteByte(data);
    }

    public void Dispose()
    {
        _stream.Dispose();
    }
}
