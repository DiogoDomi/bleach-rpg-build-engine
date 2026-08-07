using BuildCalculator.Data.Dtos;
using BuildCalculator.Core;
using BuildCalculator.Domain.Enums;
using BuildCalculator.Data.Repositories;
using BuildCalculator.Data.Parsers.Mappers;

namespace BuildCalculator.Data.Factories;

public readonly record struct GameConfigDtoBag(
    IReadOnlyDictionary<byte, CharacterMaxUpgradeCostDto> CharacterMaxUpgradeCostDtos,
    IReadOnlyDictionary<byte, string> EntityTypes,
    IReadOnlyDictionary<byte, LimitedGachaGuaranteedPullCostDto[]> LimitedGachaGuaranteedPullCostDtos,
    IReadOnlyDictionary<byte, GameLevelConfigDto> GameLevelConfigDtos
);

public static class GameConfigRepositoryFactory
{
    public static ResultData<GameConfigRepository> Create(GameConfigDtoBag dtoBag)
    {
        var characterMaxUpgradeCosts = dtoBag.CharacterMaxUpgradeCostDtos.Values
            .Select(GameConfigMapper.MapToCharacterMaxUpgradeCostDomain)
            .GroupBy(domain => (byte)domain.Rarity)
            .ToDictionary(g => g.Key, g => g.ToArray());

        var limitedGachaGuaranteedPullCosts = dtoBag.LimitedGachaGuaranteedPullCostDtos
            .ToDictionary(
                kvp => kvp.Key,
                kvp => kvp.Value.Select(
                    GameConfigMapper.MapToLimitedGachaGuaranteedPullCostDomain)
                .ToArray());

        var gameLevelConfigs = dtoBag.GameLevelConfigDtos.Values
            .Select(GameConfigMapper.MapToGameLevelConfigDomain)
            .GroupBy(domain => (byte)domain.EntityType)
            .ToDictionary(g => g.Key, g => g.ToArray());

        var dataBag = new GameConfigDataBag(
            characterMaxUpgradeCosts,
            dtoBag.EntityTypes,
            limitedGachaGuaranteedPullCosts,
            gameLevelConfigs
        );

        var repository = new GameConfigRepository(dataBag);

        return ResultData<GameConfigRepository>.Ok(repository);
    }
}

