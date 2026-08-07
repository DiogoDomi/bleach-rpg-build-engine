using BuildCalculator.Data.Dtos;
using BuildCalculator.Core;
using BuildCalculator.Domain.Enums;
using BuildCalculator.Data.Repositories;
using BuildCalculator.Data.Parsers.Mappers;

namespace BuildCalculator.Data.Factories;

public readonly record struct SetStampDtoBag(
    IReadOnlyDictionary<ushort, string> Names,
    IReadOnlyDictionary<ushort, SetStampDto> SetStampDtos,
    IReadOnlyDictionary<ushort, string> Templates,
    IReadOnlyDictionary<byte, string> PassiveNames,
    IReadOnlyDictionary<byte, SetStampPassiveDto> PassiveDtos,
    IReadOnlyDictionary<byte, string> PassiveTemplates,
    IReadOnlyDictionary<byte, SetStampLevelGapDto[]> LevelGapDtos,
    IReadOnlyDictionary<byte, byte> FixedBasicStatDtos,
    IReadOnlyDictionary<byte, byte[]> PoolBasicStatDtos,
    IReadOnlyDictionary<byte, SetStampFixedBasicStatGrowthDto[]> FixedBasicStatGrowthDtos,
    IReadOnlyDictionary<byte, SetStampPoolBasicStatGrowthDto[]> PoolBasicStatGrowthDtos,
    IReadOnlyDictionary<byte, SetStampPoolAdvancedStatGrowthDto[]> PoolAdvancedStatGrowthDtos
);

public static class SetStampRepositoryFactory
{
    public static ResultData<SetStampRepository> Create(SetStampDtoBag dtoBag)
    {
        var setStamps = dtoBag.SetStampDtos.ToDictionary(
            kvp => kvp.Key,
            kvp => SetStampMapper.MapToSetStampDomain(kvp.Value));

        var passives = dtoBag.PassiveDtos.ToDictionary(
            kvp => kvp.Key,
            kvp => SetStampMapper.MapToPassiveDomain(kvp.Value));

        var levelGaps = dtoBag.LevelGapDtos.ToDictionary(
            kvp => kvp.Key,
            kvp => kvp.Value.Select(
                dto => SetStampMapper.MapToLevelGapDomain(dto)).ToArray());

        var fixedBasicStats = dtoBag.FixedBasicStatDtos.ToDictionary(
            kvp => kvp.Key,
            kvp => (StatType)kvp.Value);

        var poolBasicStats = dtoBag.PoolBasicStatDtos.ToDictionary(
            kvp => kvp.Key,
            kvp => kvp.Value.Select(
                dto => (StatType)dto).ToArray());

        var fixedBasicStatGrowths = dtoBag.FixedBasicStatGrowthDtos.ToDictionary(
            kvp => kvp.Key,
            kvp => kvp.Value.Select(
                dto => SetStampMapper.MapToFixedBasicStatGrowthDomain(dto)).ToArray());

        var poolBasicStatGrowths = dtoBag.PoolBasicStatGrowthDtos.ToDictionary(
            kvp => kvp.Key,
            kvp => kvp.Value.Select(
                dto => SetStampMapper.MapToPoolBasicStatGrowthDomain(dto)).ToArray());

        var poolAdvancedStatGrowths = dtoBag.PoolAdvancedStatGrowthDtos.ToDictionary(
            kvp => kvp.Key,
            kvp => kvp.Value.Select(
                dto => SetStampMapper.MapToPoolAdvancedStatGrowthDomain(dto)).ToArray());


        var dataBag = new SetStampDataBag(
            dtoBag.Names,
            setStamps,
            dtoBag.Templates,
            dtoBag.PassiveNames,
            passives,
            dtoBag.PassiveTemplates,
            levelGaps,
            fixedBasicStats,
            poolBasicStats,
            fixedBasicStatGrowths,
            poolBasicStatGrowths,
            poolAdvancedStatGrowths);

        var repository = new SetStampRepository(dataBag);

        return ResultData<SetStampRepository>.Ok(repository);
    }
}

