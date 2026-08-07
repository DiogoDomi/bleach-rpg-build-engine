using Xunit;
using BuildCalculator.Data.Dtos;
using BuildCalculator.Domain.Enums;
using BuildCalculator.Data.Parsers.Mappers;

namespace BuildCalculator.Tests.Data.Parsers.Mappers;

public class SetStampMapperTests
{
    [Fact]
    public void MapToSetStampDomain_ValidDto_MapsCorrectly()
    {
        // Arrange
        var dto = new SetStampDto(
            Id: (ushort)100,
            NameId: (ushort)200,
            DisplayOrder: (ushort)5
        );

        // Act
        var result = SetStampMapper.MapToSetStampDomain(dto);

        // Assert
        Assert.Equal((ushort)100, result.Id);
        Assert.Equal((ushort)200, result.NameId);
        Assert.Equal((ushort)5, result.DisplayOrder);
    }

    [Fact]
    public void MapToPassiveDomain_ValidDto_MapsCorrectly()
    {
        // Arrange
        var dto = new SetStampPassiveDto(
            Id: (byte)10,
            NameId: (byte)20,
            PassiveLevel: (byte)3
        );

        // Act
        var result = SetStampMapper.MapToPassiveDomain(dto);

        // Assert
        Assert.Equal((byte)10, result.Id);
        Assert.Equal((byte)20, result.NameId);
        Assert.Equal((byte)3, result.PassiveLevel);
    }

    [Fact]
    public void MapToLevelGapDomain_ValidDto_MapsCorrectlyAndIgnoresStarRatingId()
    {
        // Arrange
        var dto = new SetStampLevelGapDto(
            StarRatingId: (byte)5,
            AscensionLevel: (byte)2,
            MaxEnhanceLevel: (byte)40
        );

        // Act
        var result = SetStampMapper.MapToLevelGapDomain(dto);

        // Assert
        Assert.Equal((byte)2, result.AscensionLevel);
        Assert.Equal((byte)40, result.MaxEnhanceLevel);
    }

    [Fact]
    public void MapToFixedBasicStatGrowthDomain_ValidDto_MapsCorrectlyAndCastsEnums()
    {
        // Arrange
        var dto = new SetStampFixedBasicStatGrowthDto(
            MinBaseValue: (ushort)150,
            MaxBaseValue: (ushort)600,
            PieceIndex: (byte)1,
            StarRatingId: (byte)4
        );

        // Act
        var result = SetStampMapper.MapToFixedBasicStatGrowthDomain(dto);

        // Assert
        Assert.Equal((ushort)150, result.MinBaseValue);
        Assert.Equal((ushort)600, result.MaxBaseValue);
        Assert.Equal((StarRating)4, result.StarRating);
    }

    [Fact]
    public void MapToPoolBasicStatGrowthDomain_ValidDto_AppliesScalingRoundsAndMapsCorrectly()
    {
        // Arrange
        var dto = new SetStampPoolBasicStatGrowthDto(
            MinBaseValue: 12.34f,
            MaxBaseValue: 56.78f,
            StarRatingId: (byte)5,
            StatTypeId: (byte)2
        );

        // Act
        var result = SetStampMapper.MapToPoolBasicStatGrowthDomain(dto);

        // Assert
        Assert.Equal((uint)1234, result.MinBaseValue);
        Assert.Equal((uint)5678, result.MaxBaseValue);
        Assert.Equal((StatType)2, result.StatType);
    }

    [Fact]
    public void MapToPoolAdvancedStatGrowthDomain_WithAllValues_AppliesScalingRoundsAndMapsCorrectly()
    {
        // Arrange
        var dto = new SetStampPoolAdvancedStatGrowthDto(
            MaxBaseValue: 45.67f,
            MinBaseValue: 11.22f,
            StarRatingId: (byte)3,
            StatTypeId: (byte)1
        );

        // Act
        var result = SetStampMapper.MapToPoolAdvancedStatGrowthDomain(dto);

        // Assert
        Assert.Equal((ushort)4567, result.MaxBaseValue);
        Assert.Equal((ushort)1122, result.MinBaseValue);
        Assert.Equal((StatType)1, result.StatType);
    }

    [Fact]
    public void MapToPoolAdvancedStatGrowthDomain_WithNullMaxBaseValue_MapsCorrectly()
    {
        // Arrange
        var dto = new SetStampPoolAdvancedStatGrowthDto(
            MaxBaseValue: null,
            MinBaseValue: 15.55f,
            StarRatingId: (byte)5,
            StatTypeId: (byte)4
        );

        // Act
        var result = SetStampMapper.MapToPoolAdvancedStatGrowthDomain(dto);

        // Assert
        Assert.Null(result.MaxBaseValue);
        Assert.Equal((ushort)1555, result.MinBaseValue);
        Assert.Equal((StatType)4, result.StatType);
    }
}

