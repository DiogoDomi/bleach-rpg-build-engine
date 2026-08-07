using Xunit;
using BuildCalculator.Data.Repositories;
using BuildCalculator.Domain;
using BuildCalculator.Domain.Enums;

namespace BuildCalculator.Tests.Data.Repositories;

public class WeaponStampRepositoryTests
{
    private WeaponStampRepository GetFakeRepository(
        IReadOnlyDictionary<ushort, string>? names = null,
        IReadOnlyDictionary<ushort, WeaponStamp>? weaponStamps = null,
        IReadOnlyDictionary<ushort, string>? templates = null)
    {
        var bag = new WeaponStampDataBag(
            names ?? new Dictionary<ushort, string>(),
            weaponStamps ?? new Dictionary<ushort, WeaponStamp>(),
            templates ?? new Dictionary<ushort, string>()
        );

        return new WeaponStampRepository(bag);
    }

    private IReadOnlyDictionary<ushort, string> GetFakeNames() => new Dictionary<ushort, string>
    {
        [1] = "Shukei Hakuteiken",
        [2] = "Shukei Hakuteiken"
    };

    private IReadOnlyDictionary<ushort, WeaponStamp> GetFakeWeaponStamps() => new Dictionary<ushort, WeaponStamp>
    {
        [1] = new(1, 1, 1, 1, Rarity.Ssr, 50),
        [2] = new(null, 2, 1, 1, Rarity.Ssr, 50)
    };

    private IReadOnlyDictionary<ushort, string> GetFakeTemplates() => new Dictionary<ushort, string>
    {
        [1] = "Byakuya Kuchiki gains 2 extra Battlefield Skill Energy every time he release his technique.",
        [2] = "Byakuya Kuchiki gains 2 extra Battlefield Skill Energy every time he release his technique."
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
    public void TryGetWeaponStamp_IdIsValid_ReturnsTrueAndWeaponStamp(ushort weaponStampId)
    {
        var fakeWeaponStamps = GetFakeWeaponStamps();
        var repo = GetFakeRepository(weaponStamps: fakeWeaponStamps);

        var result = repo.TryGetWeaponStamp(weaponStampId, out var weaponStamp);

        Assert.True(result);
        Assert.Equal(fakeWeaponStamps[weaponStampId], weaponStamp);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(3)]
    public void TryGetWeaponStamp_IdIsInvalidOrNotFound_ReturnsFalseAndDefault(ushort weaponStampId)
    {
        var fakeWeaponStamps = GetFakeWeaponStamps();
        var repo = GetFakeRepository(weaponStamps: fakeWeaponStamps);

        var result = repo.TryGetWeaponStamp(weaponStampId, out var weaponStamp);

        Assert.False(result);
        Assert.Equal(default(WeaponStamp), weaponStamp);
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
}

