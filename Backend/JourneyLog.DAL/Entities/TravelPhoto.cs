namespace JourneyLog.DAL.Entities;

public class TravelPhoto : BaseEntity<Guid>
{
    public Guid Id { get; set; }
    public Guid TravelNoteId { get; set; }
    public string Link { get; set; }

    public TravelNote TravelNote { get; set; }
}