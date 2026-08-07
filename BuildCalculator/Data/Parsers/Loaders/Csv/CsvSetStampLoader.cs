using BuildCalculator.Core;
using BuildCalculator.Data.Dtos;
using BuildCalculator.Data.Repositories;
using BuildCalculator.Data.Parsers.Builders.Csv;
using BuildCalculator.Data.Factories;

namespace BuildCalculator.Data.Parsers.Loaders.Csv;

public static class CsvSetStampLoader
{
    public static ResultData<SetStampRepository> LoadRepository(string csvDirPath)
    {
        var nameData = CsvSharedLoaders.ExecuteLoader(
            csvDirPath, "set_stamp_names.csv",
            reader => CsvSharedLoaders.LoadSingleDomainData<ushort, string>(
                reader, CsvSharedBuilders.BuildIdAndText<ushort>));

        if (!nameData.IsSuccess)
            return ResultData<SetStampRepository>.Fail(nameData.Error,
                $"[LoadSetStampRepository] (nameData) Failed to load names -> {nameData.Message}");

        var setStampData = CsvSharedLoaders.ExecuteLoader(
            csvDirPath, "set_stamps.csv",
            reader => CsvSharedLoaders.LoadSingleDomainData<ushort, SetStampDto>(
                reader, CsvSetStampBuilder.BuildSetStampDto));

        if (!setStampData.IsSuccess)
            return ResultData<SetStampRepository>.Fail(setStampData.Error,
                $"[LoadSetStampRepository] (setStampData) Failed to load setStamps -> {setStampData.Message}");

        var templateData = CsvSharedLoaders.ExecuteLoader(
            csvDirPath, "set_stamp_templates.csv",
            reader => CsvSharedLoaders.LoadSingleDomainData<ushort, string>(
                reader, CsvSharedBuilders.BuildIdAndText<ushort>));

        if (!templateData.IsSuccess)
            return ResultData<SetStampRepository>.Fail(templateData.Error,
                $"[LoadSetStampRepository] (templateData) Failed to load templates -> {templateData.Message}");

        var passiveNameData = CsvSharedLoaders.ExecuteLoader(
            csvDirPath, "set_stamp_passive_names.csv",
            reader => CsvSharedLoaders.LoadSingleDomainData<byte, string>(
                reader, CsvSharedBuilders.BuildIdAndText<byte>));

        if (!passiveNameData.IsSuccess)
            return ResultData<SetStampRepository>.Fail(passiveNameData.Error,
                $"[LoadSetStampRepository] (passiveNameData) Failed to load passiveNames -> {passiveNameData.Message}");

        var passiveData = CsvSharedLoaders.ExecuteLoader(
            csvDirPath, "set_stamp_passives.csv",
            reader => CsvSharedLoaders.LoadSingleDomainData<byte, SetStampPassiveDto>(
                reader, CsvSetStampBuilder.BuildPassiveDto));

        if (!passiveData.IsSuccess)
            return ResultData<SetStampRepository>.Fail(passiveData.Error,
                $"[LoadSetStampRepository] (passiveData) Failed to load passives -> {passiveData.Message}");

        var passiveTemplateData = CsvSharedLoaders.ExecuteLoader(
            csvDirPath, "set_stamp_passive_templates.csv",
            reader => CsvSharedLoaders.LoadSingleDomainData<byte, string>(
                reader, CsvSharedBuilders.BuildIdAndText<byte>));

        if (!passiveTemplateData.IsSuccess)
            return ResultData<SetStampRepository>.Fail(passiveTemplateData.Error,
                $"[LoadSetStampRepository] (passiveTemplateData) Failed to load passiveTemplates -> {passiveTemplateData.Message}");

        var levelGapData = CsvSharedLoaders.ExecuteLoader(
            csvDirPath, "set_stamp_level_gaps.csv",
            reader => CsvSharedLoaders.LoadManyDomainData<byte, SetStampLevelGapDto>(
                reader, CsvSetStampBuilder.BuildLevelGapDto));

        if (!levelGapData.IsSuccess)
            return ResultData<SetStampRepository>.Fail(levelGapData.Error,
                $"[LoadSetStampRepository] (levelGapData) Failed to load levelGaps -> {levelGapData.Message}");

        var fixedBasicStatData = CsvSharedLoaders.ExecuteLoader(
            csvDirPath, "set_stamp_fixed_basic_stats.csv",
            reader => CsvSharedLoaders.LoadSingleDomainData<byte, byte>(
                reader, CsvSetStampBuilder.BuildFixedBasicStat));

        if (!fixedBasicStatData.IsSuccess)
            return ResultData<SetStampRepository>.Fail(fixedBasicStatData.Error,
                $"[LoadSetStampRepository] (fixedBasicStatData) Failed to load fixedBasicStats -> {fixedBasicStatData.Message}");

        var poolBasicStatData = CsvSharedLoaders.ExecuteLoader(
            csvDirPath, "set_stamp_pool_basic_stats.csv",
            reader => CsvSharedLoaders.LoadManyDomainData<byte, byte>(
                reader, CsvSetStampBuilder.BuildPoolBasicStat));

        if (!poolBasicStatData.IsSuccess)
            return ResultData<SetStampRepository>.Fail(poolBasicStatData.Error,
                $"[LoadSetStampRepository] (poolBasicStatData) Failed to load poolBasicStats -> {poolBasicStatData.Message}");

        var fixedBasicStatGrowthData = CsvSharedLoaders.ExecuteLoader(
            csvDirPath, "set_stamp_fixed_basic_stat_growths.csv",
            reader => CsvSharedLoaders.LoadManyDomainData<byte, SetStampFixedBasicStatGrowthDto>(
                reader, CsvSetStampBuilder.BuildFixedBasicStatGrowthDto));

        if (!fixedBasicStatGrowthData.IsSuccess)
            return ResultData<SetStampRepository>.Fail(fixedBasicStatGrowthData.Error,
                $"[LoadSetStampRepository] (fixedBasicStatGrowthData) Failed to load fixedBasicStatGrowths -> {fixedBasicStatGrowthData.Message}");

        var poolBasicStatGrowthData = CsvSharedLoaders.ExecuteLoader(
            csvDirPath, "set_stamp_pool_basic_stat_growths.csv",
            reader => CsvSharedLoaders.LoadManyDomainData<byte, SetStampPoolBasicStatGrowthDto>(
                reader, CsvSetStampBuilder.BuildPoolBasicStatGrowthDto));

        if (!poolBasicStatGrowthData.IsSuccess)
            return ResultData<SetStampRepository>.Fail(poolBasicStatGrowthData.Error,
                $"[LoadSetStampRepository] (poolBasicStatGrowthData) Failed to load poolBasicStatGrowths -> {poolBasicStatGrowthData.Message}");

        var poolAdvancedStatGrowthData = CsvSharedLoaders.ExecuteLoader(
            csvDirPath, "set_stamp_pool_advanced_stat_growths.csv",
            reader => CsvSharedLoaders.LoadManyDomainData<byte, SetStampPoolAdvancedStatGrowthDto>(
                reader, CsvSetStampBuilder.BuildPoolAdvancedStatGrowthDto));

        if (!poolAdvancedStatGrowthData.IsSuccess)
            return ResultData<SetStampRepository>.Fail(poolAdvancedStatGrowthData.Error,
                $"[LoadSetStampRepository] (poolAdvancedStatGrowthData) Failed to load poolAdvancedStatGrowths -> {poolAdvancedStatGrowthData.Message}");

        var dtoBag = new SetStampDtoBag(
            nameData.Item,
            setStampData.Item,
            templateData.Item,
            passiveNameData.Item,
            passiveData.Item,
            passiveTemplateData.Item,
            levelGapData.Item,
            fixedBasicStatData.Item,
            poolBasicStatData.Item,
            fixedBasicStatGrowthData.Item,
            poolBasicStatGrowthData.Item,
            poolAdvancedStatGrowthData.Item);

        return SetStampRepositoryFactory.Create(dtoBag);
    }
}

