using JourneyLog.DAL.Entities;
using JourneyLog.DAL.Repositories.Interfaces;

namespace JourneyLog.DAL.Repositories;

public class UserRepository : BaseRepository<Guid, User>, IUserRepository 
{
    protected UserRepository(JourneyLogContext journeyLogContext) : base(journeyLogContext)
    {
    }
}