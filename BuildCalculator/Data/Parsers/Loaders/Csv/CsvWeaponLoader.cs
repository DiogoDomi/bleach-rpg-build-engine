using BuildCalculator.Core;
using BuildCalculator.Data.Dtos;
using BuildCalculator.Data.Repositories;
using BuildCalculator.Data.Parsers.Builders.Csv;
using BuildCalculator.Data.Factories;

namespace BuildCalculator.Data.Parsers.Loaders.Csv;

public static class CsvWeaponLoader
{
    public static ResultData<WeaponRepository> LoadRepository(string csvDirPath)
    {
        var nameData = CsvSharedLoaders.ExecuteLoader(csvDirPath, "weapon_names.csv",
            reader => CsvSharedLoaders.LoadSingleDomainData<ushort, string>(
                reader, CsvSharedBuilders.BuildIdAndText<ushort>));

        if (!nameData.IsSuccess)
            return ResultData<WeaponRepository>.Fail(nameData.Error,
                $"[LoadWeaponRepository] (nameData) Failed to load names -> {nameData.Message}");

        var typeData = CsvSharedLoaders.ExecuteLoader(csvDirPath, "weapon_types.csv",
            reader => CsvSharedLoaders.LoadSingleDomainData<byte, string>(
                reader, CsvSharedBuilders.BuildIdAndText<byte>));

        if (!typeData.IsSuccess)
            return ResultData<WeaponRepository>.Fail(typeData.Error,
                $"[LoadWeaponRepository] (typeData) Failed to load types -> {typeData.Message}");

        var weaponData = CsvSharedLoaders.ExecuteLoader(csvDirPath, "weapons.csv",
                reader => CsvSharedLoaders.LoadSingleDomainData<ushort, WeaponDto>(
                    reader, CsvWeaponBuilder.BuildWeaponDto));

        if (!weaponData.IsSuccess)
            return ResultData<WeaponRepository>.Fail(weaponData.Error,
                $"[LoadWeaponRepository] (weaponData) Failed to load weapons -> {weaponData.Message}");

        var baseStatData = CsvSharedLoaders.ExecuteLoader(csvDirPath, "weapon_base_stats.csv",
                reader => CsvSharedLoaders.LoadManyDomainData<ushort, WeaponBaseStatDto>(
                    reader, CsvWeaponBuilder.BuildBaseStatDto));

        if (!baseStatData.IsSuccess)
            return ResultData<WeaponRepository>.Fail(baseStatData.Error,
                $"[LoadWeaponRepository] (baseStatsData) Failed to load baseStats -> {baseStatData.Message}");

        var dtoBag = new WeaponDtoBag(
            nameData.Item,
            typeData.Item,
            weaponData.Item,
            baseStatData.Item
        );

        return WeaponRepositoryFactory.Create(dtoBag);
    }
}

