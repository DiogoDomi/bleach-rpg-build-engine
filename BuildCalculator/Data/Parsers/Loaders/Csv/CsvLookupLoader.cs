using BuildCalculator.Core;
using BuildCalculator.Data.Repositories;
using BuildCalculator.Data.Parsers.Loaders.Csv;
using BuildCalculator.Data.Dtos;
using BuildCalculator.Data.Parsers.Builders.Csv;
using BuildCalculator.Data.Factories;

namespace BuildCalculator.Data.Parsers.Loaders.Csv;

public static class CsvLookupLoader
{
    public static ResultData<LookupRepository> LoadRepository(string csvDirPath)
    {
        var rarityData = CsvSharedLoaders.ExecuteLoader(csvDirPath, "rarities.csv",
            reader => CsvSharedLoaders.LoadSingleDomainData<byte, string>(
                reader, CsvSharedBuilders.BuildIdAndText<byte>));

        if (!rarityData.IsSuccess)
            return ResultData<LookupRepository>.Fail(rarityData.Error,
                $"[LoadLookupRepository] (rarityData) Failed to load rarities -> {rarityData.Message}");

        var statTypeData = CsvSharedLoaders.ExecuteLoader(csvDirPath, "stat_types.csv",
            reader => CsvSharedLoaders.LoadSingleDomainData<byte, string>(
                reader, CsvSharedBuilders.BuildIdAndText<byte>));

        if (!statTypeData.IsSuccess)
            return ResultData<LookupRepository>.Fail(statTypeData.Error,
                $"[LoadLookupRepository] (statTypeData) Failed to load statTypes -> {statTypeData.Message}");

        var starRatingData = CsvSharedLoaders.ExecuteLoader(csvDirPath, "star_ratings.csv",
            reader => CsvSharedLoaders.LoadSingleDomainData<byte, string>(
                reader, CsvSharedBuilders.BuildIdAndText<byte>));

        if (!starRatingData.IsSuccess)
            return ResultData<LookupRepository>.Fail(starRatingData.Error,
                $"[LoadLookupRepository] (starRatingData) Failed to load starRatings -> {starRatingData.Message}");

        var dtoBag = new LookupDtoBag(
            rarityData.Item,
            statTypeData.Item,
            starRatingData.Item);

        return LookupRepositoryFactory.Create(dtoBag);
    }
}

