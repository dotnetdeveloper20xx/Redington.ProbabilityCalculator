using FluentAssertions;
using Redington.ProbabilityCalculator.Core.DTOs;
using Redington.ProbabilityCalculator.Core.Enums;
using Redington.ProbabilityCalculator.Core.Services;
using Xunit;

namespace Redington.ProbabilityCalculator.Tests.Services;

public class ProbabilityCalculatorTests
{
    private readonly Redington.ProbabilityCalculator.Core.Services.ProbabilityCalculator _calculator;

    public ProbabilityCalculatorTests()
    {
        _calculator = new Redington.ProbabilityCalculator.Core.Services.ProbabilityCalculator();
    }

    [Theory]
    [InlineData(0.5, 0.5, CalculationType.CombinedWith, 0.25)]
    [InlineData(0.5, 0.5, CalculationType.Either, 0.75)]
    [InlineData(0, 0.8, CalculationType.CombinedWith, 0)]
    [InlineData(0, 0.8, CalculationType.Either, 0.8)]
    public void Calculate_ValidInputs_ReturnsExpectedResult(
        double a, double b, CalculationType type, double expected)
    {
        // Arrange
        var request = new ProbabilityRequestDto
        {
            ProbabilityA = a,
            ProbabilityB = b,
            CalculationType = type
        };

        // Act
        var result = _calculator.Calculate(request);

        // Assert
        result.Result.Should().BeApproximately(expected, 0.0001);
    }

    [Fact]
    public void Calculate_InvalidType_ThrowsArgumentException()
    {
        // Arrange
        var request = new ProbabilityRequestDto
        {
            ProbabilityA = 0.3,
            ProbabilityB = 0.3,
            CalculationType = (CalculationType)99
        };

        // Act
        var act = () => _calculator.Calculate(request);

        // Assert
        act.Should().Throw<ArgumentException>()
            .WithMessage("Invalid Calculation Type");
    }
}
