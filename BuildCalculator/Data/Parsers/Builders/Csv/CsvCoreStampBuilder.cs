using BuildCalculator.Data.Parsers;
using BuildCalculator.Data.Dtos;

namespace BuildCalculator.Data.Parsers.Builders.Csv;

public static class CsvCoreStampBuilder
{
    public static (ushort CoreStampId, CoreStampDto Dto) BuildCoreStampDto(ReadOnlySpan<char> items)
    {
        var coreStampId = ushort.Parse(CsvParser.Slice(ref items));
        var coreStampNameId = ushort.Parse(CsvParser.Slice(ref items));
        ushort? exclusiveEffectCharacterId = ushort.TryParse(CsvParser.Slice(ref items), out var value)
            ? value
            : null;
        var rarityId = byte.Parse(CsvParser.Slice(ref items));
        var starRatingId = byte.Parse(CsvParser.Slice(ref items));
        var displayOrder = ushort.Parse(CsvParser.Slice(ref items));

        return (coreStampId, new CoreStampDto(
            exclusiveEffectCharacterId,
            coreStampId,
            coreStampNameId,
            displayOrder,
            rarityId,
            starRatingId));
    }

    public static (ushort CoreStampId, CoreStampBaseStatDto Dto) BuildBaseStatDto(ReadOnlySpan<char> items)
    {
        var coreStampId = ushort.Parse(CsvParser.Slice(ref items));
        var statTypeId = byte.Parse(CsvParser.Slice(ref items));
        var minBaseValue = float.Parse(CsvParser.Slice(ref items));
        var maxBaseValue = float.Parse(CsvParser.Slice(ref items));

        return (coreStampId, new CoreStampBaseStatDto(
            minBaseValue,
            maxBaseValue,
            coreStampId,
            statTypeId));
    }
}

