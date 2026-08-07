using BuildCalculator.Data.Dtos;
using BuildCalculator.Domain;
using BuildCalculator.Domain.Enums;

namespace BuildCalculator.Data.Parsers.Mappers;

public static class SkillMapper
{
    public static SkillCategory MapToCategoryDomain(SkillCategoryDto dto)
    {
        return new SkillCategory(dto.Name, dto.DisplayOrder);
    }

    public static SkillSubCategory MapToSubCategoryDomain(SkillSubCategoryDto dto)
    {
        return new SkillSubCategory(dto.Name, dto.CategoryId, dto.DisplayOrder);
    }

    public static Skill MapToSkillDomain(SkillDto dto)
    {
        return new Skill(
            dto.Id,
            dto.NameId,
            dto.SubCategoryId,
            dto.DisplayOrder);
    }

    public static byte MapToSkillTagMappingDomain(IEnumerable<SkillTagMappingDto> dtos)
    {
        byte tags = 0;

        foreach (var dto in dtos)
        {

            tags |= dto.TagId;
        }

        return tags;
    }
}

