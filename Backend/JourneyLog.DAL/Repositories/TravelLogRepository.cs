using JourneyLog.DAL.Entities;
using JourneyLog.DAL.Repositories.Interfaces;

namespace JourneyLog.DAL.Repositories;

public class TravelLogRepository : BaseRepository<Guid, TravelLog>, ITravelLogRepository
{
    protected TravelLogRepository(JourneyLogContext journeyLogContext) : base(journeyLogContext)
    {
    }
}