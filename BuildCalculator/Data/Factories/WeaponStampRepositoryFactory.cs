using BuildCalculator.Data.Dtos;
using BuildCalculator.Core;
using BuildCalculator.Data.Repositories;
using BuildCalculator.Data.Parsers.Mappers;

namespace BuildCalculator.Data.Factories;

public readonly record struct WeaponStampDtoBag(
    IReadOnlyDictionary<ushort, string> Names,
    IReadOnlyDictionary<ushort, WeaponStampDto> WeaponStampDtos,
    IReadOnlyDictionary<ushort, string> Templates
);

public static class WeaponStampRepositoryFactory
{
    public static ResultData<WeaponStampRepository> Create(WeaponStampDtoBag dtoBag)
    {
        var weaponStamps = dtoBag.WeaponStampDtos.ToDictionary(
            kvp => kvp.Key,
            kvp => WeaponStampMapper.MapToWeaponStampDomain(kvp.Value));

        var dataBag = new WeaponStampDataBag(
            dtoBag.Names,
            weaponStamps,
            dtoBag.Templates);

        var repository = new WeaponStampRepository(dataBag);

        return ResultData<WeaponStampRepository>.Ok(repository);
    }
}

