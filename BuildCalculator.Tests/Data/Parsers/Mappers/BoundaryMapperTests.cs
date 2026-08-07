using Xunit;
using BuildCalculator.Data.Dtos;
using BuildCalculator.Data.Parsers.Mappers;

namespace BuildCalculator.Tests.Data.Parsers.Mappers;

public class BoundaryMapperTests
{
    [Fact]
    public void MapToBoundaryDomain_WithAllValues_MapsCorrectly()
    {
        // Arrange
        var dto = new BoundaryDto(
            SkillNameId: (ushort?)500,
            Id: (ushort)10,
            CharacterId: (ushort)99,
            ImprovementValue: (byte?)5,
            AscensionId: (byte)2,
            TypeId: (byte)3
        );

        // Act
        var result = BoundaryMapper.MapToBoundaryDomain(dto);

        // Assert
        Assert.Equal((ushort?)500, result.SkillNameId);
        Assert.Equal((ushort)10, result.Id);
        Assert.Equal((byte?)5, result.ImprovementValue);
        Assert.Equal((byte)2, result.AscensionId);
        Assert.Equal((byte)3, result.TypeId);
    }

    [Fact]
    public void MapToBoundaryDomain_WithNullOptionalValues_MapsCorrectly()
    {
        // Arrange
        var dto = new BoundaryDto(
            SkillNameId: null,
            Id: (ushort)15,
            CharacterId: (ushort)100,
            ImprovementValue: null,
            AscensionId: (byte)4,
            TypeId: (byte)1
        );

        // Act
        var result = BoundaryMapper.MapToBoundaryDomain(dto);

        // Assert
        Assert.Null(result.SkillNameId);
        Assert.Equal((ushort)15, result.Id);
        Assert.Null(result.ImprovementValue);
        Assert.Equal((byte)4, result.AscensionId);
        Assert.Equal((byte)1, result.TypeId);
    }
}

