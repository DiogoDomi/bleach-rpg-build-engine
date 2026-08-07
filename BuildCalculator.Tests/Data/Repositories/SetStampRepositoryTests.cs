using Xunit;
using BuildCalculator.Data.Repositories;
using BuildCalculator.Domain;
using BuildCalculator.Domain.Enums;

namespace BuildCalculator.Tests.Data.Repositories;

public class SetStampRepositoryTests
{
    private SetStampRepository GetFakeRepository(
        IReadOnlyDictionary<ushort, string>? names = null,
        IReadOnlyDictionary<ushort, SetStamp>? setStamps = null,
        IReadOnlyDictionary<ushort, string>? templates = null,
        IReadOnlyDictionary<byte, string>? passiveNames = null,
        IReadOnlyDictionary<byte, SetStampPassive>? passives = null,
        IReadOnlyDictionary<byte, string>? passiveTemplates = null,
        IReadOnlyDictionary<byte, SetStampLevelGap[]>? levelGaps = null,
        IReadOnlyDictionary<byte, StatType>? fixedBasicStats = null,
        IReadOnlyDictionary<byte, StatType[]>? poolBasicStats = null,
        IReadOnlyDictionary<byte, SetStampFixedBasicStatGrowth[]>? fixedBasicStatGrowths = null,
        IReadOnlyDictionary<byte, SetStampPoolBasicStatGrowth[]>? poolBasicStatGrowths = null,
        IReadOnlyDictionary<byte, SetStampPoolAdvancedStatGrowth[]>? poolAdvancedStatGrowths = null)
    {

        var bag = new SetStampDataBag(
            names ?? new Dictionary<ushort, string>(),
            setStamps ?? new Dictionary<ushort, SetStamp>(),
            templates ?? new Dictionary<ushort, string>(),
            passiveNames ?? new Dictionary<byte, string>(),
            passives ?? new Dictionary<byte, SetStampPassive>(),
            passiveTemplates ?? new Dictionary<byte, string>(),
            levelGaps ?? new Dictionary<byte, SetStampLevelGap[]>(),
            fixedBasicStats ?? new Dictionary<byte, StatType>(),
            poolBasicStats ?? new Dictionary<byte, StatType[]>(),
            fixedBasicStatGrowths ?? new Dictionary<byte, SetStampFixedBasicStatGrowth[]>(),
            poolBasicStatGrowths ?? new Dictionary<byte, SetStampPoolBasicStatGrowth[]>(),
            poolAdvancedStatGrowths ?? new Dictionary<byte, SetStampPoolAdvancedStatGrowth[]>()
        );
        return new SetStampRepository(bag);
    }

    private IReadOnlyDictionary<ushort, string> GetFakeNames() => new Dictionary<ushort, string>
    {
        [1] = "Rising Black Moon",
        [2] = "Rising Black Moon"
    };

    private IReadOnlyDictionary<ushort, SetStamp> GetFakeSetStamps() => new Dictionary<ushort, SetStamp>
    {
        [1] = new(1, 1, 1),
        [2] = new(2, 1, 1)
    };

    private IReadOnlyDictionary<ushort, string> GetFakeTemplates() => new Dictionary<ushort, string>
    {
        [1] = "2-Piece: Increases Slash DMG by 11%.",
        [2] = "2-Piece: Increases Slash DMG by 11%."
    };

    private IReadOnlyDictionary<byte, string> GetFakePassiveNames() => new Dictionary<byte, string>
    {
        [1] = "Enhanced Basic Attack",
        [2] = "Enhanced Basic Attack"
    };

    private IReadOnlyDictionary<byte, SetStampPassive> GetFakePassives() => new Dictionary<byte, SetStampPassive>
    {
        [1] = new(1, 1, 1),
        [2] = new(2, 1, 1)
    };

    private IReadOnlyDictionary<byte, string> GetFakePassiveTemplates() => new Dictionary<byte, string>
    {
        [1] = "Increases Basic Attack DMG by 30%.",
        [2] = "Increases Basic Attack DMG by 30%."
    };

