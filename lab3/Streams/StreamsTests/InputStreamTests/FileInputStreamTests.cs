using Streams.InputStream;
using Xunit;

namespace StreamsTests.InputStreamTests;

public class FileInputStreamTests
{
    private const string TestFilesPath = "../../../InputStreamTests/TestFiles";

    [Fact]
    public void ReadEmptyFile()
    {
        string filePath = $"{TestFilesPath}/EmptyFile.txt";
        IInputStream inputStream = new FileInputStream(filePath);

        var result = inputStream.ReadByte();
        inputStream.Dispose();

        Assert.True(-1 == result, "The returned code is equal to EndFile");
    }

    [Fact]
    public void ReadByteInDataFile()
    {
        string filePath = $"{TestFilesPath}/DataFile.txt";
        IInputStream inputStream = new FileInputStream(filePath);

        var result = inputStream.ReadByte();
        inputStream.Dispose();

        Assert.True(0x32 == result, "The symbol `2` is equal to the code 32");
    }

    [Fact]
    public void ReadBlockInDataFile()
    {
        string filePath = $"{TestFilesPath}/DataFile.txt";
        IInputStream inputStream = new FileInputStream(filePath);
        byte[] buffer = new byte[4];

        var result = inputStream.ReadBlock(buffer, 4);
        inputStream.Dispose();

        Assert.Equal(new byte[4] { 0x32, 0x39, 0x30, 0x37 }, buffer);
        Assert.Equal(4, result);
    }
}
