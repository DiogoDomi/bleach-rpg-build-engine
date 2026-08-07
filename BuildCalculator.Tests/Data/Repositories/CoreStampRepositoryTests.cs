using Xunit;
using BuildCalculator.Data.Repositories;
using BuildCalculator.Domain;
using BuildCalculator.Domain.Enums;

namespace BuildCalculator.Tests.Data.Repositories;

public class CoreStampRepositoryTests
{
    private CoreStampRepository GetFakeRepository(
        IReadOnlyDictionary<ushort, string>? names = null,
        IReadOnlyDictionary<ushort, CoreStamp>? coreStamps = null,
        IReadOnlyDictionary<ushort, string>? templates = null,
        IReadOnlyDictionary<ushort, CoreStampBaseStat[]>? baseStats = null)
    {

        var bag = new CoreStampDataBag(
            names ?? new Dictionary<ushort, string>(),
            coreStamps ?? new Dictionary<ushort, CoreStamp>(),
            templates ?? new Dictionary<ushort, string>(),
            baseStats ?? new Dictionary<ushort, CoreStampBaseStat[]>()
        );
        return new CoreStampRepository(bag);
    }

    private IReadOnlyDictionary<ushort, string> GetFakeNames() => new Dictionary<ushort, string>
    {
        [1] = "To Reach Higher Places",
        [2] = "To Reach Higher Places"
    };

    private IReadOnlyDictionary<ushort, CoreStamp> GetFakeCoreStamps() => new Dictionary<ushort, CoreStamp>
    {
        [1] = new(1, 1, 1, 1, Rarity.Ssr, StarRating.VI),
        [2] = new(null, 2, 1, 1, Rarity.Ssr, StarRating.VI)
    };

    private IReadOnlyDictionary<ushort, string> GetFakeTemplates() => new Dictionary<ushort, string>
    {
        [1] = "As the combo count goes up, the on-field characters’ basic attack DMG increases by 6.5%, up to 10 times.",
        [2] = "As the combo count goes up, the on-field characters’ basic attack DMG increases by 6.5%, up to 10 times."
    };

    private IReadOnlyDictionary<ushort, CoreStampBaseStat[]> GetFakeBaseStats() => new Dictionary<ushort, CoreStampBaseStat[]>
    {
        [1] = [new(113, 488, StatType.HpFlat)],
        [2] = [new(113, 488, StatType.HpFlat)]
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
    public void TryGetCoreStamp_IdIsValid_ReturnsTrueAndCoreStamp(ushort coreStampId)
    {
        var fakeCoreStamps = GetFakeCoreStamps();
        var repo = GetFakeRepository(coreStamps: fakeCoreStamps);

        var result = repo.TryGetCoreStamp(coreStampId, out var coreStamp);

        Assert.True(result);
        Assert.Equal(fakeCoreStamps[coreStampId], coreStamp);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(3)]
    public void TryGetCoreStamp_IdIsInvalidOrNotFound_ReturnsFalseAndDefault(ushort coreStampId)
    {
        var fakeCoreStamps = GetFakeCoreStamps();
        var repo = GetFakeRepository(coreStamps: fakeCoreStamps);

        var result = repo.TryGetCoreStamp(coreStampId, out var coreStamp);

        Assert.False(result);
        Assert.Equal(default(CoreStamp), coreStamp);
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
    public void TryGetBaseStats_IdIsValid_ReturnsTrueAndBaseStats(ushort coreStampId)
    {
        var fakeBaseStats = GetFakeBaseStats();
        var repo = GetFakeRepository(baseStats: fakeBaseStats);

        var result = repo.TryGetBaseStats(coreStampId, out var baseStats);

        Assert.True(result);
        Assert.Equal(fakeBaseStats[coreStampId], baseStats);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(3)]
    public void TryGetBaseStats_IdIsInvalidOrNotFound_ReturnsFalseAndNull(ushort coreStampId)
    {
        var fakeBaseStats = GetFakeBaseStats();
        var repo = GetFakeRepository(baseStats: fakeBaseStats);

        var result = repo.TryGetBaseStats(coreStampId, out var baseStats);

        Assert.False(result);
        Assert.Null(baseStats);
    }
}

