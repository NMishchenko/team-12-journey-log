using JourneyLog.DAL.Entities;

namespace JourneyLog.DAL.Repositories.Interfaces;

public interface IUserRepository : IRepository<Guid, User>
{
}