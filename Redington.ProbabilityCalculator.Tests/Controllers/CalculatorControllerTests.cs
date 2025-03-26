using FluentAssertions;
using Moq;
using Redington.ProbabilityCalculator.Api.Controllers;
using Redington.ProbabilityCalculator.Core.DTOs;
using Redington.ProbabilityCalculator.Core.Enums;
using Redington.ProbabilityCalculator.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace Redington.ProbabilityCalculator.Tests.Controllers;

public class CalculatorControllerTests
{
    private readonly Mock<IProbabilityCalculator> _calculatorMock;
    private readonly Mock<ICalculationLogger> _loggerMock;
    private readonly CalculatorController _controller;

    public CalculatorControllerTests()
    {
        _calculatorMock = new Mock<IProbabilityCalculator>();
        _loggerMock = new Mock<ICalculationLogger>();
        _controller = new CalculatorController(_calculatorMock.Object, _loggerMock.Object);
    }

    [Fact]
    public void Calculate_ValidRequest_ReturnsOkResult()
    {
        // Arrange
        var request = new ProbabilityRequestDto
        {
            ProbabilityA = 0.4,
            ProbabilityB = 0.5,
            CalculationType = CalculationType.CombinedWith
        };

        var expected = new ProbabilityResultDto { Result = 0.2 };

        _calculatorMock.Setup(x => x.Calculate(request)).Returns(expected);

        // Act
        var result = _controller.Calculate(request);

        // Assert
        var okResult = result as OkObjectResult;
        okResult.Should().NotBeNull();
        var actualResult = okResult!.Value as ProbabilityResultDto;
        actualResult!.Result.Should().Be(0.2);
    }
}
