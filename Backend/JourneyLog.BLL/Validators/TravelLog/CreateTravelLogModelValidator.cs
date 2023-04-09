using FluentValidation;
using JourneyLog.BLL.Models.TravelLog;

namespace JourneyLog.BLL.Validators.TravelLog;

public class CreateTravelLogModelValidator : AbstractValidator<CreateTravelLogModel>
{
    public CreateTravelLogModelValidator()
    {
        RuleFor(e => e.Name)
            .NotEmpty().WithMessage("Travel log name cannot be null, empty or whitespace")
            .MaximumLength(65).WithMessage("Travel log name cannot contain more than 65 characters");

        RuleFor(e => e.Description)
            .MaximumLength(255).WithMessage("Travel log description cannot contain more than 255 characters");
    }
}