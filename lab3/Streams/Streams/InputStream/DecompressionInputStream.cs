namespace Streams.InputStream;

public class DecompressionInputStream : IInputStream
{
    private const byte RleMarker = 255;
    private readonly IInputStream _stream;
    private int _byteslength = 0;
    private byte _currentValue;

    public DecompressionInputStream(IInputStream stream)
    {
        _stream = stream;
    }

    public bool IsEof => _byteslength == 0 && _stream.IsEof;

    public int ReadBlock(byte[] buffer, uint count)
    {
        int readSize = 0;

        for (int i = 0; i < count; i++)
        {
            buffer[i] = (byte)ReadByte();
            readSize++;
            if (IsEof && _byteslength == 0)
            {
                break;
            }
        }

        return readSize;
    }

    public int ReadByte()
    {
        if (_byteslength != 0)
        {
            _byteslength--;
            return _currentValue;
        }

        if (IsEof)
        {
            return -1;
        }

        _currentValue = (byte)_stream.ReadByte();
        if (_currentValue != RleMarker)
        {
            return _currentValue;
        }

        if (IsEof)
        {
            throw new ApplicationException($"After rleMarker={RleMarker} can be one or more bytes");
        }

        _currentValue = (byte)_stream.ReadByte();
        if (_currentValue == RleMarker)
        {
            return RleMarker;
        }

        _byteslength = _currentValue + 4;
        if (IsEof)
        {
            throw new ApplicationException($"After length={RleMarker} marker can be one or more bytes");
        }

        _currentValue = (byte)_stream.ReadByte();
        _byteslength--;

        return _currentValue;
    }

    public void Dispose()
    {
        _stream.Dispose();
    }
}
