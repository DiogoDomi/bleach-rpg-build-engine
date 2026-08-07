using BuildCalculator.Core;

namespace BuildCalculator.Data.Parsers;

public static class CsvParser
{
    public static ResultData<TextReader> CreateFileReader(string filePath)
    {
        if (!File.Exists(filePath))
            return ResultData<TextReader>.Fail(ResultError.Failed, "File not found.");

        StreamReader reader = new(filePath);

        return ResultData<TextReader>.Ok(reader);
    }

    public static ResultData<TextReader> GetFileReader(string csvDirPath, string csvFileName)
    {
        var filePath = Path.Combine(csvDirPath, csvFileName);

        return CsvParser.CreateFileReader(filePath);
    }

    public static void Parse(TextReader reader, ProcessSpan builder)
    {
        if (reader.ReadLine() == null)
            return;

        while (reader.ReadLine() is { } line)
        {
            builder(line.AsSpan());
        }
    }

    public static ReadOnlySpan<char> Slice(ref ReadOnlySpan<char> line)
    {
        var commaIndex = -1;
        bool inQuotes = false;

        for (var i = 0; i < line.Length; i++)
        {
            if (line[i] == '"')
            {
                inQuotes = !inQuotes;
            }
            else if (line[i] == ',' && !inQuotes)
            {
                commaIndex = i;
                break;
            }
        }

        var piece = ReadOnlySpan<char>.Empty;

        if (commaIndex != -1)
        {
            piece = line.Slice(0, commaIndex);
            line = line.Slice(commaIndex + 1);

        } else
        {
            piece = line;
            line = ReadOnlySpan<char>.Empty;
        }

        return piece.Trim("\"' ");
    }

    public delegate void ProcessSpan(ReadOnlySpan<char> span);
}

