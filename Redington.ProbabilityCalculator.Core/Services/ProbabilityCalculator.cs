using Redington.ProbabilityCalculator.Core.DTOs;
using Redington.ProbabilityCalculator.Core.Enums;
using Redington.ProbabilityCalculator.Core.Interfaces;

namespace Redington.ProbabilityCalculator.Core.Services;

public class ProbabilityCalculator : IProbabilityCalculator
{
    public ProbabilityResultDto Calculate(ProbabilityRequestDto request)
    {
        double a = request.ProbabilityA;
        double b = request.ProbabilityB;
        double result = request.CalculationType switch
        {
            CalculationType.CombinedWith => a * b,
            CalculationType.Either => a + b - (a * b),
            _ => throw new ArgumentException("Invalid Calculation Type")
        };

        return new ProbabilityResultDto { Result = result };
    }
}
