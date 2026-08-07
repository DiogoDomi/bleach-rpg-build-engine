using BuildCalculator.Data.Parsers;
using BuildCalculator.Data.Dtos;

namespace BuildCalculator.Data.Parsers.Builders.Csv;

public static class CsvGameConfigBuilder
{
    public static (byte Id, CharacterMaxUpgradeCostDto Dto) BuildCharacterMaxUpgradeCostDto(ReadOnlySpan<char> items)
    {
        var id = byte.Parse(CsvParser.Slice(ref items));
        var rarityId = byte.Parse(CsvParser.Slice(ref items));

        byte? characterRoleId = byte.TryParse(CsvParser.Slice(ref items), out var role)
            ? role
            : null;
        byte? characterAffinityId = byte.TryParse(CsvParser.Slice(ref items), out var affinity)
            ? affinity
            : null;

        var itemId = byte.Parse(CsvParser.Slice(ref items));
        var amount = uint.Parse(CsvParser.Slice(ref items));


        return (id, new CharacterMaxUpgradeCostDto(
            amount,
            characterRoleId,
            characterAffinityId,
            id,
            rarityId,
            itemId
        ));
    }

    public static (byte Id, LimitedGachaGuaranteedPullCostDto Dto) BuildLimitedGachaGuaranteedPullCostDto(
            ReadOnlySpan<char> items)
    {
        var entityTypeId = byte.Parse(CsvParser.Slice(ref items));
        var itemId = byte.Parse(CsvParser.Slice(ref items));
        var amount = ushort.Parse(CsvParser.Slice(ref items));

        return (entityTypeId, new LimitedGachaGuaranteedPullCostDto(
            amount,
            entityTypeId,
            itemId
        ));
    }

    public static (byte Id, GameLevelConfigDto Dto) BuildGameLevelConfigDto(ReadOnlySpan<char> items)
    {
        var id = byte.Parse(CsvParser.Slice(ref items));
        var entityTypeId = byte.Parse(CsvParser.Slice(ref items));
        byte? rarityId = byte.TryParse(CsvParser.Slice(ref items), out var rarity)
            ? rarity
            : null;
        byte? starRatingId = byte.TryParse(CsvParser.Slice(ref items), out var rating)
            ? rating
            : null;
        byte? skillSubcategoryId = byte.TryParse(CsvParser.Slice(ref items), out var subcategory)
            ? subcategory
            : null;
        byte? minLevel = byte.TryParse(CsvParser.Slice(ref items), out var minLvl)
            ? minLvl
            : null;
        byte? maxLevel = byte.TryParse(CsvParser.Slice(ref items), out var maxLvl)
            ? maxLvl
            : null;
        byte? minAscensionLevel = byte.TryParse(CsvParser.Slice(ref items), out var minAsc)
            ? minAsc
            : null;
        byte? maxAscensionLevel = byte.TryParse(CsvParser.Slice(ref items), out var maxAsc)
            ? maxAsc
            : null;

        return (id, new GameLevelConfigDto(
            rarityId,
            starRatingId,
            skillSubcategoryId,
            minLevel,
            maxLevel,
            minAscensionLevel,
            maxAscensionLevel,
            id,
            entityTypeId
        ));
    }
}

