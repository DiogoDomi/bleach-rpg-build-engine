using BuildCalculator.Data.Dtos;
using BuildCalculator.Core;
using BuildCalculator.Data.Repositories;
using BuildCalculator.Data.Parsers.Mappers;

namespace BuildCalculator.Data.Factories;

public readonly record struct LookupDtoBag(
    IReadOnlyDictionary<byte, string> Rarities,
    IReadOnlyDictionary<byte, string> StatTypes,
    IReadOnlyDictionary<byte, string> StarRatings
);

public static class LookupRepositoryFactory
{
    public static ResultData<LookupRepository> Create(LookupDtoBag dtoBag)
    {
        var dataBag = new LookupDataBag(
                dtoBag.Rarities,
                dtoBag.StatTypes,
                dtoBag.StarRatings);

        var repository = new LookupRepository(dataBag);

        return ResultData<LookupRepository>.Ok(repository);
    }
}

