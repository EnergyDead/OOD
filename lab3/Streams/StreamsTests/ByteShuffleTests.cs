using Streams;
using System;
using Xunit;

namespace StreamsTests.ByteShuffleTests;

public class ByteShuffleTests
{
    [Fact]
    public void EncodeDecodeBytes()
    {
        int key = new Random().Next();
        byte[] encode = ByteShuffle.GetEncodingBytes(key);
        byte[] decode = ByteShuffle.GetDecodingBytes(key);

        for (int i = 0; i < 256; i++)
        {
            if (i != decode[encode[i]])
            {
                Assert.True(false, "Cent get original byte.");
            }
        }
    }
}
