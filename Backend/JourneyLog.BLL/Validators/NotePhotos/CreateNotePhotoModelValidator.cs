using FluentValidation;
using JourneyLog.BLL.Models.TravelLogPlaceNotePhotos;

namespace JourneyLog.BLL.Validators.NotePhotos;

public class CreateNotePhotoModelValidator : AbstractValidator<CreateNotePhotoModel>
{
    public CreateNotePhotoModelValidator()
    {
        RuleFor(e => e.ImageBase64)
            .NotEmpty().WithMessage("Image link cannot be empty, null or whitespace");
    }
}