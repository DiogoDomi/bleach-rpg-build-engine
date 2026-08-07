using Xunit;
using BuildCalculator.Data.Parsers.Builders.Csv;

namespace BuildCalculator.Tests.Data.Parsers.Builders.Csv;

public class CsvSharedBuildersTests
{
    [Fact]
    public void BuildIdAndText_WithByteId_ReturnsExpectedTuple()
    {
        // Arrange
        ReadOnlySpan<char> line = "10,Simple Text".AsSpan();

        // Act
        var (id, text) = CsvSharedBuilders.BuildIdAndText<byte>(line);

        // Assert
        Assert.Equal((byte)10, id);
        Assert.Equal("Simple Text", text);
    }

    [Fact]
    public void BuildIdAndText_WithUshortIdAndNewlines_ReplacesLiteralNewlines()
    {
        // Arrange
        ReadOnlySpan<char> line = "1000,Line 1\\nLine 2".AsSpan();

        // Act
        var (id, text) = CsvSharedBuilders.BuildIdAndText<ushort>(line);

        // Assert
        Assert.Equal((ushort)1000, id);
        Assert.Equal("Line 1\nLine 2", text);
    }

    [Fact]
    public void BuildIdAndText_WithMultipleEscapedNewlines_ReplacesAll()
    {
        // Arrange
        ReadOnlySpan<char> line = "5,A\\nB\\nC".AsSpan();

        // Act
        var (id, text) = CsvSharedBuilders.BuildIdAndText<byte>(line);

        // Assert
        Assert.Equal((byte)5, id);
        Assert.Equal("A\nB\nC", text);
    }
}

