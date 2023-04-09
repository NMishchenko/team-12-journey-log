using JourneyLog.BLL.Models.TravelLogPlaceNotePhotos;

namespace JourneyLog.BLL.Services.Interfaces;

public interface INotePhotoService
{
    Task CreateAsync(Guid noteId, CreateNotePhotoModel createNotePhotoModel, CancellationToken cancellationToken);
    Task DeleteAsync(Guid photoId, CancellationToken cancellationToken);
}