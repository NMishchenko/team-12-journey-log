using JourneyLog.DAL.Entities;
using JourneyLog.DAL.Repositories.Interfaces;

namespace JourneyLog.DAL.Repositories;

public class TravelPhotoRepository : BaseRepository<Guid, TravelPhoto>, ITravelPhotoRepository
{
    public TravelPhotoRepository(JourneyLogContext journeyLogContext) : base(journeyLogContext)
    {
    }
}