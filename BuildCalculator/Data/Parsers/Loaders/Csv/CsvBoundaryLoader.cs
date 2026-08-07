using BuildCalculator.Core;
using BuildCalculator.Data.Dtos;
using BuildCalculator.Data.Repositories;
using BuildCalculator.Data.Parsers.Builders.Csv;
using BuildCalculator.Data.Factories;

namespace BuildCalculator.Data.Parsers.Loaders.Csv;

public static class CsvBoundaryLoader
{
    public static ResultData<BoundaryRepository> LoadRepository(string csvDirPath)
    {
        var ascensionData = CsvSharedLoaders.ExecuteLoader(
            csvDirPath, "boundary_ascensions.csv",
            reader => CsvSharedLoaders.LoadSingleDomainData<byte, string>(
                reader, CsvSharedBuilders.BuildIdAndText<byte>));

        if (!ascensionData.IsSuccess)
            return ResultData<BoundaryRepository>.Fail(ascensionData.Error,
                $"[LoadBoundaryRepository] (ascensionData) Failed to load ascensions -> {ascensionData.Message}");

        var typeData = CsvSharedLoaders.ExecuteLoader(
            csvDirPath, "boundary_types.csv",
            reader => CsvSharedLoaders.LoadSingleDomainData<byte, string>(
                reader, CsvSharedBuilders.BuildIdAndText<byte>));

        if (!typeData.IsSuccess)
            return ResultData<BoundaryRepository>.Fail(typeData.Error,
                $"[LoadBoundaryRepository] (typeData) Failed to load types -> {typeData.Message}");

        var skillNameData = CsvSharedLoaders.ExecuteLoader(
            csvDirPath, "boundary_skill_names.csv",
            reader => CsvSharedLoaders.LoadSingleDomainData<ushort, string>(
                reader, CsvSharedBuilders.BuildIdAndText<ushort>));

        if (!skillNameData.IsSuccess)
            return ResultData<BoundaryRepository>.Fail(skillNameData.Error,
                $"[LoadBoundaryRepository] (skillNameData) Failed to load skillNames -> {skillNameData.Message}");

        var boundaryData = CsvSharedLoaders.ExecuteLoader(
            csvDirPath, "boundaries.csv",
            reader => CsvSharedLoaders.LoadManyDomainData<ushort, BoundaryDto>(
                reader, CsvBoundaryBuilder.BuildBoundaryDto));

        if (!boundaryData.IsSuccess)
            return ResultData<BoundaryRepository>.Fail(boundaryData.Error,
                $"[LoadBoundaryRepository] (boundaryData) Failed to load boundaries -> {boundaryData.Message}");

        var templateData = CsvSharedLoaders.ExecuteLoader(
            csvDirPath, "boundary_templates.csv",
            reader => CsvSharedLoaders.LoadSingleDomainData<ushort, string>(
                reader, CsvSharedBuilders.BuildIdAndText<ushort>));

        if (!templateData.IsSuccess)
            return ResultData<BoundaryRepository>.Fail(templateData.Error,
                $"[LoadBoundaryRepository] (templateData) Failed to load templates -> {templateData.Message}");

        var dtoBag = new BoundaryDtoBag(
            ascensionData.Item,
            typeData.Item,
            skillNameData.Item,
            boundaryData.Item,
            templateData.Item);

        return BoundaryRepositoryFactory.Create(dtoBag);
    }
}

