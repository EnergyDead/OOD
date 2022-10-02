using System.Linq;
using Streams.OutputStream;
using Xunit;

namespace StreamsTests.OutputStreamTests;

public class СompressionOutputStreamTest
{
    [Fact]
    public void WriteByte_WriteManyEqualsBytes_WriteCompressed()
    {
        var result = new byte[3];
        IOutputStream compressionStream = new CompressionOutputStream(new MemoryOutputStream(result));
        var expectedData = new byte[] { 255, 6, 1 };

        for (int i = 0; i < 10; i++)
        {
            compressionStream.WriteByte(1);
        }
        compressionStream.Dispose();

        Assert.True(result.SequenceEqual(expectedData));
    }

    [Fact]
    public void WriteByte_WriteManyNotEqualsBytes_WriteUncompressed()
    {
        var result = new byte[6];
        IOutputStream compressionStream = new CompressionOutputStream(new MemoryOutputStream(result));
        var expectedData = new byte[] { 0, 1, 2, 3, 4, 5 };

        for (int i = 0; i < 6; i++)
        {
            compressionStream.WriteByte((byte)i);
        }
        compressionStream.Dispose();

        Assert.True(result.SequenceEqual(expectedData));
    }

    [Fact]
    public void WriteByte_WriteBytesWithMarker_WriteCompressed()
    {
        var result = new byte[5];
        IOutputStream compressionStream = new CompressionOutputStream(new MemoryOutputStream(result));
        var expectedData = new byte[] { 255, 255, 255, 6, 1 };

        compressionStream.WriteByte(255);
        for (int i = 0; i < 10; i++)
        {
            compressionStream.WriteByte(1);
        }
        compressionStream.Dispose();

        Assert.True(result.SequenceEqual(expectedData));
    }

    [Fact]
    public void WriteByte_WriteEqualBytesMoreThanCompressionLength_WriteCompressed()
    {
        var result = new byte[6];
        IOutputStream compressionStream = new CompressionOutputStream(new MemoryOutputStream(result));
        var expectedData = new byte[] { 255, 254, 1, 255, 38, 1 };

        for (int i = 0; i < 300; i++)
        {
            compressionStream.WriteByte(1);
        }
        compressionStream.Dispose();

        Assert.True(result.SequenceEqual(expectedData));
    }

    [Fact]
    public void WriteByte_WriteManyEqualsAndNotEqualsBytes_WritePartCompressedAndPartUncompressed()
    {
        var result = new byte[6];
        IOutputStream compressionStream = new CompressionOutputStream(new MemoryOutputStream(result));
        var expectedData = new byte[] { 0, 1, 2, 255, 0, 1 };

        for (int i = 0; i < 3; i++)
        {
            compressionStream.WriteByte((byte)i);
        }
        for (int i = 0; i < 4; i++)
        {
            compressionStream.WriteByte(1);
        }
        compressionStream.Dispose();

        Assert.True(result.SequenceEqual(expectedData));
    }

    [Fact]
    public void WriteBlock_WriteManyEqualsBytes_WriteCompressed()
    {
        var result = new byte[6];
        IOutputStream compressionStream = new CompressionOutputStream(new MemoryOutputStream(result));
        var inputData = new byte[] { 1, 1, 1, 1, 2, 2, 2, 2, 2 };
        var expectedData = new byte[] { 255, 0, 1, 255, 1, 2 };

        compressionStream.WriteBlock(inputData, (uint)inputData.Length);
        compressionStream.Dispose();

        Assert.True(result.SequenceEqual(expectedData));
    }
}
