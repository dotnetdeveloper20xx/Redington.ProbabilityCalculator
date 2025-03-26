using Redington.ProbabilityCalculator.Core.DTOs;

namespace Redington.ProbabilityCalculator.Core.Interfaces;

public interface IProbabilityCalculator
{
    ProbabilityResultDto Calculate(ProbabilityRequestDto request);
}
