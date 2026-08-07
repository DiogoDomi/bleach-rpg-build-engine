using BuildCalculator.Data.Parsers;
using BuildCalculator.Data.Dtos;

namespace BuildCalculator.Data.Parsers.Builders.Csv;

public static class CsvWeaponBuilder
{
    public static (ushort CharacterId, WeaponDto Dto) BuildWeaponDto(ReadOnlySpan<char> items)
    {
        var characterId = ushort.Parse(CsvParser.Slice(ref items));
        var weaponNameId = ushort.Parse(CsvParser.Slice(ref items));
        var weaponTypeId = byte.Parse(CsvParser.Slice(ref items));
        var rarityId = byte.Parse(CsvParser.Slice(ref items));

        return (characterId, new WeaponDto(
            characterId,
            weaponNameId,
            weaponTypeId,
            rarityId
        ));
    }

    public static (ushort CharacterId, WeaponBaseStatDto Dto) BuildBaseStatDto(ReadOnlySpan<char> items)
    {
        var characterId = ushort.Parse(CsvParser.Slice(ref items));
        var statTypeId = byte.Parse(CsvParser.Slice(ref items));
        var minBaseValue = ushort.Parse(CsvParser.Slice(ref items));
        var maxBaseValue = ushort.Parse(CsvParser.Slice(ref items));

        return (characterId, new WeaponBaseStatDto(
            characterId,
            minBaseValue,
            maxBaseValue,
            statTypeId
        ));
    }
}

