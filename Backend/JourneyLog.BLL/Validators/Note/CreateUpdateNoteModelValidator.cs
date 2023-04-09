using JourneyLog.BLL.Models.TravelLogPlaceNote;

namespace JourneyLog.BLL.Validators.Note;
using FluentValidation;

public class CreateUpdateNoteModelValidator : AbstractValidator<CreateUpdateNoteModel>
{
    public CreateUpdateNoteModelValidator()
    {
        RuleFor(i => i.Text)
            .NotEmpty().WithMessage("Note text cannot be empty, null or whitespace")
            .MaximumLength(255).WithMessage("Note text cannot contain more than 255 symbols");
    }
}