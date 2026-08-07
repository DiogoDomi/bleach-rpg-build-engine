using BuildCalculator.Data.Parsers;
using BuildCalculator.Data.Dtos;

namespace BuildCalculator.Data.Parsers.Builders.Csv;

public static class CsvSetStampBuilder
{
    public static (ushort SetStampId, SetStampDto Dto) BuildSetStampDto(ReadOnlySpan<char> items)
    {
        var id = ushort.Parse(CsvParser.Slice(ref items));
        var setStampNameId = ushort.Parse(CsvParser.Slice(ref items));
        var displayOrder = ushort.Parse(CsvParser.Slice(ref items));

        return (id, new SetStampDto(
            id,
            setStampNameId,
            displayOrder));
    }

    public static (byte PassiveId, SetStampPassiveDto Dto) BuildPassiveDto(ReadOnlySpan<char> items)
    {
        var id = byte.Parse(CsvParser.Slice(ref items));
        var setStampPassiveNameId = byte.Parse(CsvParser.Slice(ref items));
        var passiveLevel = byte.Parse(CsvParser.Slice(ref items));

        return (id, new SetStampPassiveDto(
            id,
            setStampPassiveNameId,
            passiveLevel));
    }

    public static (byte StarRatingId, SetStampLevelGapDto Dto) BuildLevelGapDto(ReadOnlySpan<char> items)
    {
        var starRatingId = byte.Parse(CsvParser.Slice(ref items));
        var ascensionLevel = byte.Parse(CsvParser.Slice(ref items));
        var maxEnhanceLevel = byte.Parse(CsvParser.Slice(ref items));

        return (starRatingId, new SetStampLevelGapDto(
            starRatingId,
            ascensionLevel,
            maxEnhanceLevel));
    }

    public static (byte PieceIndexId, byte StatTypeId) BuildFixedBasicStat(ReadOnlySpan<char> items)
    {
        var pieceIndex = byte.Parse(CsvParser.Slice(ref items));
        var statTypeId = byte.Parse(CsvParser.Slice(ref items));

        return (pieceIndex, statTypeId);
    }

    public static (byte PieceIndexId, byte StatTypeId) BuildPoolBasicStat(ReadOnlySpan<char> items)
    {
        var pieceIndex = byte.Parse(CsvParser.Slice(ref items));
        var statTypeId = byte.Parse(CsvParser.Slice(ref items));

        return (pieceIndex, statTypeId);
    }

    public static (byte PieceIndexId, SetStampFixedBasicStatGrowthDto Dto) BuildFixedBasicStatGrowthDto(ReadOnlySpan<char> items)
    {
        var pieceIndex = byte.Parse(CsvParser.Slice(ref items));
        var starRatingId = byte.Parse(CsvParser.Slice(ref items));
        var minBaseValue = ushort.Parse(CsvParser.Slice(ref items));
        var maxBaseValue = ushort.Parse(CsvParser.Slice(ref items));

        return (pieceIndex, new SetStampFixedBasicStatGrowthDto(
            minBaseValue,
            maxBaseValue,
            pieceIndex,
            starRatingId));
    }

    public static (byte StarRatingId, SetStampPoolBasicStatGrowthDto Dto) BuildPoolBasicStatGrowthDto(ReadOnlySpan<char> items)
    {
        var starRatingId = byte.Parse(CsvParser.Slice(ref items));
        var statTypeId = byte.Parse(CsvParser.Slice(ref items));
        var minBaseValue = float.Parse(CsvParser.Slice(ref items));
        var maxBaseValue = float.Parse(CsvParser.Slice(ref items));

        return (starRatingId, new SetStampPoolBasicStatGrowthDto(
            minBaseValue,
            maxBaseValue,
            starRatingId,
            statTypeId));
    }

    public static (byte StarRatingId, SetStampPoolAdvancedStatGrowthDto Dto) BuildPoolAdvancedStatGrowthDto(ReadOnlySpan<char> items)
    {
        var starRatingId = byte.Parse(CsvParser.Slice(ref items));
        var statTypeId = byte.Parse(CsvParser.Slice(ref items));
        var minBaseValue = float.Parse(CsvParser.Slice(ref items));
        float? maxBaseValue = float.TryParse(CsvParser.Slice(ref items), out var value)
            ? value
            : null;

        return (starRatingId, new SetStampPoolAdvancedStatGrowthDto(
            maxBaseValue,
            minBaseValue,
            starRatingId,
            statTypeId));
    }
}

