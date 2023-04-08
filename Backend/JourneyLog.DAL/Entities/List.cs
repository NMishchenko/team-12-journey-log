namespace JourneyLog.DAL.Entities;

public class List
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public string? Description { get; set; }
    public string TotalDistance { get; set; }
    public DateOnly JourneyDate { get; set; }
    public DateTime Timestamp { get; set; }

    public virtual ICollection<Place> Places { get; set; }
    public virtual User User { get; set; }
}