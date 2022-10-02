using Streams;
using Streams.InputStream;
using Streams.OutputStream;

string _inputFileName;
string _outputFileName;

try
{
    ParseFileNames();
    List<Option> options = ParseOptions();
    if (options.Count > 0 && options.Select(o => o.Type).Distinct().Count() != 1)
    {
        throw new ArgumentException("Arguments should only be input or output parameters");
    }

    IInputStream inputStream = new FileInputStream(_inputFileName);
    IOutputStream outputStream = new FileOutputStream(_outputFileName);
    
    CheackInput(options);
    Decorate(ref inputStream, ref outputStream, options);

    while (!inputStream.IsEof)
    {
        outputStream.WriteByte((byte)inputStream.ReadByte());
    }

    inputStream.Dispose();
    outputStream.Dispose();

}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}


#region helper
List<Option> ParseOptions()
{
    List<Option> result = new();
    int? key = null;
    var optionArgs = args.Take(args.Length - 2).ToArray();

    for (int i = 0; i < optionArgs.Length; i++)
    {
        switch (optionArgs[i])
        {
            case "--encrypt":
                key = optionArgs[i + 1].TryToInt();
                if (key == null)
                {
                    throw new ApplicationException("Invalid command");
                }
                result.Add(new Option(OptionType.output, "--encrypt", key));
                i++;
                break;
            case "--decrypt":
                key = optionArgs[i + 1].TryToInt();
                if (key == null)
                {
                    throw new ApplicationException("Invalid command");
                }
                result.Add(new Option(OptionType.input, "--decrypt", key));
                i++;
                break;
            case "--compress":
                result.Add(new Option(OptionType.output, "--compress"));
                break;
            case "--decompress":
                result.Add(new Option(OptionType.input, "--decompress"));
                break;
            default:
                throw new ApplicationException("Invalid command");
        }
    }
    return result;
}

void ParseFileNames()
{
    int length = args.Length;
    if (length < 2)
    {
        throw new ApplicationException("Arguments can`t less 2");
    }

    _outputFileName = args[length - 1];
    _inputFileName = args[length - 2];
}

void Decorate(ref IInputStream inputStream, ref IOutputStream outputStream, List<Option> options)
{
    foreach (var option in options)
    {
        switch (option.Argument)
        {
            case "--encrypt":
                outputStream = new EncodingOutputStream(outputStream, option.Key!.Value);
                break;
            case "--decrypt":
                inputStream = new DecodingInputStream(inputStream, option.Key!.Value);
                break;
            case "--compress":
                outputStream = new CompressionOutputStream(outputStream);
                break;
            case "--decompress":
                inputStream = new DecompressionInputStream(inputStream);
                break;
            default:
                break;
        }
    }
}

void CheackInput(List<Option> options)
{
    if (options.Count > 0 && options.First().Type == OptionType.input)
    {
        options.Reverse();
    }
}
#endregion