    private IReadOnlyDictionary<byte, SetStampLevelGap[]> GetFakeLevelGaps() => new Dictionary<byte, SetStampLevelGap[]>
    {
        [1] = [new(0, 10)],
        [2] = [new(0, 10)]
    };

    private IReadOnlyDictionary<byte, StatType> GetFakeFixedBasicStats() => new Dictionary<byte, StatType>
    {
        [1] = StatType.HpFlat,
        [2] = StatType.HpFlat
    };

    private IReadOnlyDictionary<byte, StatType[]> GetFakePoolBasicStats() => new Dictionary<byte, StatType[]>
    {
        [1] = [StatType.AtkPercent],
        [2] = [StatType.AtkFlat]
    };

    private IReadOnlyDictionary<byte, SetStampFixedBasicStatGrowth[]> GetFakeFixedBasicStatGrowths() => new Dictionary<byte, SetStampFixedBasicStatGrowth[]>
    {
        [1] = [new(125, 543, StarRating.V)],
        [2] = [new(125, 543, StarRating.V)]
    };

    private IReadOnlyDictionary<byte, SetStampPoolBasicStatGrowth[]> GetFakePoolBasicStatGrowths() => new Dictionary<byte, SetStampPoolBasicStatGrowth[]>
    {
        [1] = [new(4, 18, StatType.AtkPercent)],
        [2] = [new(4, 18, StatType.AtkFlat)]
    };

