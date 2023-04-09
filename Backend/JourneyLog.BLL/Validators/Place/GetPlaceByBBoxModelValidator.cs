using FluentValidation;
using JourneyLog.BLL.Models.Place;

namespace JourneyLog.BLL.Validators.Place;

public class GetPlaceByBBoxModelValidator : AbstractValidator<GetPlaceByBBoxModel>
{
    public GetPlaceByBBoxModelValidator()
    {
        RuleFor(e => e.lat_max)
            .NotEmpty().WithMessage("Maximum latitude cannot be null or empty");
        RuleFor(e => e.lat_min)
            .NotEmpty().WithMessage("Minimum latitude cannot be null or empty");
        RuleFor(e => e.lon_max)
            .NotEmpty().WithMessage("Maximum longitude cannot be null or empty");
        RuleFor(e => e.lon_min)
            .NotEmpty().WithMessage("Minimum longitude cannot be null or empty");
    }
}