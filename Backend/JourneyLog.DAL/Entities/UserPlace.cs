namespace JourneyLog.DAL.Entities;

public class UserPlace : BaseEntity<Guid>
{
    public string PlaceId { get; set; }
    public Guid UserId { get; set; }
    public int? Rate { get; set; }
    public string? Review { get; set; }
    
    public User User { get; set; }
}