    private IReadOnlyDictionary<byte, SetStampPoolAdvancedStatGrowth[]> GetFakePoolAdvancedStatGrowths() => new Dictionary<byte, SetStampPoolAdvancedStatGrowth[]>
    {
        [1] = [new(10, 2, StatType.CritRate)],
        [2] = [new(10, 2, StatType.CritRate)]
    };

    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    public void TryGetName_IdIsValid_ReturnsTrueAndName(ushort nameId)
    {
        var fakeNames = GetFakeNames();
        var repo = GetFakeRepository(names: fakeNames);

        var result = repo.TryGetName(nameId, out var name);

        Assert.True(result);
        Assert.Equal(fakeNames[nameId], name);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(3)]
    public void TryGetName_IdIsInvalidOrNotFound_ReturnsFalseAndNull(ushort nameId)
    {
        var fakeNames = GetFakeNames();
        var repo = GetFakeRepository(names: fakeNames);

        var result = repo.TryGetName(nameId, out var name);

        Assert.False(result);
        Assert.Null(name);
    }

    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    public void TryGetSetStamp_IdIsValid_ReturnsTrueAndSetStamp(ushort setStampId)
    {
        var fakeSetStamps = GetFakeSetStamps();
        var repo = GetFakeRepository(setStamps: fakeSetStamps);

        var result = repo.TryGetSetStamp(setStampId, out var setStamp);

        Assert.True(result);
        Assert.Equal(fakeSetStamps[setStampId], setStamp);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(3)]
    public void TryGetSetStamp_IdIsInvalidOrNotFound_ReturnsFalseAndDefault(ushort setStampId)
    {
        var fakeSetStamps = GetFakeSetStamps();
        var repo = GetFakeRepository(setStamps: fakeSetStamps);

        var result = repo.TryGetSetStamp(setStampId, out var setStamp);

        Assert.False(result);
        Assert.Equal(default(SetStamp), setStamp);
    }

    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    public void TryGetTemplate_IdIsValid_ReturnsTrueAndTemplate(ushort templateId)
    {
        var fakeTemplates = GetFakeTemplates();
        var repo = GetFakeRepository(templates: fakeTemplates);

        var result = repo.TryGetTemplate(templateId, out var template);

        Assert.True(result);
        Assert.Equal(fakeTemplates[templateId], template);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(3)]
    public void TryGetTemplate_IdIsInvalidOrNotFound_ReturnsFalseAndNull(ushort templateId)
    {
        var fakeTemplates = GetFakeTemplates();
        var repo = GetFakeRepository(templates: fakeTemplates);

        var result = repo.TryGetTemplate(templateId, out var template);

        Assert.False(result);
        Assert.Null(template);
    }

    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    public void TryGetPassiveName_IdIsValid_ReturnsTrueAndPassiveName(byte passiveNameId)
    {
        var fakePassiveNames = GetFakePassiveNames();
        var repo = GetFakeRepository(passiveNames: fakePassiveNames);

        var result = repo.TryGetPassiveName(passiveNameId, out var passiveName);

        Assert.True(result);
        Assert.Equal(fakePassiveNames[passiveNameId], passiveName);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(3)]
    public void TryGetPassiveName_IdIsInvalidOrNotFound_ReturnsFalseAndNull(byte passiveNameId)
    {
        var fakePassiveNames = GetFakePassiveNames();
        var repo = GetFakeRepository(passiveNames: fakePassiveNames);

        var result = repo.TryGetPassiveName(passiveNameId, out var passiveName);

        Assert.False(result);
        Assert.Null(passiveName);
    }

    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    public void TryGetPassive_IdIsValid_ReturnsTrueAndPassive(byte passiveId)
    {
        var fakePassives = GetFakePassives();
        var repo = GetFakeRepository(passives: fakePassives);

        var result = repo.TryGetPassive(passiveId, out var passive);

        Assert.True(result);
        Assert.Equal(fakePassives[passiveId], passive);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(3)]
    public void TryGetPassive_IdIsInvalidOrNotFound_ReturnsFalseAndDefault(byte passiveId)
    {
        var fakePassives = GetFakePassives();
        var repo = GetFakeRepository(passives: fakePassives);

        var result = repo.TryGetPassive(passiveId, out var passive);

        Assert.False(result);
        Assert.Equal(default(SetStampPassive), passive);
    }

    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    public void TryGetPassiveTemplate_IdIsValid_ReturnsTrueAndPassiveTemplate(byte passiveTemplateId)
    {
        var fakePassiveTemplates = GetFakePassiveTemplates();
        var repo = GetFakeRepository(passiveTemplates: fakePassiveTemplates);

        var result = repo.TryGetPassiveTemplate(passiveTemplateId, out var passiveTemplate);

        Assert.True(result);
        Assert.Equal(fakePassiveTemplates[passiveTemplateId], passiveTemplate);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(3)]
    public void TryGetPassiveTemplate_IdIsInvalidOrNotFound_ReturnsFalseAndNull(byte passiveTemplateId)
    {
        var fakePassiveTemplates = GetFakePassiveTemplates();
        var repo = GetFakeRepository(passiveTemplates: fakePassiveTemplates);

        var result = repo.TryGetPassiveTemplate(passiveTemplateId, out var passiveTemplate);

        Assert.False(result);
        Assert.Null(passiveTemplate);
    }

    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    public void TryGetLevelGaps_IdIsValid_ReturnsTrueAndLevelGaps(byte key)
    {
        var fakeLevelGaps = GetFakeLevelGaps();
        var repo = GetFakeRepository(levelGaps: fakeLevelGaps);

        var result = repo.TryGetLevelGaps(key, out var levelGaps);

        Assert.True(result);
        Assert.Equal(fakeLevelGaps[key], levelGaps);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(3)]
    public void TryGetLevelGaps_IdIsInvalidOrNotFound_ReturnsFalseAndNull(byte key)
    {
        var fakeLevelGaps = GetFakeLevelGaps();
        var repo = GetFakeRepository(levelGaps: fakeLevelGaps);

        var result = repo.TryGetLevelGaps(key, out var levelGaps);

        Assert.False(result);
        Assert.Null(levelGaps);
    }

    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    public void TryGetFixedBasicStat_IdIsValid_ReturnsTrueAndFixedBasicStat(byte key)
    {
        var fakeFixedBasicStats = GetFakeFixedBasicStats();
        var repo = GetFakeRepository(fixedBasicStats: fakeFixedBasicStats);

        var result = repo.TryGetFixedBasicStat(key, out var fixedBasicStat);

        Assert.True(result);
        Assert.Equal(fakeFixedBasicStats[key], fixedBasicStat);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(3)]
    public void TryGetFixedBasicStat_IdIsInvalidOrNotFound_ReturnsFalseAndDefault(byte key)
    {
        var fakeFixedBasicStats = GetFakeFixedBasicStats();
        var repo = GetFakeRepository(fixedBasicStats: fakeFixedBasicStats);

        var result = repo.TryGetFixedBasicStat(key, out var fixedBasicStat);

        Assert.False(result);
        Assert.Equal(default(StatType), fixedBasicStat);
    }

    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    public void TryGetPoolBasicStats_IdIsValid_ReturnsTrueAndPoolBasicStats(byte key)
    {
        var fakePoolBasicStats = GetFakePoolBasicStats();
        var repo = GetFakeRepository(poolBasicStats: fakePoolBasicStats);

        var result = repo.TryGetPoolBasicStats(key, out var poolBasicStats);

        Assert.True(result);
        Assert.Equal(fakePoolBasicStats[key], poolBasicStats);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(3)]
    public void TryGetPoolBasicStats_IdIsInvalidOrNotFound_ReturnsFalseAndNull(byte key)
    {
        var fakePoolBasicStats = GetFakePoolBasicStats();
        var repo = GetFakeRepository(poolBasicStats: fakePoolBasicStats);

        var result = repo.TryGetPoolBasicStats(key, out var poolBasicStats);

        Assert.False(result);
        Assert.Null(poolBasicStats);
    }

    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    public void TryGetFixedBasicStatGrowths_IdIsValid_ReturnsTrueAndGrowths(byte key)
    {
        var fakeGrowths = GetFakeFixedBasicStatGrowths();
        var repo = GetFakeRepository(fixedBasicStatGrowths: fakeGrowths);

        var result = repo.TryGetFixedBasicStatGrowths(key, out var growths);

        Assert.True(result);
        Assert.Equal(fakeGrowths[key], growths);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(3)]
    public void TryGetFixedBasicStatGrowths_IdIsInvalidOrNotFound_ReturnsFalseAndNull(byte key)
    {
        var fakeGrowths = GetFakeFixedBasicStatGrowths();
        var repo = GetFakeRepository(fixedBasicStatGrowths: fakeGrowths);

        var result = repo.TryGetFixedBasicStatGrowths(key, out var growths);

        Assert.False(result);
        Assert.Null(growths);
    }

    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    public void TryGetPoolBasicStatGrowths_IdIsValid_ReturnsTrueAndGrowths(byte key)
    {
        var fakeGrowths = GetFakePoolBasicStatGrowths();
        var repo = GetFakeRepository(poolBasicStatGrowths: fakeGrowths);

        var result = repo.TryGetPoolBasicStatGrowths(key, out var growths);

        Assert.True(result);
        Assert.Equal(fakeGrowths[key], growths);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(3)]
    public void TryGetPoolBasicStatGrowths_IdIsInvalidOrNotFound_ReturnsFalseAndNull(byte key)
    {
        var fakeGrowths = GetFakePoolBasicStatGrowths();
        var repo = GetFakeRepository(poolBasicStatGrowths: fakeGrowths);

        var result = repo.TryGetPoolBasicStatGrowths(key, out var growths);

        Assert.False(result);
        Assert.Null(growths);
    }

    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    public void TryGetPoolAdvancedStatGrowths_IdIsValid_ReturnsTrueAndGrowths(byte key)
    {
        var fakeGrowths = GetFakePoolAdvancedStatGrowths();
        var repo = GetFakeRepository(poolAdvancedStatGrowths: fakeGrowths);

        var result = repo.TryGetPoolAdvancedStatGrowths(key, out var growths);

        Assert.True(result);
        Assert.Equal(fakeGrowths[key], growths);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(3)]
    public void TryGetPoolAdvancedStatGrowths_IdIsInvalidOrNotFound_ReturnsFalseAndNull(byte key)
    {
        var fakeGrowths = GetFakePoolAdvancedStatGrowths();
        var repo = GetFakeRepository(poolAdvancedStatGrowths: fakeGrowths);

        var result = repo.TryGetPoolAdvancedStatGrowths(key, out var growths);

        Assert.False(result);
        Assert.Null(growths);
    }
}

