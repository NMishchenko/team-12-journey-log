using FluentValidation;
using JourneyLog.BLL.Models.Place;

namespace JourneyLog.BLL.Validators.Place;

public class CreateUpdatePlaceRatingModelValidator : AbstractValidator<CreateUpdatePlaceRating>
{
    public CreateUpdatePlaceRatingModelValidator()
    {
        RuleFor(e => e.Rating)
            .NotEmpty().WithMessage("Rating value cannot be null, empty or whitespace")
            .InclusiveBetween(1, 3).WithMessage("Rating value can only be in range between 1 and 3 inclusive");
        
    }
}