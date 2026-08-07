using BuildCalculator.Core;
using BuildCalculator.Data.Repositories;
using BuildCalculator.Data.Parsers.Builders.Csv;
using BuildCalculator.Data.Dtos;
using BuildCalculator.Data.Factories;

namespace BuildCalculator.Data.Parsers.Loaders.Csv;

public static class CsvCharacterLoader
{
    public static ResultData<CharacterRepository> LoadRepository(string csvDirPath)
    {
        var nameData = CsvSharedLoaders.ExecuteLoader(
            csvDirPath, "character_names.csv",
            reader => CsvSharedLoaders.LoadSingleDomainData<ushort, string>(
                reader, CsvSharedBuilders.BuildIdAndText<ushort>));

        if (!nameData.IsSuccess)
            return ResultData<CharacterRepository>.Fail(nameData.Error,
                $"[LoadCharacterRepository] (nameData) Failed to load names -> {nameData.Message}");

        var affinityData = CsvSharedLoaders.ExecuteLoader(
            csvDirPath, "character_affinities.csv",
            reader => CsvSharedLoaders.LoadSingleDomainData<byte, string>(
                reader, CsvSharedBuilders.BuildIdAndText<byte>));

        if (!affinityData.IsSuccess)
            return ResultData<CharacterRepository>.Fail(affinityData.Error,
                $"[LoadCharacterRepository] (affinityData) Failed to load affinities -> {affinityData.Message}");

        var roleData = CsvSharedLoaders.ExecuteLoader(
            csvDirPath, "character_roles.csv",
            reader => CsvSharedLoaders.LoadSingleDomainData<byte, CharacterRoleDto>(
                reader, CsvCharacterBuilder.BuildCharacterRoleDto));

        if (!roleData.IsSuccess)
            return ResultData<CharacterRepository>.Fail(roleData.Error,
                $"[LoadCharacterRepository] (roleData) Failed to load roles -> {roleData.Message}");

        var factionData = CsvSharedLoaders.ExecuteLoader(
            csvDirPath, "character_factions.csv",
            reader => CsvSharedLoaders.LoadSingleDomainData<byte, string>(
                reader, CsvSharedBuilders.BuildIdAndText<byte>));

        if (!factionData.IsSuccess)
            return ResultData<CharacterRepository>.Fail(factionData.Error,
                $"[LoadCharacterRepository] (factionData) Failed to load factions -> {factionData.Message}");

        var characterData = CsvSharedLoaders.ExecuteLoader(
            csvDirPath, "characters.csv",
            reader => CsvSharedLoaders.LoadSingleDomainData<ushort, CharacterDto>(
                reader, CsvCharacterBuilder.BuildCharacterDto));

        if (!characterData.IsSuccess)
            return ResultData<CharacterRepository>.Fail(characterData.Error,
                $"[LoadCharacterRepository] (characterData) Failed to load characters -> {characterData.Message}");

        var baseStatData = CsvSharedLoaders.ExecuteLoader(
            csvDirPath, "character_base_stats.csv",
            reader => CsvSharedLoaders.LoadManyDomainData<ushort, CharacterBaseStatDto>(
                reader, CsvCharacterBuilder.BuildBaseStatDto));

        if (!baseStatData.IsSuccess)
            return ResultData<CharacterRepository>.Fail(baseStatData.Error,
                $"[LoadCharacterRepository] (baseStatData) Failed to load baseStats -> {baseStatData.Message}");

        var dtoBag = new CharacterDtoBag(
            nameData.Item,
            affinityData.Item,
            roleData.Item,
            factionData.Item,
            characterData.Item,
            baseStatData.Item);

        return CharacterRepositoryFactory.Create(dtoBag);
    }
}

