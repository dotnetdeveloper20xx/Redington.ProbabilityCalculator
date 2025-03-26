using FluentValidation;
using Redington.ProbabilityCalculator.Core.DTOs;

namespace Redington.ProbabilityCalculator.Api.Validators;

public class ProbabilityRequestDtoValidator : AbstractValidator<ProbabilityRequestDto>
{
    public ProbabilityRequestDtoValidator()
    {
        RuleFor(x => x.ProbabilityA)
            .InclusiveBetween(0, 1).WithMessage("ProbabilityA must be between 0 and 1");
        RuleFor(x => x.ProbabilityB)
            .InclusiveBetween(0, 1).WithMessage("ProbabilityB must be between 0 and 1");
    }
}
