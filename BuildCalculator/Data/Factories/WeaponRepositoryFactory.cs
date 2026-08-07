using BuildCalculator.Data.Dtos;
using BuildCalculator.Core;
using BuildCalculator.Data.Repositories;
using BuildCalculator.Data.Parsers.Mappers;

namespace BuildCalculator.Data.Factories;

public readonly record struct WeaponDtoBag(
    IReadOnlyDictionary<ushort, string> Names,
    IReadOnlyDictionary<byte, string> Types,
    IReadOnlyDictionary<ushort, WeaponDto> WeaponDtos,
    IReadOnlyDictionary<ushort, WeaponBaseStatDto[]> BaseStatDtos
);

public static class WeaponRepositoryFactory
{
    public static ResultData<WeaponRepository> Create(WeaponDtoBag dtoBag)
    {
        var weapons = dtoBag.WeaponDtos.ToDictionary(
            kvp => kvp.Key,
            kvp => WeaponMapper.MapToWeaponDomain(kvp.Value));

        var baseStats = dtoBag.BaseStatDtos.ToDictionary(
            kvp => kvp.Key,
            kvp => kvp.Value.Select(
                dto => WeaponMapper.MapToBaseStatDomain(dto)).ToArray());

        var dataBag = new WeaponDataBag(
            dtoBag.Names,
            dtoBag.Types,
            weapons,
            baseStats);

        var repository = new WeaponRepository(dataBag);

        return ResultData<WeaponRepository>.Ok(repository);
    }
}

