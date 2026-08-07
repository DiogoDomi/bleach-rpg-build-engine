using Xunit;
using BuildCalculator.Data.Dtos;
using BuildCalculator.Data.Parsers.Mappers;
using BuildCalculator.Domain.Enums;

namespace BuildCalculator.Tests.Data.Parsers.Mappers;

public class SkillMapperTests
{
    [Fact]
    public void MapToCategoryDomain_ValidDto_MapsCorrectlyAndIgnoresId()
    {
        // Arrange
        var dto = new SkillCategoryDto(
            Name: "Offensive",
            Id: (byte)1,
            DisplayOrder: (byte)10
        );

        // Act
        var result = SkillMapper.MapToCategoryDomain(dto);

        // Assert
        Assert.Equal("Offensive", result.Name);
        Assert.Equal((byte)10, result.DisplayOrder);
    }

    [Fact]
    public void MapToSubCategoryDomain_ValidDto_MapsCorrectlyAndIgnoresId()
    {
        // Arrange
        var dto = new SkillSubCategoryDto(
            Name: "Slash",
            Id: (byte)5,
            CategoryId: (byte)1,
            DisplayOrder: (byte)20
        );

        // Act
        var result = SkillMapper.MapToSubCategoryDomain(dto);

        // Assert
        Assert.Equal("Slash", result.Name);
        Assert.Equal((byte)1, result.CategoryId);
        Assert.Equal((byte)20, result.DisplayOrder);
    }

    [Fact]
    public void MapToSkillDomain_ValidDto_MapsCorrectlyAndIgnoresCharacterId()
    {
        // Arrange
        var dto = new SkillDto(
            Id: (ushort)1000,
            CharacterId: (ushort)500,
            NameId: (ushort)2000,
            SubCategoryId: (byte)3,
            DisplayOrder: (byte)1
        );

        // Act
        var result = SkillMapper.MapToSkillDomain(dto);

        // Assert
        Assert.Equal((ushort)1000, result.Id);
        Assert.Equal((ushort)2000, result.NameId);
        Assert.Equal((byte)3, result.SubCategoryId);
        Assert.Equal((byte)1, result.DisplayOrder);
    }

    [Fact]
    public void MapToSkillTagMappingDomain_WithMultipleTags_CombinesUsingBitwiseOr()
    {
        // Arrange
        var dtos = new List<SkillTagMappingDto>
        {
            new SkillTagMappingDto(SkillId: 100, TagId: 1),
            new SkillTagMappingDto(SkillId: 100, TagId: 2),
            new SkillTagMappingDto(SkillId: 100, TagId: 4)
        };

        // Act
        var result = SkillMapper.MapToSkillTagMappingDomain(dtos);

        // Assert
        Assert.Equal((byte)7, result);
    }

    [Fact]
    public void MapToSkillTagMappingDomain_WithEmptyList_ReturnsZero()
    {
        // Arrange
        var dtos = new List<SkillTagMappingDto>();

        // Act
        var result = SkillMapper.MapToSkillTagMappingDomain(dtos);

        // Assert
        Assert.Equal((byte)0, result);
    }
}

