using JourneyLog.DAL.Entities;

namespace JourneyLog.DAL.Repositories.Interfaces;

public interface ITravelNoteRepository : IRepository<Guid, TravelNote>
{
}