using BuildCalculator.Core;
using BuildCalculator.Data.Repositories;
using BuildCalculator.Data.Parsers.Loaders.Csv;
using BuildCalculator.Data.Dtos;
using BuildCalculator.Data.Parsers.Builders.Csv;
using BuildCalculator.Data.Factories;

namespace BuildCalculator.Data.Parsers.Loaders.Csv;

public static class CsvSkillLoader
{
    public static ResultData<SkillRepository> LoadRepository(string csvDirPath)
    {
        var nameData = CsvSharedLoaders.ExecuteLoader(csvDirPath, "skill_names.csv",
            reader => CsvSharedLoaders.LoadSingleDomainData<ushort, string>(
                reader, CsvSharedBuilders.BuildIdAndText<ushort>));

        if (!nameData.IsSuccess)
            return ResultData<SkillRepository>.Fail(nameData.Error,
                $"[LoadSkillRepository] (nameData) Failed to load names -> {nameData.Message}");

        var categoryData = CsvSharedLoaders.ExecuteLoader(csvDirPath, "skill_categories.csv",
            reader => CsvSharedLoaders.LoadSingleDomainData<byte, SkillCategoryDto>(
                reader, CsvSkillBuilder.BuildCategoryDto));

        if (!categoryData.IsSuccess)
            return ResultData<SkillRepository>.Fail(categoryData.Error,
                $"[LoadSkillRepository] (categoryData) Failed to load categories -> {categoryData.Message}");

        var subCategoryData = CsvSharedLoaders.ExecuteLoader(csvDirPath, "skill_subcategories.csv",
            reader => CsvSharedLoaders.LoadSingleDomainData<byte, SkillSubCategoryDto>(
                reader, CsvSkillBuilder.BuildSubCategoryDto));

        if (!subCategoryData.IsSuccess)
            return ResultData<SkillRepository>.Fail(subCategoryData.Error,
                $"[LoadSkillRepository] (subCategoryData) Failed to load subCategories -> {subCategoryData.Message}");

        var skillData = CsvSharedLoaders.ExecuteLoader(csvDirPath, "skills.csv",
            reader => CsvSharedLoaders.LoadManyDomainData<ushort, SkillDto>(
                reader, CsvSkillBuilder.BuildSkillDto));

        if (!skillData.IsSuccess)
            return ResultData<SkillRepository>.Fail(skillData.Error,
                $"[LoadSkillRepository] (skillData) Failed to load skills -> {skillData.Message}");

        var skillUseStateData = CsvSharedLoaders.ExecuteLoader(csvDirPath, "skill_use_states.csv",
            reader => CsvSharedLoaders.LoadSingleDomainData<ushort, string>(
                reader, CsvSharedBuilders.BuildIdAndText<ushort>));

        if (!skillUseStateData.IsSuccess)
            return ResultData<SkillRepository>.Fail(skillUseStateData.Error,
                $"[LoadSkillRepository] (skillUseStateData) Failed to load useStates -> {skillUseStateData.Message}");

        var skillTemplateData = CsvSharedLoaders.ExecuteLoader(csvDirPath, "skill_templates.csv",
            reader => CsvSharedLoaders.LoadSingleDomainData<ushort, string>(
                reader, CsvSharedBuilders.BuildIdAndText<ushort>));

        if (!skillTemplateData.IsSuccess)
            return ResultData<SkillRepository>.Fail(skillTemplateData.Error,
                $"[LoadSkillRepository] (skillTemplateData) Failed to load templates -> {skillTemplateData.Message}");

        var tagData = CsvSharedLoaders.ExecuteLoader(csvDirPath, "skill_tags.csv",
            reader => CsvSharedLoaders.LoadSingleDomainData<byte, string>(
                reader, CsvSharedBuilders.BuildIdAndText<byte>));

        if (!tagData.IsSuccess)
            return ResultData<SkillRepository>.Fail(tagData.Error,
                $"[LoadSkillRepository] (tagData) Failed to load tags -> {tagData.Message}");

        var tagMappingData = CsvSharedLoaders.ExecuteLoader(csvDirPath, "skill_tag_mapping.csv",
            reader => CsvSharedLoaders.LoadManyDomainData<ushort, SkillTagMappingDto>(
                reader, CsvSkillBuilder.BuildTagMappingDto));

        if (!tagMappingData.IsSuccess)
            return ResultData<SkillRepository>.Fail(tagMappingData.Error,
                $"[LoadSkillRepository] (tagMappingData) Failed to load tagMapping -> {tagMappingData.Message}");

        var dtoBag = new SkillDtoBag(
            nameData.Item,
            categoryData.Item,
            subCategoryData.Item,
            skillData.Item,
            skillUseStateData.Item,
            skillTemplateData.Item,
            tagData.Item,
            tagMappingData.Item
        );

        return SkillRepositoryFactory.Create(dtoBag);
    }
}

