using Streams.OutputStream;
using System.Linq;
using Xunit;

namespace StreamsTests.OutputStreamTests;

public class MemoryOutputStreamTests
{
    [Fact]
    public void WriteByte()
    {
        byte[] buffer = new byte[1];
        IOutputStream stream = new MemoryOutputStream(buffer);

        stream.WriteByte(1);
        stream.Dispose();

        Assert.True(buffer.SequenceEqual(new byte[1] { 1 }));
    }

    [Fact]
    public void WritePartBytesInArray()
    {
        byte[] buffer = new byte[2];
        IOutputStream stream = new MemoryOutputStream(buffer);

        stream.WriteBlock(new byte[3] { 3, 3, 3 }, 2);
        stream.Dispose();

        Assert.True(buffer.SequenceEqual(new byte[2] { 3, 3 }));
    }

    [Fact]
    public void WriteBytes()
    {
        byte[] buffer = new byte[3];
        IOutputStream stream = new MemoryOutputStream(buffer);

        stream.WriteBlock(new byte[3] { 3, 3, 3 }, 3);
        stream.Dispose();

        Assert.True(buffer.SequenceEqual(new byte[3] { 3, 3, 3 }));
    }
}
