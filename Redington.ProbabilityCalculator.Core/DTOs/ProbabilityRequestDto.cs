using Redington.ProbabilityCalculator.Core.Enums;

namespace Redington.ProbabilityCalculator.Core.DTOs;

public class ProbabilityRequestDto
{
    public double ProbabilityA { get; set; }
    public double ProbabilityB { get; set; }
    public CalculationType CalculationType { get; set; }
}
