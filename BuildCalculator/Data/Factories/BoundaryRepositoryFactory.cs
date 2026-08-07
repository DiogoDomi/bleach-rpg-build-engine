using BuildCalculator.Data.Dtos;
using BuildCalculator.Core;
using BuildCalculator.Data.Repositories;
using BuildCalculator.Data.Parsers.Mappers;

namespace BuildCalculator.Data.Factories;

public readonly record struct BoundaryDtoBag(
    IReadOnlyDictionary<byte, string> Ascensions,
    IReadOnlyDictionary<byte, string> Types,
    IReadOnlyDictionary<ushort, string> SkillNames,
    IReadOnlyDictionary<ushort, BoundaryDto[]> BoundaryDtos,
    IReadOnlyDictionary<ushort, string> Templates
);

public static class BoundaryRepositoryFactory
{
    public static ResultData<BoundaryRepository> Create(BoundaryDtoBag dtoBag)
    {
        var boundaries = dtoBag.BoundaryDtos.ToDictionary(
            kvp => kvp.Key,
            kvp => kvp.Value.Select(
                dto => BoundaryMapper.MapToBoundaryDomain(dto)).ToArray());

        var dataBag = new BoundaryDataBag(
            dtoBag.Ascensions,
            dtoBag.Types,
            dtoBag.SkillNames,
            boundaries,
            dtoBag.Templates);

        var repository = new BoundaryRepository(dataBag);

        return ResultData<BoundaryRepository>.Ok(repository);
    }
}

