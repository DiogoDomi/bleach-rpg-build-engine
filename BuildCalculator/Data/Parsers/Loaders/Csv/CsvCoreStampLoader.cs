using BuildCalculator.Core;
using BuildCalculator.Data.Dtos;
using BuildCalculator.Data.Repositories;
using BuildCalculator.Data.Parsers.Builders.Csv;
using BuildCalculator.Data.Factories;

namespace BuildCalculator.Data.Parsers.Loaders.Csv;

public static class CsvCoreStampLoader
{
    public static ResultData<CoreStampRepository> LoadRepository(string csvDirPath)
    {
        var nameData = CsvSharedLoaders.ExecuteLoader(
            csvDirPath, "core_stamp_names.csv",
            reader => CsvSharedLoaders.LoadSingleDomainData<ushort, string>(
                reader, CsvSharedBuilders.BuildIdAndText<ushort>));

        if (!nameData.IsSuccess)
            return ResultData<CoreStampRepository>.Fail(nameData.Error,
                $"[LoadCoreStampRepository] (nameData) Failed to load names -> {nameData.Message}");

        var coreStampData = CsvSharedLoaders.ExecuteLoader(
            csvDirPath, "core_stamps.csv",
            reader => CsvSharedLoaders.LoadSingleDomainData<ushort, CoreStampDto>(
                reader, CsvCoreStampBuilder.BuildCoreStampDto));

        if (!coreStampData.IsSuccess)
            return ResultData<CoreStampRepository>.Fail(coreStampData.Error,
                $"[LoadCoreStampRepository] (coreStampData) Failed to load coreStamps -> {coreStampData.Message}");

        var templateData = CsvSharedLoaders.ExecuteLoader(
            csvDirPath, "core_stamp_templates.csv",
            reader => CsvSharedLoaders.LoadSingleDomainData<ushort, string>(
                reader, CsvSharedBuilders.BuildIdAndText<ushort>));

        if (!templateData.IsSuccess)
            return ResultData<CoreStampRepository>.Fail(templateData.Error,
                $"[LoadCoreStampRepository] (templateData) Failed to load templates -> {templateData.Message}");

        var baseStatData = CsvSharedLoaders.ExecuteLoader(
            csvDirPath, "core_stamp_base_stats.csv",
            reader => CsvSharedLoaders.LoadManyDomainData<ushort, CoreStampBaseStatDto>(
                reader, CsvCoreStampBuilder.BuildBaseStatDto));

        if (!baseStatData.IsSuccess)
            return ResultData<CoreStampRepository>.Fail(baseStatData.Error,
                $"[LoadCoreStampRepository] (baseStatData) Failed to load baseStats -> {baseStatData.Message}");

        var dtoBag = new CoreStampDtoBag(
            nameData.Item,
            coreStampData.Item,
            templateData.Item,
            baseStatData.Item);

        return CoreStampRepositoryFactory.Create(dtoBag);
    }
}

