using BuildCalculator.Data.Dtos;
using BuildCalculator.Core;
using BuildCalculator.Data.Repositories;
using BuildCalculator.Data.Parsers.Mappers;

namespace BuildCalculator.Data.Factories;

public readonly record struct CoreStampDtoBag(
    IReadOnlyDictionary<ushort, string> Names,
    IReadOnlyDictionary<ushort, CoreStampDto> CoreStampDtos,
    IReadOnlyDictionary<ushort, string> Templates,
    IReadOnlyDictionary<ushort, CoreStampBaseStatDto[]> BaseStatDtos
);

public static class CoreStampRepositoryFactory
{
    public static ResultData<CoreStampRepository> Create(CoreStampDtoBag dtoBag)
    {
        var coreStamps = dtoBag.CoreStampDtos.ToDictionary(
            kvp => kvp.Key,
            kvp => CoreStampMapper.MapToCoreStampDomain(kvp.Value));

        var baseStats = dtoBag.BaseStatDtos.ToDictionary(
            kvp => kvp.Key,
            kvp => kvp.Value.Select(
                dto => CoreStampMapper.MapToBaseStatDomain(dto)).ToArray());

        var dataBag = new CoreStampDataBag(
            dtoBag.Names,
            coreStamps,
            dtoBag.Templates,
            baseStats);

        var repository = new CoreStampRepository(dataBag);

        return ResultData<CoreStampRepository>.Ok(repository);
    }
}

