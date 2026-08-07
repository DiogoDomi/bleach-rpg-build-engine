using BuildCalculator.Core;

namespace BuildCalculator.Data.Parsers.Loaders.Csv;

public static class CsvSharedLoaders
{
    public static IReadOnlyDictionary<TKey, TValue> LoadSingleDomainData<TKey, TValue>(
            TextReader reader,
            DomainBuilder<TKey, TValue> builder) where TKey : notnull
    {
        List<(TKey Id, TValue Item)> domainItems = new();

        CsvParser.Parse(reader,
                items => domainItems.Add(builder(items)));

        return domainItems.ToDictionary(x => x.Id, x => x.Item);
    }

    public static IReadOnlyDictionary<TKey, TValue[]> LoadManyDomainData<TKey, TValue>(
            TextReader reader,
            DomainBuilder<TKey, TValue> builder) where TKey : notnull
    {
        List<(TKey Id, TValue Item)> domainItems = new();

        CsvParser.Parse(reader,
                items => domainItems.Add(builder(items)));

        return domainItems
            .GroupBy(x => x.Id)
            .ToDictionary(
                    g => g.Key,
                    g => g.Select(t => t.Item).ToArray());
    }

    public static ResultData<T> ExecuteLoader<T>(
                string csvDirPath,
                string csvFileName,
                Func<TextReader, T> loader)
    {
        var fileReader = CsvParser.GetFileReader(csvDirPath, csvFileName);

        if (!fileReader.IsSuccess)
            return ResultData<T>.Fail(fileReader.Error, fileReader.Message);

        using (fileReader.Item)
        {
            var result = loader(fileReader.Item);
            return ResultData<T>.Ok(result);
        }
    }

    public delegate (TKey DomainKey, TValue DomainValue) DomainBuilder<TKey, TValue>(ReadOnlySpan<char> items);
}

