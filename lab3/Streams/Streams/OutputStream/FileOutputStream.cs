namespace Streams.OutputStream;

public class FileOutputStream : IOutputStream
{
    private readonly FileStream _stream;

    public FileOutputStream(string fileName)
    {
        _stream = new FileStream(fileName, FileMode.Create);
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
