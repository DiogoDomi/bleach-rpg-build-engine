using BuildCalculator.Data.Parsers;
using BuildCalculator.Data.Dtos;

namespace BuildCalculator.Data.Parsers.Builders.Csv;

public static class CsvWeaponStampBuilder
{
    public static (ushort Id, WeaponStampDto Dto) BuildWeaponStampDto(ReadOnlySpan<char> items)
    {
        var id = ushort.Parse(CsvParser.Slice(ref items));
        var weaponStampNameId = ushort.Parse(CsvParser.Slice(ref items));
        ushort? exclusiveEffectCharacterId = ushort.TryParse(CsvParser.Slice(ref items), out var value)
            ? value
            : null;
        var rarityId = byte.Parse(CsvParser.Slice(ref items));
        var statsMultiplierValue = byte.Parse(CsvParser.Slice(ref items));
        var displayOrder = ushort.Parse(CsvParser.Slice(ref items));

        return (id, new WeaponStampDto(
            exclusiveEffectCharacterId,
            id,
            weaponStampNameId,
            displayOrder,
            rarityId,
            statsMultiplierValue
        ));
    }
}

