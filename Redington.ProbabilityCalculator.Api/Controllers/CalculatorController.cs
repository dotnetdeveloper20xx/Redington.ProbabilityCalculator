using Microsoft.AspNetCore.Mvc;
using Redington.ProbabilityCalculator.Core.DTOs;
using Redington.ProbabilityCalculator.Core.Interfaces;

namespace Redington.ProbabilityCalculator.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CalculatorController : ControllerBase
{
    private readonly IProbabilityCalculator _calculator;
    private readonly ICalculationLogger _logger;

    public CalculatorController(IProbabilityCalculator calculator, ICalculationLogger logger)
    {
        _calculator = calculator;
        _logger = logger;
    }

    [HttpPost]
    public async Task<IActionResult> Calculate([FromBody] ProbabilityRequestDto request)
    {
        var result = _calculator.Calculate(request);
        await _logger.LogAsync(request, result.Result);
        return Ok(result);
    }
}
