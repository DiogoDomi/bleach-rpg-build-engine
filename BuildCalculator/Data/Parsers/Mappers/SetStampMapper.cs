using BuildCalculator.Data.Dtos;
using BuildCalculator.Domain;
using BuildCalculator.Domain.Enums;

namespace BuildCalculator.Data.Parsers.Mappers;

public static class SetStampMapper
{
    private const byte ScalingFactor = 100;

    public static SetStamp MapToSetStampDomain(SetStampDto dto)
    {
        return new SetStamp(
            dto.Id,
            dto.NameId,
            dto.DisplayOrder);
    }

    public static SetStampPassive MapToPassiveDomain(SetStampPassiveDto dto)
    {
        return new SetStampPassive(
            dto.Id,
            dto.NameId,
            dto.PassiveLevel);
    }

    public static SetStampLevelGap MapToLevelGapDomain(SetStampLevelGapDto dto)
    {
        return new SetStampLevelGap(
            dto.AscensionLevel,
            dto.MaxEnhanceLevel);
    }

    public static SetStampFixedBasicStatGrowth MapToFixedBasicStatGrowthDomain(SetStampFixedBasicStatGrowthDto dto)
    {
        return new SetStampFixedBasicStatGrowth(
            dto.MinBaseValue,
            dto.MaxBaseValue,
            (StarRating)dto.StarRatingId);
    }

    public static SetStampPoolBasicStatGrowth MapToPoolBasicStatGrowthDomain(SetStampPoolBasicStatGrowthDto dto)
    {
        return new SetStampPoolBasicStatGrowth(
            (uint)Math.Round(dto.MinBaseValue * ScalingFactor),
            (uint)Math.Round(dto.MaxBaseValue * ScalingFactor),
            (StatType)dto.StatTypeId);
    }
    public static SetStampPoolAdvancedStatGrowth MapToPoolAdvancedStatGrowthDomain(SetStampPoolAdvancedStatGrowthDto dto)
    {
        ushort? maxBaseValue = dto.MaxBaseValue == null
            ? null
            : (ushort)Math.Round(dto.MaxBaseValue.Value * ScalingFactor);

        return new SetStampPoolAdvancedStatGrowth(
            maxBaseValue,
            (ushort)Math.Round(dto.MinBaseValue * ScalingFactor),
            (StatType)dto.StatTypeId);
    }
}

