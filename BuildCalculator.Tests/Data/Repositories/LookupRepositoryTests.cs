using Xunit;
using BuildCalculator.Data.Repositories;
using BuildCalculator.Domain;
using BuildCalculator.Domain.Enums;

namespace BuildCalculator.Tests.Data.Repositories;

public class LookupRepositoryTests
{
    private LookupRepository GetFakeRepository(
        IReadOnlyDictionary<byte, string>? rarities = null,
        IReadOnlyDictionary<byte, string>? statTypes = null,
        IReadOnlyDictionary<byte, string>? starRatings = null)
    {
        var bag = new LookupDataBag(
            rarities ?? new Dictionary<byte, string>(),
            statTypes ?? new Dictionary<byte, string>(),
            starRatings ?? new Dictionary<byte, string>()
        );
        return new LookupRepository(bag);
    }

    private IReadOnlyDictionary<byte, string> GetFakeRarities() => new Dictionary<byte, string>
    {
        [1] = "SSR",
        [2] = "SR"
    };

    private IReadOnlyDictionary<byte, string> GetFakeStatTypes() => new Dictionary<byte, string>
    {
        [1] = "AtkFlat",
        [2] = "DefFlat"
    };

    private IReadOnlyDictionary<byte, string> GetFakeStarRatings() => new Dictionary<byte, string>
    {
        [1] = "I",
        [2] = "II"
    };

    [Theory]
    [InlineData((Rarity)1)]
    [InlineData((Rarity)2)]
    public void TryGetRarity_EnumIsValid_ReturnsTrueAndName(Rarity rarity)
    {
        var fakeRarities = GetFakeRarities();
        var repo = GetFakeRepository(rarities: fakeRarities);

        var result = repo.TryGetRarity(rarity, out var rarityName);

        Assert.True(result);
        Assert.Equal(fakeRarities[(byte)rarity], rarityName);
    }

    [Theory]
    [InlineData((Rarity)0)]
    [InlineData((Rarity)3)]
    public void TryGetRarity_EnumIsInvalidOrNotFound_ReturnsFalseAndNull(Rarity rarity)
    {
        var fakeRarities = GetFakeRarities();
        var repo = GetFakeRepository(rarities: fakeRarities);

        var result = repo.TryGetRarity(rarity, out var rarityName);

        Assert.False(result);
        Assert.Null(rarityName);
    }

    [Theory]
    [InlineData((StatType)1)]
    [InlineData((StatType)2)]
    public void TryGetStatType_EnumIsValid_ReturnsTrueAndName(StatType statType)
    {
        var fakeStatTypes = GetFakeStatTypes();
        var repo = GetFakeRepository(statTypes: fakeStatTypes);

        var result = repo.TryGetStatType(statType, out var statTypeName);

        Assert.True(result);
        Assert.Equal(fakeStatTypes[(byte)statType], statTypeName);
    }

    [Theory]
    [InlineData((StatType)0)]
    [InlineData((StatType)3)]
    public void TryGetStatType_EnumIsInvalidOrNotFound_ReturnsFalseAndNull(StatType statType)
    {
        var fakeStatTypes = GetFakeStatTypes();
        var repo = GetFakeRepository(statTypes: fakeStatTypes);

        var result = repo.TryGetStatType(statType, out var statTypeName);

        Assert.False(result);
        Assert.Null(statTypeName);
    }

    [Theory]
    [InlineData((StarRating)1)]
    [InlineData((StarRating)2)]
    public void TryGetStarRating_EnumIsValid_ReturnsTrueAndName(StarRating starRating)
    {
        var fakeStarRatings = GetFakeStarRatings();
        var repo = GetFakeRepository(starRatings: fakeStarRatings);

        var result = repo.TryGetStarRating(starRating, out var starRatingName);

        Assert.True(result);
        Assert.Equal(fakeStarRatings[(byte)starRating], starRatingName);
    }

    [Theory]
    [InlineData((StarRating)0)]
    [InlineData((StarRating)3)]
    public void TryGetStarRating_EnumIsInvalidOrNotFound_ReturnsFalseAndNull(StarRating starRating)
    {
        var fakeStarRatings = GetFakeStarRatings();
        var repo = GetFakeRepository(starRatings: fakeStarRatings);

        var result = repo.TryGetStarRating(starRating, out var starRatingName);

        Assert.False(result);
        Assert.Null(starRatingName);
    }
}
