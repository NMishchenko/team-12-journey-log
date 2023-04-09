namespace JourneyLog.DAL;

public interface IJourneyLogContext
{
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}