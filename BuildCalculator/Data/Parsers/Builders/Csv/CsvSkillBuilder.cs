using BuildCalculator.Data.Parsers;
using BuildCalculator.Data.Dtos;

namespace BuildCalculator.Data.Parsers.Builders.Csv;

public static class CsvSkillBuilder
{
    public static (byte CategoryId, SkillCategoryDto Dto) BuildCategoryDto(ReadOnlySpan<char> items)
    {
        var id = byte.Parse(CsvParser.Slice(ref items));
        var name = CsvParser.Slice(ref items).ToString();
        var displayOrder = byte.Parse(CsvParser.Slice(ref items));

        return (id, new SkillCategoryDto(
            name,
            id,
            displayOrder
        ));
    }

    public static (byte SubCategoryId, SkillSubCategoryDto Dto) BuildSubCategoryDto(ReadOnlySpan<char> items)
    {
        var id = byte.Parse(CsvParser.Slice(ref items));
        var name = CsvParser.Slice(ref items).ToString();
        var skillCategoryId = byte.Parse(CsvParser.Slice(ref items));
        var displayOrder = byte.Parse(CsvParser.Slice(ref items));

        return (id, new SkillSubCategoryDto(
            name,
            id,
            skillCategoryId,
            displayOrder
        ));
    }

    public static (ushort CharacterId, SkillDto Dto) BuildSkillDto(ReadOnlySpan<char> items)
    {
        var id = ushort.Parse(CsvParser.Slice(ref items));
        var characterId = ushort.Parse(CsvParser.Slice(ref items));
        var skillNameId = ushort.Parse(CsvParser.Slice(ref items));
        var skillSubCategoryId = byte.Parse(CsvParser.Slice(ref items));
        var displayOrder = byte.Parse(CsvParser.Slice(ref items));

        return (characterId, new SkillDto(
            id,
            characterId,
            skillNameId,
            skillSubCategoryId,
            displayOrder
        ));
    }

    public static (ushort SkillId, SkillTagMappingDto Dto) BuildTagMappingDto(ReadOnlySpan<char> items)
    {
        var skillId = ushort.Parse(CsvParser.Slice(ref items));
        var tagId = byte.Parse(CsvParser.Slice(ref items));

        return (skillId, new SkillTagMappingDto(
            skillId,
            tagId
        ));
    }
}

