using BuildCalculator.Domain;
using BuildCalculator.Domain.Enums;

namespace BuildCalculator.Data.Repositories;

public readonly record struct GameConfigDataBag(
    IReadOnlyDictionary<byte, CharacterMaxUpgradeCost[]> CharacterMaxUpgradeCosts,
    IReadOnlyDictionary<byte, string> EntityTypes,
    IReadOnlyDictionary<byte, LimitedGachaGuaranteedPullCost[]> LimitedGachaGuaranteedPullCosts,
    IReadOnlyDictionary<byte, GameLevelConfig[]> GameLevelConfigs
);

public class GameConfigRepository
{
    private readonly IReadOnlyDictionary<byte, CharacterMaxUpgradeCost[]> _characterMaxUpgradeCosts;
    private readonly IReadOnlyDictionary<byte, string> _entityTypes;
    private readonly IReadOnlyDictionary<byte, LimitedGachaGuaranteedPullCost[]> _limitedGachaGuaranteedPullCosts;
    private readonly IReadOnlyDictionary<byte, GameLevelConfig[]> _gameLevelConfigs;

    public GameConfigRepository(GameConfigDataBag bag)
    {
        _characterMaxUpgradeCosts = bag.CharacterMaxUpgradeCosts;
        _entityTypes = bag.EntityTypes;
        _limitedGachaGuaranteedPullCosts = bag.LimitedGachaGuaranteedPullCosts;
        _gameLevelConfigs = bag.GameLevelConfigs;
    }

    public IReadOnlyDictionary<byte, CharacterMaxUpgradeCost[]> GetCharacterMaxUpgradeCosts() => _characterMaxUpgradeCosts;
    public IReadOnlyDictionary<byte, string> GetEntityTypes() => _entityTypes;
    public IReadOnlyDictionary<byte, LimitedGachaGuaranteedPullCost[]> GetLimitedGachaGuaranteedPullCosts() => _limitedGachaGuaranteedPullCosts;
    public IReadOnlyDictionary<byte, GameLevelConfig[]> GetGameLevelConfigs() => _gameLevelConfigs;

    public bool TryGetCharacterMaxUpgradeCosts(byte key, out CharacterMaxUpgradeCost[]? costs)
    {
        if (key == 0)
        {
            costs = default!;
            return false;
        }
        return _characterMaxUpgradeCosts.TryGetValue(key, out costs);
    }

    public bool TryGetEntityType(EntityType entityType, out string? entityTypeName)
    {
        byte entityTypeId = (byte)entityType;
        if (entityTypeId == 0)
        {
            entityTypeName = default!;
            return false;
        }
        return _entityTypes.TryGetValue(entityTypeId, out entityTypeName);
    }

    public bool TryGetLimitedGachaGuaranteedPullCosts(byte key, out LimitedGachaGuaranteedPullCost[]? costs)
    {
        if (key == 0)
        {
            costs = default!;
            return false;
        }
        return _limitedGachaGuaranteedPullCosts.TryGetValue(key, out costs);
    }

    public bool TryGetGameLevelConfigs(byte key, out GameLevelConfig[]? configs)
    {
        if (key == 0)
        {
            configs = default!;
            return false;
        }
        return _gameLevelConfigs.TryGetValue(key, out configs);
    }
}

