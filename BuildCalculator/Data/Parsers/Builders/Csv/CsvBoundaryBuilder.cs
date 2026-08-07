using BuildCalculator.Data.Parsers;
using BuildCalculator.Data.Dtos;

namespace BuildCalculator.Data.Parsers.Builders.Csv;

public static class CsvBoundaryBuilder
{
    public static (ushort CharacterId, BoundaryDto Dto) BuildBoundaryDto(ReadOnlySpan<char> items)
    {
        var id = ushort.Parse(CsvParser.Slice(ref items));
        var characterId = ushort.Parse(CsvParser.Slice(ref items));
        var boundaryAscensionId = byte.Parse(CsvParser.Slice(ref items));
        var boundaryTypeId = byte.Parse(CsvParser.Slice(ref items));
        byte? improvementValue = byte.TryParse(CsvParser.Slice(ref items), out var impValue)
            ? impValue
            : null;
        ushort? boundarySkillNameId = ushort.TryParse(CsvParser.Slice(ref items), out var skillName)
            ? skillName
            : null;

        return (characterId, new BoundaryDto(
            boundarySkillNameId,
            id,
            characterId,
            improvementValue,
            boundaryAscensionId,
            boundaryTypeId));
    }
}

