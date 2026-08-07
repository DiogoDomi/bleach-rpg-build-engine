using BuildCalculator.Core;
using BuildCalculator.Data.Repositories;
using BuildCalculator.Data.Parsers.Loaders.Csv;
using BuildCalculator.Data.Dtos;
using BuildCalculator.Data.Parsers.Builders.Csv;
using BuildCalculator.Data.Factories;

namespace BuildCalculator.Data.Parsers.Loaders.Csv;

public static class CsvGameConfigLoader
{
    public static ResultData<GameConfigRepository> LoadRepository(string csvDirPath)
    {
        var upgradeCostData = CsvSharedLoaders.ExecuteLoader(csvDirPath, "character_max_upgrade_costs.csv",
            reader => CsvSharedLoaders.LoadSingleDomainData<byte, CharacterMaxUpgradeCostDto>(
                reader, CsvGameConfigBuilder.BuildCharacterMaxUpgradeCostDto));

        if (!upgradeCostData.IsSuccess)
            return ResultData<GameConfigRepository>.Fail(upgradeCostData.Error,
                $"[LoadGameConfigRepository] (upgradeCostsData) Failed to load characterMaxUpgradeCosts -> {upgradeCostData.Message}");

        var entityTypeData = CsvSharedLoaders.ExecuteLoader(csvDirPath, "entity_types.csv",
            reader => CsvSharedLoaders.LoadSingleDomainData<byte, string>(
                reader, CsvSharedBuilders.BuildIdAndText<byte>));

        if (!entityTypeData.IsSuccess)
            return ResultData<GameConfigRepository>.Fail(entityTypeData.Error,
                $"[LoadGameConfigRepository] (categoryData) Failed to load entityTypes -> {entityTypeData.Message}");

        var limitedGachaPullCostData = CsvSharedLoaders.ExecuteLoader(csvDirPath, "limited_gacha_guaranteed_pull_costs.csv",
            reader => CsvSharedLoaders.LoadManyDomainData<byte, LimitedGachaGuaranteedPullCostDto>(
                reader, CsvGameConfigBuilder.BuildLimitedGachaGuaranteedPullCostDto));

        if (!limitedGachaPullCostData.IsSuccess)
            return ResultData<GameConfigRepository>.Fail(limitedGachaPullCostData.Error,
                $"[LoadGameConfigRepository] (typeData) Failed to load limitedGachaPullCosts -> {limitedGachaPullCostData.Message}");

        var levelConfigData = CsvSharedLoaders.ExecuteLoader(csvDirPath, "game_level_configs.csv",
            reader => CsvSharedLoaders.LoadSingleDomainData<byte, GameLevelConfigDto>(
                reader, CsvGameConfigBuilder.BuildGameLevelConfigDto));

        if (!levelConfigData.IsSuccess)
            return ResultData<GameConfigRepository>.Fail(levelConfigData.Error,
                $"[LoadGameConfigRepository] (itemData) Failed to load levelConfigs -> {levelConfigData.Message}");

        var dtoBag = new GameConfigDtoBag(
            upgradeCostData.Item,
            entityTypeData.Item,
            limitedGachaPullCostData.Item,
            levelConfigData.Item
        );

        return GameConfigRepositoryFactory.Create(dtoBag);
    }
}

