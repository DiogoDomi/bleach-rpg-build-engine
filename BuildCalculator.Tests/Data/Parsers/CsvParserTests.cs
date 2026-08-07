using Xunit;
using BuildCalculator.Core;
using BuildCalculator.Data.Parsers;

namespace BuildCalculator.Tests.Data.Parsers;

public class CsvParserTests
{
    [Fact]
    public void CreateFileReader_FileDoesNotExist_ReturnsFailResult()
    {
        // Arrange
        var nonExistentPath = Path.Combine(Path.GetTempPath(), "non_existent_file_test_12345.csv");

        // Act
        var result = CsvParser.CreateFileReader(nonExistentPath);

        // Assert
        Assert.False(result.IsSuccess);
        Assert.Equal(ResultError.Failed, result.Error);
    }

    [Fact]
    public void CreateFileReader_FileExists_ReturnsSuccessResultWithReader()
    {
        // Arrange
        var tempFile = Path.GetTempFileName();
        try
        {
            // Act
            var result = CsvParser.CreateFileReader(tempFile);

            // Assert
            Assert.True(result.IsSuccess);
            Assert.NotNull(result.Item);
        }
        finally
        {
            if (File.Exists(tempFile))
                File.Delete(tempFile);
        }
    }

    [Fact]
    public void Parse_ValidCsvData_SkipsHeaderAndInvokesBuilderForEachRow()
    {
        // Arrange
        var csvContent = "id,name\n1,Alpha\n2,Beta";
        using var reader = new StringReader(csvContent);
        var parsedLines = new List<string>();

        // Act
        CsvParser.Parse(reader, line =>
        {
            parsedLines.Add(line.ToString());
        });

        // Assert
        Assert.Equal(2, parsedLines.Count);
        Assert.Equal("1,Alpha", parsedLines[0]);
        Assert.Equal("2,Beta", parsedLines[1]);
    }

    [Fact]
    public void Parse_EmptyReader_DoesNotInvokeBuilder()
    {
        // Arrange
        using var reader = new StringReader(string.Empty);
        var invoked = false;

        // Act
        CsvParser.Parse(reader, _ => invoked = true);

        // Assert
        Assert.False(invoked);
    }

    [Fact]
    public void Slice_StandardLine_ExtractsFirstPieceAndAdvancesReferenceSpan()
    {
        // Arrange
        ReadOnlySpan<char> line = "id,name,props".AsSpan();

        // Act
        var piece = CsvParser.Slice(ref line);

        // Assert
        Assert.Equal("id", piece.ToString());
        Assert.Equal("name,props", line.ToString());
    }

    [Fact]
    public void Slice_FieldWithQuotesAndCommas_RespectsQuotesAndExtractsPieceCorrectly()
    {
        // Arrange
        ReadOnlySpan<char> line = "\"value, with comma\",otherColumn".AsSpan();

        // Act
        var piece = CsvParser.Slice(ref line);

        // Assert
        Assert.Equal("value, with comma", piece.ToString());
        Assert.Equal("otherColumn", line.ToString());
    }

    [Fact]
    public void Slice_LastFieldWithoutCommas_ReturnsRemainingSpanAndEmptiesReference()
    {
        // Arrange
        ReadOnlySpan<char> line = "singleField".AsSpan();

        // Act
        var piece = CsvParser.Slice(ref line);

        // Assert
        Assert.Equal("singleField", piece.ToString());
        Assert.True(line.IsEmpty);
    }
}

