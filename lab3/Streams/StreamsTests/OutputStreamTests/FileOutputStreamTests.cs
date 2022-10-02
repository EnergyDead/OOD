using Streams.OutputStream;
using System;
using System.IO;
using System.Linq;
using Xunit;

namespace StreamsTests.OutputStreamTests;

public class FileOutputStreamTests
{
    private static string GuidFileName => $"{Path.GetTempPath()}{Guid.NewGuid()}.txt";

    [Fact]
    public void WriteByte()
    {
        string fileName = GuidFileName;
        IOutputStream stream = new FileOutputStream(fileName);
        byte data = 5;

        stream.WriteByte(data);
        stream.Dispose();

        Assert.True(IsEquals(new[] { data }, fileName));
    }

    [Fact]
    public void WritePartBytesInArray()
    {
        string fileName = GuidFileName;
        IOutputStream stream = new FileOutputStream(fileName);
        byte[] data = new byte[3] { 3, 3, 3 };

        stream.WriteBlock(data, 2);
        stream.Dispose();

        Assert.True(IsEquals(new byte[2] { 3, 3 }, fileName));
    }

    [Fact]
    public void WriteBytes()
    {
        string fileName = GuidFileName;
        IOutputStream stream = new FileOutputStream(fileName);
        byte[] data = new byte[3] { 3, 3, 3 };

        stream.WriteBlock(data, 3);
        stream.Dispose();

        Assert.True(IsEquals(data, fileName));
    }

    private static bool IsEquals(byte[] data, string fileName)
    {
        return File.ReadAllBytes(fileName).SequenceEqual(data);
    }
}
