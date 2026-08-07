using Xunit;
using BuildCalculator.Data.Repositories;
using BuildCalculator.Domain;
using BuildCalculator.Domain.Enums;

namespace BuildCalculator.Tests.Data.Repositories;

public class BoundaryRepositoryTests
{
    private BoundaryRepository GetFakeRepository(
        IReadOnlyDictionary<byte, string>? ascensions = null,
        IReadOnlyDictionary<byte, string>? types = null,
        IReadOnlyDictionary<ushort, string>? skillNames = null,
        IReadOnlyDictionary<ushort, Boundary[]>? boundaries = null,
        IReadOnlyDictionary<ushort, string>? templates = null)
    {
        var bag = new BoundaryDataBag(
            ascensions ?? new Dictionary<byte, string>(),
            types ?? new Dictionary<byte, string>(),
            skillNames ?? new Dictionary<ushort, string>(),
            boundaries ?? new Dictionary<ushort, Boundary[]>(),
            templates ?? new Dictionary<ushort, string>()
        );
        return new BoundaryRepository(bag);
    }

    private IReadOnlyDictionary<byte, string> GetFakeAscensions() => new Dictionary<byte, string>
    {
        [1] = "I",
        [2] = "I"
    };

    private IReadOnlyDictionary<byte, string> GetFakeTypes() => new Dictionary<byte, string>
    {
        [1] = "Obtain Skill",
        [2] = "Obtain Skill"
    };

    private IReadOnlyDictionary<ushort, string> GetFakeSkillNames() => new Dictionary<ushort, string>
    {
        [1] = "Lonely Moon",
        [2] = "Lonely Moon"
    };

    private IReadOnlyDictionary<ushort, Boundary[]> GetFakeBoundaries() => new Dictionary<ushort, Boundary[]>
    {
        [1] = [new(1, 1, null, 1, 1)],
        [2] = [new(null, 1, 5, 1, 1)]
    };

    private IReadOnlyDictionary<ushort, string> GetFakeTemplates() => new Dictionary<ushort, string>
    {
        [1] = "When Byakuya Kuchiki releases his Ultimate, he immediately gains 30% Spiritual Pressure.",
        [2] = "When Byakuya Kuchiki releases his Ultimate, he immediately gains 30% Spiritual Pressure."
    };

    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    public void TryGetAscension_IdIsValid_ReturnsTrueAndAscension(byte ascensionId)
    {
        var fakeAscensions = GetFakeAscensions();
        var repo = GetFakeRepository(ascensions: fakeAscensions);

        var result = repo.TryGetAscension(ascensionId, out var ascension);

        Assert.True(result);
        Assert.Equal(fakeAscensions[ascensionId], ascension);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(3)]
    public void TryGetAscension_IdIsInvalidOrNotFound_ReturnsFalseAndNull(byte ascensionId)
    {
        var fakeAscensions = GetFakeAscensions();
        var repo = GetFakeRepository(ascensions: fakeAscensions);

        var result = repo.TryGetAscension(ascensionId, out var ascension);

        Assert.False(result);
        Assert.Null(ascension);
    }

    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    public void TryGetType_IdIsValid_ReturnsTrueAndType(byte typeId)
    {
        var fakeTypes = GetFakeTypes();
        var repo = GetFakeRepository(types: fakeTypes);

        var result = repo.TryGetType(typeId, out var typeName);

        Assert.True(result);
        Assert.Equal(fakeTypes[typeId], typeName);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(3)]
    public void TryGetType_IdIsInvalidOrNotFound_ReturnsFalseAndNull(byte typeId)
    {
        var fakeTypes = GetFakeTypes();
        var repo = GetFakeRepository(types: fakeTypes);

        var result = repo.TryGetType(typeId, out var typeName);

        Assert.False(result);
        Assert.Null(typeName);
    }

    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    public void TryGetSkillName_IdIsValid_ReturnsTrueAndSkillName(ushort skillNameId)
    {
        var fakeSkillNames = GetFakeSkillNames();
        var repo = GetFakeRepository(skillNames: fakeSkillNames);

        var result = repo.TryGetSkillName(skillNameId, out var skillName);

        Assert.True(result);
        Assert.Equal(fakeSkillNames[skillNameId], skillName);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(3)]
    public void TryGetSkillName_IdIsInvalidOrNotFound_ReturnsFalseAndNull(ushort skillNameId)
    {
        var fakeSkillNames = GetFakeSkillNames();
        var repo = GetFakeRepository(skillNames: fakeSkillNames);

        var result = repo.TryGetSkillName(skillNameId, out var skillName);

        Assert.False(result);
        Assert.Null(skillName);
    }

    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    public void TryGetBoundaries_IdIsValid_ReturnsTrueAndBoundaries(ushort key)
    {
        var fakeBoundaries = GetFakeBoundaries();
        var repo = GetFakeRepository(boundaries: fakeBoundaries);

        var result = repo.TryGetBoundaries(key, out var boundaries);

        Assert.True(result);
        Assert.Equal(fakeBoundaries[key], boundaries);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(3)]
    public void TryGetBoundaries_IdIsInvalidOrNotFound_ReturnsFalseAndNull(ushort key)
    {
        var fakeBoundaries = GetFakeBoundaries();
        var repo = GetFakeRepository(boundaries: fakeBoundaries);

        var result = repo.TryGetBoundaries(key, out var boundaries);

        Assert.False(result);
        Assert.Null(boundaries);
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

