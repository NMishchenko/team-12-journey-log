namespace JourneyLog.DAL.Entities;

public class User : BaseEntity<Guid>
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime DateOfBirth { get; set; }

    public ICollection<TravelLog> TravelLogs { get; set; }
    public ICollection<UserPlace> UserPlaces { get; set; }
}