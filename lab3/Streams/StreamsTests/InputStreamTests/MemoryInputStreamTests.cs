using Streams.InputStream;
using Xunit;

namespace StreamsTests.InputStreamTests;

public class MemoryInputStreamTests
{
    [Fact]
    public void ReadEndOfStream()
    {
        IInputStream inputStream = new MemoryInputStream(new byte[0]);

        var result = inputStream.ReadByte();
        inputStream.Dispose();

        Assert.True(-1 == result, "The returned code is equal to EndOfStream");
    }

    [Fact]
    public void ReadByteInDataFile()
    {
        IInputStream inputStream = new MemoryInputStream(new byte[1] { 0x32 });

        var result = inputStream.ReadByte();
        inputStream.Dispose();

        Assert.Equal(0x32, result);
    }

    [Fact]
    public void ReadBlockInDataFile()
    {
        var buffer = new byte[4] { 0x32, 0x39, 0x30, 0x37 };
        IInputStream inputStream = new MemoryInputStream(buffer);
        byte[] resultBuffer = new byte[4];

        var result = inputStream.ReadBlock(resultBuffer, 4);
        inputStream.Dispose();

        Assert.Equal(buffer, resultBuffer);
        Assert.Equal(4, result);
    }
}
