using BuildCalculator.Domain;
using BuildCalculator.Domain.Enums;

namespace BuildCalculator.Data.Repositories;

public readonly record struct SetStampDataBag(
    IReadOnlyDictionary<ushort, string> Names,
    IReadOnlyDictionary<ushort, SetStamp> SetStamps,
    IReadOnlyDictionary<ushort, string> Templates,
    IReadOnlyDictionary<byte, string> PassiveNames,
    IReadOnlyDictionary<byte, SetStampPassive> Passives,
    IReadOnlyDictionary<byte, string> PassiveTemplates,
    IReadOnlyDictionary<byte, SetStampLevelGap[]> LevelGaps,
    IReadOnlyDictionary<byte, StatType> FixedBasicStats,
    IReadOnlyDictionary<byte, StatType[]> PoolBasicStats,
    IReadOnlyDictionary<byte, SetStampFixedBasicStatGrowth[]> FixedBasicStatGrowths,
    IReadOnlyDictionary<byte, SetStampPoolBasicStatGrowth[]> PoolBasicStatGrowths,
    IReadOnlyDictionary<byte, SetStampPoolAdvancedStatGrowth[]> PoolAdvancedStatGrowths
);

public class SetStampRepository
{
    private readonly IReadOnlyDictionary<ushort, string> _names;
    private readonly IReadOnlyDictionary<ushort, SetStamp> _setStamps;
    private readonly IReadOnlyDictionary<ushort, string> _templates;
    private readonly IReadOnlyDictionary<byte, string> _passiveNames;
    private readonly IReadOnlyDictionary<byte, SetStampPassive> _passives;
    private readonly IReadOnlyDictionary<byte, string> _passiveTemplates;
    private readonly IReadOnlyDictionary<byte, SetStampLevelGap[]> _levelGaps;
    private readonly IReadOnlyDictionary<byte, StatType> _fixedBasicStats;
    private readonly IReadOnlyDictionary<byte, StatType[]> _poolBasicStats;
    private readonly IReadOnlyDictionary<byte, SetStampFixedBasicStatGrowth[]> _fixedBasicStatGrowths;
    private readonly IReadOnlyDictionary<byte, SetStampPoolBasicStatGrowth[]> _poolBasicStatGrowths;
    private readonly IReadOnlyDictionary<byte, SetStampPoolAdvancedStatGrowth[]> _poolAdvancedStatGrowths;

    public SetStampRepository(SetStampDataBag bag)
    {
        _names = bag.Names;
        _setStamps = bag.SetStamps;
        _templates = bag.Templates;
        _passiveNames = bag.PassiveNames;
        _passives = bag.Passives;
        _passiveTemplates = bag.PassiveTemplates;
        _levelGaps = bag.LevelGaps;
        _fixedBasicStats = bag.FixedBasicStats;
        _poolBasicStats = bag.PoolBasicStats;
        _fixedBasicStatGrowths = bag.FixedBasicStatGrowths;
        _poolBasicStatGrowths = bag.PoolBasicStatGrowths;
        _poolAdvancedStatGrowths = bag.PoolAdvancedStatGrowths;
    }

    public IReadOnlyDictionary<ushort, string> GetNames() => _names;
    public IReadOnlyDictionary<ushort, SetStamp> GetSetStamps() => _setStamps;
    public IReadOnlyDictionary<ushort, string> GetTemplates() => _templates;
    public IReadOnlyDictionary<byte, string> GetPassiveNames() => _passiveNames;
    public IReadOnlyDictionary<byte, SetStampPassive> GetPassives() => _passives;
    public IReadOnlyDictionary<byte, string> GetPassiveTemplates() => _passiveTemplates;
    public IReadOnlyDictionary<byte, SetStampLevelGap[]> GetLevelGaps() => _levelGaps;
    public IReadOnlyDictionary<byte, StatType> GetFixedBasicStats() => _fixedBasicStats;
    public IReadOnlyDictionary<byte, StatType[]> GetPoolBasicStats() => _poolBasicStats;
    public IReadOnlyDictionary<byte, SetStampFixedBasicStatGrowth[]> GetFixedBasicStatGrowths() => _fixedBasicStatGrowths;
    public IReadOnlyDictionary<byte, SetStampPoolBasicStatGrowth[]> GetPoolBasicStatGrowths() => _poolBasicStatGrowths;
    public IReadOnlyDictionary<byte, SetStampPoolAdvancedStatGrowth[]> GetPoolAdvancedStatGrowths() => _poolAdvancedStatGrowths;

    public bool TryGetName(ushort nameId, out string? name)
    {
        if (nameId == 0)
        {
            name = default!;
            return false;
        }
        return _names.TryGetValue(nameId, out name);
    }

    public bool TryGetSetStamp(ushort setStampId, out SetStamp setStamp)
    {
        if (setStampId == 0)
        {
            setStamp = default!;
            return false;
        }
        return _setStamps.TryGetValue(setStampId, out setStamp);
    }

    public bool TryGetTemplate(ushort templateId, out string? template)
    {
        if (templateId == 0)
        {
            template = default!;
            return false;
        }
        return _templates.TryGetValue(templateId, out template);
    }

    public bool TryGetPassiveName(byte passiveNameId, out string? passiveName)
    {
        if (passiveNameId == 0)
        {
            passiveName = default!;
            return false;
        }
        return _passiveNames.TryGetValue(passiveNameId, out passiveName);
    }

    public bool TryGetPassive(byte passiveId, out SetStampPassive passive)
    {
        if (passiveId == 0)
        {
            passive = default!;
            return false;
        }
        return _passives.TryGetValue(passiveId, out passive);
    }

    public bool TryGetPassiveTemplate(byte passiveTemplateId, out string? passiveTemplate)
    {
        if (passiveTemplateId == 0)
        {
            passiveTemplate = default!;
            return false;
        }
        return _passiveTemplates.TryGetValue(passiveTemplateId, out passiveTemplate);
    }

    public bool TryGetLevelGaps(byte key, out SetStampLevelGap[]? levelGaps)
    {
        if (key == 0)
        {
            levelGaps = default!;
            return false;
        }
        return _levelGaps.TryGetValue(key, out levelGaps);
    }

    public bool TryGetFixedBasicStat(byte key, out StatType fixedBasicStat)
    {
        if (key == 0)
        {
            fixedBasicStat = default!;
            return false;
        }
        return _fixedBasicStats.TryGetValue(key, out fixedBasicStat);
    }

    public bool TryGetPoolBasicStats(byte key, out StatType[]? poolBasicStats)
    {
        if (key == 0)
        {
            poolBasicStats = default!;
            return false;
        }
        return _poolBasicStats.TryGetValue(key, out poolBasicStats);
    }

    public bool TryGetFixedBasicStatGrowths(byte key, out SetStampFixedBasicStatGrowth[]? growths)
    {
        if (key == 0)
        {
            growths = default!;
            return false;
        }
        return _fixedBasicStatGrowths.TryGetValue(key, out growths);
    }

    public bool TryGetPoolBasicStatGrowths(byte key, out SetStampPoolBasicStatGrowth[]? growths)
    {
        if (key == 0)
        {
            growths = default!;
            return false;
        }
        return _poolBasicStatGrowths.TryGetValue(key, out growths);
    }

    public bool TryGetPoolAdvancedStatGrowths(byte key, out SetStampPoolAdvancedStatGrowth[]? growths)
    {
        if (key == 0)
        {
            growths = default!;
            return false;
        }
        return _poolAdvancedStatGrowths.TryGetValue(key, out growths);
    }
}
