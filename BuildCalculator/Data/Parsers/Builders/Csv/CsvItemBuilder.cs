using BuildCalculator.Data.Parsers;
using BuildCalculator.Data.Dtos;

namespace BuildCalculator.Data.Parsers.Builders.Csv;

public static class CsvItemBuilder
{
    public static (byte ItemId, ItemDto Dto) BuildItemDto(ReadOnlySpan<char> items)
    {
        var id = byte.Parse(CsvParser.Slice(ref items));
        var itemNameId = byte.Parse(CsvParser.Slice(ref items));
        var itemCategoryId = byte.Parse(CsvParser.Slice(ref items));
        var itemTypeId = byte.Parse(CsvParser.Slice(ref items));

        return (id, new ItemDto(
            id,
            itemNameId,
            itemCategoryId,
            itemTypeId
        ));
    }
}

