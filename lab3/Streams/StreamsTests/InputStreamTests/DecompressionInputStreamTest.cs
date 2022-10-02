using System.Linq;
using Streams.InputStream;
using Xunit;

namespace StreamsTests.InputStreamTests;

public class DecompressionInputStreamTest
{
    [Fact]
    public void ReadByte_ReadSingleByte_ReadCorrect()
    {
        var data = new byte[] { 1, 2 };
        IInputStream decompressionStream = new DecompressionInputStream(new MemoryInputStream(data));

        int result = decompressionStream.ReadByte();
        decompressionStream.Dispose();

        Assert.Equal(1, result);
    }

    [Fact]
    public void ReadByte_ReadFromCompressedByte_ReadCorrect()
    {
        var data = new byte[] { 255, 3, 4 };
        IInputStream decompressionStream = new DecompressionInputStream(new MemoryInputStream(data));

        int result = decompressionStream.ReadByte();
        decompressionStream.Dispose();

        Assert.Equal(4, result);
    }

    [Fact]
    public void ReadByte_ReadBytesEqualsMarker_ReadCorrect()
    {
        var data = new byte[] { 255, 255 };
        IInputStream decompressionStream = new DecompressionInputStream(new MemoryInputStream(data));

        int result = decompressionStream.ReadByte();
        decompressionStream.Dispose();

        Assert.Equal(255, result);
    }

    [Fact]
    public void ReadBlock_ReadFromCompressedByte_ReadCorrect()
    {
        var data = new byte[] { 255, 3, 4 };
        IInputStream decompressionStream = new DecompressionInputStream(new MemoryInputStream(data));
        var buffer = new byte[7];
        var expectedData = new byte[] { 4, 4, 4, 4, 4, 4, 4 };

        int readSize = decompressionStream.ReadBlock(buffer, 7);
        decompressionStream.Dispose();

        Assert.Equal(7, readSize);
        Assert.True(buffer.SequenceEqual(expectedData));
    }

    [Fact]
    public void ReadBlock_ReadFromCompressedBytes_ReadCorrect()
    {
        var data = new byte[] { 255, 254, 1, 255, 26, 1 };
        IInputStream decompressionStream = new DecompressionInputStream(new MemoryInputStream(data));
        var buffer = new byte[288];
        var expectedData = new byte[288];
        for (int i = 0; i < 288; i++)
        {
            expectedData[i] = 1;
        }

        int readSize = decompressionStream.ReadBlock(buffer, 288);
        decompressionStream.Dispose();

        Assert.Equal(288, readSize);
        Assert.True(buffer.SequenceEqual(expectedData));
    }
}
