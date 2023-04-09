namespace JourneyLog.DAL.Entities;

public class TravelNote : BaseEntity<Guid>
{
    public Guid PlaceTravelLogId { get; set; }
    public string Text { get; set; }

    public TravelLogPlace TravelLogPlace { get; set; }
    public ICollection<NotePhoto> TravelPhotos { get; set; }
}