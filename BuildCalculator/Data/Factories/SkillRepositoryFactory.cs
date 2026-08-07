using BuildCalculator.Data.Dtos;
using BuildCalculator.Core;
using BuildCalculator.Data.Repositories;
using BuildCalculator.Data.Parsers.Mappers;

namespace BuildCalculator.Data.Factories;

public readonly record struct SkillDtoBag(
    IReadOnlyDictionary<ushort, string> Names,
    IReadOnlyDictionary<byte, SkillCategoryDto> CategoryDtos,
    IReadOnlyDictionary<byte, SkillSubCategoryDto> SubCategoryDtos,
    IReadOnlyDictionary<ushort, SkillDto[]> SkillDtos,
    IReadOnlyDictionary<ushort, string> UseStates,
    IReadOnlyDictionary<ushort, string> Templates,
    IReadOnlyDictionary<byte, string> Tags,
    IReadOnlyDictionary<ushort, SkillTagMappingDto[]> TagMappingDtos
);

public static class SkillRepositoryFactory
{
    public static ResultData<SkillRepository> Create(SkillDtoBag dtoBag)
    {
        var categories = dtoBag.CategoryDtos.ToDictionary(
            kvp => kvp.Key,
            kvp => SkillMapper.MapToCategoryDomain(kvp.Value));

        var subCategories = dtoBag.SubCategoryDtos.ToDictionary(
            kvp => kvp.Key,
            kvp => SkillMapper.MapToSubCategoryDomain(kvp.Value));

        var skills = dtoBag.SkillDtos.ToDictionary(
            kvp => kvp.Key,
            kvp => kvp.Value
                .Select(dto => SkillMapper.MapToSkillDomain(dto))
                .ToArray());

        var tagMapping = dtoBag.TagMappingDtos.ToDictionary(
            kvp => kvp.Key,
            kvp => SkillMapper.MapToSkillTagMappingDomain(kvp.Value));

        var dataBag = new SkillDataBag(
            dtoBag.Names,
            categories,
            subCategories,
            skills,
            dtoBag.UseStates,
            dtoBag.Templates,
            dtoBag.Tags,
            tagMapping
        );

        var repository = new SkillRepository(dataBag);

        return ResultData<SkillRepository>.Ok(repository);
    }
}

