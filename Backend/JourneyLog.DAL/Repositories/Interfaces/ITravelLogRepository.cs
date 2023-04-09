using JourneyLog.DAL.Entities;

namespace JourneyLog.DAL.Repositories.Interfaces;

public interface ITravelLogRepository : IRepository<Guid, TravelLog>
{
    Task<IEnumerable<TravelLog>> GetAllByUserIdAsync(Guid userId);
    Task<TravelLog?> GetWithAllNestedPropertiesAsync(Guid id);
}