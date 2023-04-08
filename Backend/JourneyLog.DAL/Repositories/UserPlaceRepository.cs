using JourneyLog.DAL.Entities;
using JourneyLog.DAL.Repositories.Interfaces;

namespace JourneyLog.DAL.Repositories;

public class UserPlaceRepository : BaseRepository<Guid, UserPlace>, IUserPlaceRepository
{
    public UserPlaceRepository(JourneyLogContext journeyLogContext) : base(journeyLogContext)
    {
    }
}