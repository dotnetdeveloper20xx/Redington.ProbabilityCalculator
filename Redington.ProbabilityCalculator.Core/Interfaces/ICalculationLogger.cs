using Redington.ProbabilityCalculator.Core.DTOs;

namespace Redington.ProbabilityCalculator.Core.Interfaces;

public interface ICalculationLogger
{
    Task LogAsync(ProbabilityRequestDto request, double result);
}
