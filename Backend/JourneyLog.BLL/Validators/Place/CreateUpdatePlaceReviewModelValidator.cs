using FluentValidation;
using JourneyLog.BLL.Models.Place;

namespace JourneyLog.BLL.Validators.Place;

public class CreateUpdatePlaceReviewModelValidator : AbstractValidator<CreateUpdatePlaceReview>
{
    public CreateUpdatePlaceReviewModelValidator()
    {
        RuleFor(e => e.Review)
            .NotEmpty().WithMessage("Rating value cannot be null, empty or whitespace")
            .MaximumLength(255).WithMessage("Review text cannot contain more than 255 symbols");
    }
}