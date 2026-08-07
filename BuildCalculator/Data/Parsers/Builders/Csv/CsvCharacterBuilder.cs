using BuildCalculator.Data.Parsers;
using BuildCalculator.Data.Dtos;

namespace BuildCalculator.Data.Parsers.Builders.Csv;

public static class CsvCharacterBuilder
{
    public static (byte CharacterRoleId, CharacterRoleDto Dto) BuildCharacterRoleDto(ReadOnlySpan<char> items)
    {
        var id = byte.Parse(CsvParser.Slice(ref items));
        var name = CsvParser.Slice(ref items).ToString();
        var description = CsvParser.Slice(ref items).ToString();

        return (id, new CharacterRoleDto(name, description, id));
    }

    public static (ushort CharacterId, CharacterDto Dto) BuildCharacterDto(ReadOnlySpan<char> items)
    {
        var id = ushort.Parse(CsvParser.Slice(ref items));
        var characterNameId = ushort.Parse(CsvParser.Slice(ref items));
        var characterAffinityId = byte.Parse(CsvParser.Slice(ref items));
        var characterRoleId = byte.Parse(CsvParser.Slice(ref items));
        var characterFactionId = byte.Parse(CsvParser.Slice(ref items));
        var rarityId = byte.Parse(CsvParser.Slice(ref items));
        var displayOrder = ushort.Parse(CsvParser.Slice(ref items));

        return (id, new CharacterDto(
            id,
            characterNameId,
            displayOrder,
            characterAffinityId,
            characterRoleId,
            characterFactionId,
            rarityId
        ));
    }

    public static (ushort CharacterId, CharacterBaseStatDto Dto) BuildBaseStatDto(ReadOnlySpan<char> items)
    {
        var characterId = ushort.Parse(CsvParser.Slice(ref items));
        var statTypeId = byte.Parse(CsvParser.Slice(ref items));
        var minBaseValue = ushort.Parse(CsvParser.Slice(ref items));
        ushort? maxBaseValue = ushort.TryParse(CsvParser.Slice(ref items), out var value)
            ? value
            : null;

        return (characterId, new CharacterBaseStatDto(
            maxBaseValue,
            minBaseValue,
            characterId,
            statTypeId
        ));
    }
}

