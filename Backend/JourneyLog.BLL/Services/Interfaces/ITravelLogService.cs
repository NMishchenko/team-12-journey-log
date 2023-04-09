using JourneyLog.BLL.Models.TravelLog;

namespace JourneyLog.BLL.Services.Interfaces;

public interface ITravelLogService
{
    Task AddAsync(CreateTravelLogModel createTravelLogModel, CancellationToken cancellationToken);
    Task UpdateAsync(Guid id, UpdateTravelLogModel updateTravelLogModel, CancellationToken cancellationToken);
    Task DeleteAsync(Guid id, CancellationToken cancellationToken);
    Task<GetTravelLogModel> GetByIdAsync(Guid id);
}