namespace JourneyLog.DAL.Entities;

public class NotePhoto : BaseEntity<Guid>
{
    public Guid TravelNoteId { get; set; }
    public string FileName { get; set; }

    public TravelNote TravelNote { get; set; }
}