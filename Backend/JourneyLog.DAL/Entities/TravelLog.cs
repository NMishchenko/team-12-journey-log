namespace JourneyLog.DAL.Entities;

public class TravelLog : BaseEntity<Guid>
{
    public Guid UserId { get; set; }
    public string? Description { get; set; }
    public DateTime CreationDate { get; set; }

    public ICollection<PlaceTravelLog> PlaceTravelLogs { get; set; }
    public User User { get; set; }
}