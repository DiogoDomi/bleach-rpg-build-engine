using BuildCalculator.Data.Parsers.Loaders.Csv;

namespace BuildCalculator.Tests.Data.Parsers.Loaders.Csv;

public class CsvSharedLoadersTests
{
    private static (int Id, string Value) DummyBuilder(ReadOnlySpan<char> span)
    {
        var str = span.ToString();
        var parts = str.Split(',');
        return (int.Parse(parts[0]), parts[1]);
    }

[Fact]
    public void LoadSingleDomainData_WithValidUniqueKeys_ReturnsDictionary()
    {
        // Arrange
        var csvContent = "Id,Name\n1,Sword\n2,Shield";
        using var reader = new StringReader(csvContent);

        // Act
        var result = CsvSharedLoaders.LoadSingleDomainData(reader, DummyBuilder);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(2, result.Count);
        Assert.Equal("Sword", result[1]);
        Assert.Equal("Shield", result[2]);
    }

    [Fact]
    public void LoadSingleDomainData_WithDuplicateKeys_ThrowsArgumentException()
    {
        // Arrange
        var csvContent = "Id,Name\n1,Sword\n1,Shield";
        using var reader = new StringReader(csvContent);

        // Act & Assert
        Assert.Throws<ArgumentException>(() =>
            CsvSharedLoaders.LoadSingleDomainData(reader, DummyBuilder));
    }

    [Fact]
    public void LoadManyDomainData_WithDuplicateKeys_GroupsCorrectly()
    {
        // Arrange
        var csvContent = "Id,Element\n1,Fire\n1,Water\n2,Earth";
        using var reader = new StringReader(csvContent);

        // Act
        var result = CsvSharedLoaders.LoadManyDomainData(reader, DummyBuilder);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(2, result.Count);
        Assert.Equal(2, result[1].Length);
        Assert.Contains("Fire", result[1]);
        Assert.Contains("Water", result[1]);
        Assert.Single(result[2]);
        Assert.Equal("Earth", result[2][0]);
    }
}

