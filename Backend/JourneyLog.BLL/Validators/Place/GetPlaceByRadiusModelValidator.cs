using FluentValidation;
using JourneyLog.BLL.Models.Place;

namespace JourneyLog.BLL.Validators.Place;

public class GetPlaceByRadiusModelValidator : AbstractValidator<GetPlaceByRadiusModel>
{
    public GetPlaceByRadiusModelValidator()
    {
        RuleFor(e => e.lat)
            .NotEmpty().WithMessage("Latitude cannot be null or empty");
        RuleFor(e => e.lon)
            .NotEmpty().WithMessage("Longitude cannot be null or empty");
        RuleFor(e => e.radius)
            .NotEmpty().WithMessage("Radius cannot be null or empty")
            .InclusiveBetween(1, 20000).WithMessage("Radius can only be in range between 1 and 20 000");
    }
}