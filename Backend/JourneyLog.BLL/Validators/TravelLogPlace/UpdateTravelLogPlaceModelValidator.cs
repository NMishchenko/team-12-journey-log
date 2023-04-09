using FluentValidation;
using JourneyLog.BLL.Models.TravelLog;

namespace JourneyLog.BLL.Validators.TravelLogPlace;

public class UpdateTravelLogPlaceModelValidator : AbstractValidator<UpdateTravelLogPlaceInfoModel>
{
    public UpdateTravelLogPlaceModelValidator()
    {
        RuleFor(e => e.VisitingOrder)
            .InclusiveBetween(1, 1000).WithMessage("You cannot have more than 1000 places in one travel log");
        
        
    }
}