using JourneyLog.BLL.Models.TravelLog;

namespace JourneyLog.BLL.Services.Interfaces;

public interface ITravelLogPlaceService
{
    Task AddAsync(Guid travelLogId, string placeId, CancellationToken cancellationToken);
    Task UpdateAsync(Guid travelLogId, string placeId, UpdateTravelLogPlaceInfoModel updateTravelLogPlaceInfoModel, CancellationToken cancellationToken);
    Task DeleteAsync(Guid travelLogId, string placeId, CancellationToken cancellationToken);
}