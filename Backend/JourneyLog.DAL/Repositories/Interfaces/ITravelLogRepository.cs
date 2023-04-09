using JourneyLog.DAL.Entities;

namespace JourneyLog.DAL.Repositories.Interfaces;

public interface ITravelLogRepository : IRepository<Guid, TravelLog>
{
    Task<TravelLog?> GetWithAllNestedPropertiesAsync(Guid id);
}