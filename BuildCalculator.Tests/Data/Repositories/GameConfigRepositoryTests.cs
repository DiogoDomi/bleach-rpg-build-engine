using Xunit;
using BuildCalculator.Data.Repositories;
using BuildCalculator.Domain;
using BuildCalculator.Domain.Enums;

namespace BuildCalculator.Tests.Data.Repositories;

public class GameConfigRepositoryTests
{
    private GameConfigRepository GetFakeRepository(
        IReadOnlyDictionary<byte, CharacterMaxUpgradeCost[]>? characterMaxUpgradeCosts = null,
        IReadOnlyDictionary<byte, string>? entityTypes = null,
        IReadOnlyDictionary<byte, LimitedGachaGuaranteedPullCost[]>? limitedGachaGuaranteedPullCosts = null,
        IReadOnlyDictionary<byte, GameLevelConfig[]>? gameLevelConfigs = null)
    {
        var bag = new GameConfigDataBag(
            characterMaxUpgradeCosts ?? new Dictionary<byte, CharacterMaxUpgradeCost[]>(),
            entityTypes ?? new Dictionary<byte, string>(),
            limitedGachaGuaranteedPullCosts ?? new Dictionary<byte, LimitedGachaGuaranteedPullCost[]>(),
            gameLevelConfigs ?? new Dictionary<byte, GameLevelConfig[]>()
        );
        return new GameConfigRepository(bag);
    }

    private IReadOnlyDictionary<byte, CharacterMaxUpgradeCost[]> GetFakeCharacterMaxUpgradeCosts() => new Dictionary<byte, CharacterMaxUpgradeCost[]>
    {
        [1] = [new(210, null, null, Rarity.Ssr, 4)],
        [2] = [new(210, 1, CharacterAffinity.Slash, Rarity.Ssr, 4)]
    };

    private IReadOnlyDictionary<byte, string> GetFakeEntityTypes() => new Dictionary<byte, string>
    {
        [1] = "Character",
        [2] = "Weapon"
    };

    private IReadOnlyDictionary<byte, LimitedGachaGuaranteedPullCost[]> GetFakeLimitedGachaGuaranteedPullCosts() => new Dictionary<byte, LimitedGachaGuaranteedPullCost[]>
    {
        [1] = [new(80, 1)],
        [2] = [new(80, 1)]
    };

    private IReadOnlyDictionary<byte, GameLevelConfig[]> GetFakeGameLevelConfigs() => new Dictionary<byte, GameLevelConfig[]>
    {
        [1] = [new(null, null, null, 1, 100, null, null, EntityType.Character)],
        [2] = [new(Rarity.Ssr, StarRating.VI, 1, 1, 100, 0, 5, EntityType.Character)]
    };

    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    public void TryGetCharacterMaxUpgradeCosts_IdIsValid_ReturnsTrueAndCosts(byte key)
    {
        var fakeCosts = GetFakeCharacterMaxUpgradeCosts();
        var repo = GetFakeRepository(characterMaxUpgradeCosts: fakeCosts);

        var result = repo.TryGetCharacterMaxUpgradeCosts(key, out var costs);

        Assert.True(result);
        Assert.Equal(fakeCosts[key], costs);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(3)]
    public void TryGetCharacterMaxUpgradeCosts_IdIsInvalidOrNotFound_ReturnsFalseAndNull(byte key)
    {
        var fakeCosts = GetFakeCharacterMaxUpgradeCosts();
        var repo = GetFakeRepository(characterMaxUpgradeCosts: fakeCosts);

        var result = repo.TryGetCharacterMaxUpgradeCosts(key, out var costs);

        Assert.False(result);
        Assert.Null(costs);
    }

    [Theory]
    [InlineData((EntityType)1)]
    [InlineData((EntityType)2)]
    public void TryGetEntityType_EnumIsValid_ReturnsTrueAndEntityType(EntityType entityType)
    {
        var fakeEntityTypes = GetFakeEntityTypes();
        var repo = GetFakeRepository(entityTypes: fakeEntityTypes);

        var result = repo.TryGetEntityType(entityType, out var entityTypeName);

        Assert.True(result);
        Assert.Equal(fakeEntityTypes[(byte)entityType], entityTypeName);
    }

    [Theory]
    [InlineData((EntityType)0)]
    [InlineData((EntityType)3)]
    public void TryGetEntityType_EnummIsInvalidOrNotFound_ReturnsFalseAndNull(EntityType entityType)
    {
        var fakeEntityTypes = GetFakeEntityTypes();
        var repo = GetFakeRepository(entityTypes: fakeEntityTypes);

        var result = repo.TryGetEntityType(entityType, out var entityTypeName);

        Assert.False(result);
        Assert.Null(entityTypeName);
    }

    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    public void TryGetLimitedGachaGuaranteedPullCosts_IdIsValid_ReturnsTrueAndCosts(byte key)
    {
        var fakeCosts = GetFakeLimitedGachaGuaranteedPullCosts();
        var repo = GetFakeRepository(limitedGachaGuaranteedPullCosts: fakeCosts);

        var result = repo.TryGetLimitedGachaGuaranteedPullCosts(key, out var costs);

        Assert.True(result);
        Assert.Equal(fakeCosts[key], costs);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(3)]
    public void TryGetLimitedGachaGuaranteedPullCosts_IdIsInvalidOrNotFound_ReturnsFalseAndNull(byte key)
    {
        var fakeCosts = GetFakeLimitedGachaGuaranteedPullCosts();
        var repo = GetFakeRepository(limitedGachaGuaranteedPullCosts: fakeCosts);

        var result = repo.TryGetLimitedGachaGuaranteedPullCosts(key, out var costs);

        Assert.False(result);
        Assert.Null(costs);
    }

    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    public void TryGetGameLevelConfigs_IdIsValid_ReturnsTrueAndConfigs(byte key)
    {
        var fakeConfigs = GetFakeGameLevelConfigs();
        var repo = GetFakeRepository(gameLevelConfigs: fakeConfigs);

        var result = repo.TryGetGameLevelConfigs(key, out var configs);

        Assert.True(result);
        Assert.Equal(fakeConfigs[key], configs);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(3)]
    public void TryGetGameLevelConfigs_IdIsInvalidOrNotFound_ReturnsFalseAndNull(byte key)
    {
        var fakeConfigs = GetFakeGameLevelConfigs();
        var repo = GetFakeRepository(gameLevelConfigs: fakeConfigs);

        var result = repo.TryGetGameLevelConfigs(key, out var configs);

        Assert.False(result);
        Assert.Null(configs);
    }
}
