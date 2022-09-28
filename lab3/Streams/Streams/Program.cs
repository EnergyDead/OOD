using Streams.InputStream;
using Streams.OutputStream;

IInputStream inputStream = new FileInputStream("Streams1.exe");
IOutputStream outputStream = new FileOutputStream("test.exe");

while(!inputStream.IsEof)
{
    outputStream.WriteByte( (byte)inputStream.ReadByte() );
}

inputStream.Dispose();
outputStream.Dispose();