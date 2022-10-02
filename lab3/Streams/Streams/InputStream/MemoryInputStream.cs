namespace Streams.InputStream;

public class MemoryInputStream : IInputStream
{
    private readonly MemoryStream _stream;
    public MemoryInputStream(byte[] bytes)
    {
        _stream = new MemoryStream(bytes);
    }
    public bool IsEof => _stream.Position >= _stream.Length;


    public int ReadBlock(byte[] buffer, uint count)
    {
        return _stream.Read(buffer, 0, (int)count);
    }

    public int ReadByte()
    {
        return _stream.ReadByte();
    }

    public void Dispose()
    {
        _stream.Dispose();
    }
}
