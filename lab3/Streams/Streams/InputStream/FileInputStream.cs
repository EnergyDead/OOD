namespace Streams.InputStream;

public class FileInputStream : IInputStream
{
    private readonly FileStream _stream;

    public FileInputStream(string fileName)
    {
        _stream = new FileStream(fileName, FileMode.Open);
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
