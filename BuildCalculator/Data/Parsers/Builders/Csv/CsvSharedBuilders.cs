using BuildCalculator.Data.Parsers;

namespace BuildCalculator.Data.Parsers.Builders.Csv;

public static class CsvSharedBuilders
{
    public static (T Id, string Text) BuildIdAndText<T>(ReadOnlySpan<char> items) where T : ISpanParsable<T>
    {
        var id = T.Parse(CsvParser.Slice(ref items), null);
        var text = CsvParser.Slice(ref items).ToString().Replace("\\n", "\n");

        return (id, text);
    }
}

