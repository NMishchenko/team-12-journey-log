namespace JourneyLog.DAL.Entities;

public class User
{
    public Guid IdentityId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateOnly DateOfBirth { get; set; }

    public virtual ICollection<List> Lists { get; set; }
}