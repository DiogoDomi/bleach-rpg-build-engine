using BuildCalculator.Domain;
using BuildCalculator.Domain.Enums;

namespace BuildCalculator.Data.Repositories;

public readonly record struct LookupDataBag(
    IReadOnlyDictionary<byte, string> Rarities,
    IReadOnlyDictionary<byte, string> StatTypes,
    IReadOnlyDictionary<byte, string> StarRatings
);

public class LookupRepository
{
    private readonly IReadOnlyDictionary<byte, string> _rarities;
    private readonly IReadOnlyDictionary<byte, string> _statTypes;
    private readonly IReadOnlyDictionary<byte, string> _starRatings;

    public LookupRepository(LookupDataBag bag)
    {
        _rarities = bag.Rarities;
        _statTypes = bag.StatTypes;
        _starRatings = bag.StarRatings;
    }

    public IReadOnlyDictionary<byte, string> GetRarities() => _rarities;
    public IReadOnlyDictionary<byte, string> GetStatTypes() => _statTypes;
    public IReadOnlyDictionary<byte, string> GetStarRatings() => _starRatings;

    public bool TryGetRarity(Rarity rarity, out string? rarityName)
    {
        byte key = (byte)rarity;
        if (key == 0)
        {
            rarityName = default!;
            return false;
        }
        return _rarities.TryGetValue(key, out rarityName);
    }

    public bool TryGetStatType(StatType statType, out string? statTypeName)
    {
        byte key = (byte)statType;
        if (key == 0)
        {
            statTypeName = default!;
            return false;
        }
        return _statTypes.TryGetValue(key, out statTypeName);
    }

    public bool TryGetStarRating(StarRating starRating, out string? starRatingName)
    {
        byte key = (byte)starRating;
        if (key == 0)
        {
            starRatingName = default!;
            return false;
        }
        return _starRatings.TryGetValue(key, out starRatingName);
    }
}

