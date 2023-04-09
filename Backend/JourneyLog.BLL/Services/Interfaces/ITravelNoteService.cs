using JourneyLog.BLL.Models.TravelLogPlaceNote;

namespace JourneyLog.BLL.Services.Interfaces;

public interface ITravelNoteService
{
    Task UpsertAsync(Guid travelLogId, string placeId, CreateUpdateNoteModel createUpdateNoteModel, CancellationToken cancellationToken);
    Task DeleteAsync(Guid noteId, CancellationToken cancellationToken);
}