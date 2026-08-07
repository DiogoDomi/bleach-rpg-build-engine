using Xunit;
using BuildCalculator.Data.Parsers.Builders.Csv;

namespace BuildCalculator.Tests.Data.Parsers.Builders.Csv;

public class CsvCharacterBuilderTests
{
    [Fact]
    public void BuildCharacterRoleDto_ValidRow_ReturnsExpectedTuple()
    {
        // Arrange
        ReadOnlySpan<char> line = "1,Attacker,Deals high physical damage".AsSpan();

        // Act
        var (roleId, dto) = CsvCharacterBuilder.BuildCharacterRoleDto(line);

        // Assert
        Assert.Equal((byte)1, roleId);
        Assert.Equal((byte)1, dto.Id);
        Assert.Equal("Attacker", dto.Name);
        Assert.Equal("Deals high physical damage", dto.Description);
    }

    [Fact]
    public void BuildCharacterDto_ValidRow_ReturnsExpectedTuple()
    {
        // Arrange
        ReadOnlySpan<char> line = "100,500,2,3,4,5,10".AsSpan();

        // Act
        var (characterId, dto) = CsvCharacterBuilder.BuildCharacterDto(line);

        // Assert
        Assert.Equal((ushort)100, characterId);
        Assert.Equal((ushort)100, dto.Id);
        Assert.Equal((ushort)500, dto.NameId);
        Assert.Equal((ushort)10, dto.DisplayOrder);
        Assert.Equal((byte)2, dto.AffinityId);
        Assert.Equal((byte)3, dto.RoleId);
        Assert.Equal((byte)4, dto.FactionId);
        Assert.Equal((byte)5, dto.RarityId);
    }

    [Fact]
    public void BuildBaseStatDto_ValidRowWithAllValues_ReturnsExpectedTuple()
    {
        // Arrange
        ReadOnlySpan<char> line = "100,2,150,300".AsSpan();

        // Act
        var (characterId, dto) = CsvCharacterBuilder.BuildBaseStatDto(line);

        // Assert
        Assert.Equal((ushort)100, characterId);
        Assert.Equal((ushort)100, dto.CharacterId);
        Assert.Equal((byte)2, dto.StatTypeId);
        Assert.Equal((ushort)150, dto.MinBaseValue);
        Assert.Equal((ushort?)300, dto.MaxBaseValue);
    }

    [Fact]
    public void BuildBaseStatDto_OptionalMaxBaseValueIsEmpty_ReturnsNullForMax()
    {
        // Arrange
        ReadOnlySpan<char> line = "100,2,150,".AsSpan();

        // Act
        var (characterId, dto) = CsvCharacterBuilder.BuildBaseStatDto(line);

        // Assert
        Assert.Equal((ushort)100, characterId);
        Assert.Equal((ushort)100, dto.CharacterId);
        Assert.Equal((byte)2, dto.StatTypeId);
        Assert.Equal((ushort)150, dto.MinBaseValue);
        Assert.Null(dto.MaxBaseValue);
    }
}
