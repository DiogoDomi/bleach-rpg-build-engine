using Xunit;
using BuildCalculator.Data.Repositories;
using BuildCalculator.Domain;

namespace BuildCalculator.Tests.Data.Repositories;

public class ItemRepositoryTests
{
    private ItemRepository GetFakeRepository(
        IReadOnlyDictionary<byte, string>? names = null,
        IReadOnlyDictionary<byte, string>? categories = null,
        IReadOnlyDictionary<byte, string>? types = null,
        IReadOnlyDictionary<byte, Item>? items = null,
        IReadOnlyDictionary<byte, string>? descriptions = null)
    {
        var bag = new ItemDataBag(
            names ?? new Dictionary<byte, string>(),
            categories ?? new Dictionary<byte, string>(),
            types ?? new Dictionary<byte, string>(),
            items ?? new Dictionary<byte, Item>(),
            descriptions ?? new Dictionary<byte, string>()
        );
        return new ItemRepository(bag);
    }

    private IReadOnlyDictionary<byte, string> GetFakeNames() => new Dictionary<byte, string>
    {
        [1] = "Limited Gacha Ticket",
        [2] = "Limited Gacha Ticket"
    };

    private IReadOnlyDictionary<byte, string> GetFakeCategories() => new Dictionary<byte, string>
    {
        [1] = "Material",
        [2] = "Material"
    };

    private IReadOnlyDictionary<byte, string> GetFakeTypes() => new Dictionary<byte, string>
    {
        [1] = "Gacha Ticket",
        [2] = "Gacha Ticket"
    };

    private IReadOnlyDictionary<byte, Item> GetFakeItems() => new Dictionary<byte, Item>
    {
        [1] = new(1, 1, 1, 1),
        [2] = new(2, 1, 1, 1)
    };

    private IReadOnlyDictionary<byte, string> GetFakeDescriptions() => new Dictionary<byte, string>
    {
        [1] = "A precious item used to draw companions in limited Gacha.",
        [2] = "A precious item used to draw companions in limited Gacha."
    };

    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    public void TryGetName_IdIsValid_ReturnsTrueAndName(byte nameId)
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
    public void TryGetName_IdIsInvalidOrNotFound_ReturnsFalseAndNull(byte nameId)
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
    public void TryGetCategory_IdIsValid_ReturnsTrueAndCategory(byte categoryId)
    {
        var fakeCategories = GetFakeCategories();
        var repo = GetFakeRepository(categories: fakeCategories);

        var result = repo.TryGetCategory(categoryId, out var category);

        Assert.True(result);
        Assert.Equal(fakeCategories[categoryId], category);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(3)]
    public void TryGetCategory_IdIsInvalidOrNotFound_ReturnsFalseAndNull(byte categoryId)
    {
        var fakeCategories = GetFakeCategories();
        var repo = GetFakeRepository(categories: fakeCategories);

        var result = repo.TryGetCategory(categoryId, out var category);

        Assert.False(result);
        Assert.Null(category);
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
    public void TryGetItem_IdIsValid_ReturnsTrueAndItem(byte itemId)
    {
        var fakeItems = GetFakeItems();
        var repo = GetFakeRepository(items: fakeItems);

        var result = repo.TryGetItem(itemId, out var item);

        Assert.True(result);
        Assert.Equal(fakeItems[itemId], item);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(3)]
    public void TryGetItem_IdIsInvalidOrNotFound_ReturnsFalseAndDefault(byte itemId)
    {
        var fakeItems = GetFakeItems();
        var repo = GetFakeRepository(items: fakeItems);

        var result = repo.TryGetItem(itemId, out var item);

        Assert.False(result);
        Assert.Equal(default(Item), item);
    }

    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    public void TryGetDescription_IdIsValid_ReturnsTrueAndDescription(byte descriptionId)
    {
        var fakeDescriptions = GetFakeDescriptions();
        var repo = GetFakeRepository(descriptions: fakeDescriptions);

        var result = repo.TryGetDescription(descriptionId, out var description);

        Assert.True(result);
        Assert.Equal(fakeDescriptions[descriptionId], description);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(3)]
    public void TryGetDescription_IdIsInvalidOrNotFound_ReturnsFalseAndNull(byte descriptionId)
    {
        var fakeDescriptions = GetFakeDescriptions();
        var repo = GetFakeRepository(descriptions: fakeDescriptions);

        var result = repo.TryGetDescription(descriptionId, out var description);

        Assert.False(result);
        Assert.Null(description);
    }
}
