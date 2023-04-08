using JourneyLog.DAL.Entities;
using JourneyLog.DAL.Repositories.Interfaces;

namespace JourneyLog.DAL.Repositories;

public class PlaceTravelLogRepository : BaseRepository<Guid, PlaceTravelLog>, IPlaceTravelLogRepository
{
    public PlaceTravelLogRepository(JourneyLogContext journeyLogContext) : base(journeyLogContext)
    {
    }
}