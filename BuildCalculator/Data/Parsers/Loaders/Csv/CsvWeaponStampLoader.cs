using BuildCalculator.Core;
using BuildCalculator.Data.Dtos;
using BuildCalculator.Data.Repositories;
using BuildCalculator.Data.Parsers.Builders.Csv;
using BuildCalculator.Data.Factories;

namespace BuildCalculator.Data.Parsers.Loaders.Csv;

public static class CsvWeaponStampLoader
{
    public static ResultData<WeaponStampRepository> LoadRepository(string csvDirPath)
    {
        var nameData = CsvSharedLoaders.ExecuteLoader(
            csvDirPath, "weapon_stamp_names.csv",
            reader => CsvSharedLoaders.LoadSingleDomainData<ushort, string>(
                reader, CsvSharedBuilders.BuildIdAndText<ushort>));

        if (!nameData.IsSuccess)
            return ResultData<WeaponStampRepository>.Fail(nameData.Error,
                $"[LoadWeaponStampRepository] (nameData) Failed to load names -> {nameData.Message}");

        var weaponStampData = CsvSharedLoaders.ExecuteLoader(
            csvDirPath, "weapon_stamps.csv",
            reader => CsvSharedLoaders.LoadSingleDomainData<ushort, WeaponStampDto>(
                reader, CsvWeaponStampBuilder.BuildWeaponStampDto));

        if (!weaponStampData.IsSuccess)
            return ResultData<WeaponStampRepository>.Fail(weaponStampData.Error,
                $"[LoadWeaponStampRepository] (weaponStampData) Failed to load weaponStamps -> {weaponStampData.Message}");

        var templateData = CsvSharedLoaders.ExecuteLoader(
            csvDirPath, "weapon_stamp_templates.csv",
            reader => CsvSharedLoaders.LoadSingleDomainData<ushort, string>(
                reader, CsvSharedBuilders.BuildIdAndText<ushort>));

        if (!templateData.IsSuccess)
            return ResultData<WeaponStampRepository>.Fail(templateData.Error,
                $"[LoadWeaponStampRepository] (templateData) Failed to load templates -> {templateData.Message}");

        var dtoBag = new WeaponStampDtoBag(
            nameData.Item,
            weaponStampData.Item,
            templateData.Item);

        return WeaponStampRepositoryFactory.Create(dtoBag);
    }
}

