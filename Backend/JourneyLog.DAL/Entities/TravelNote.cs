namespace JourneyLog.DAL.Entities;

public class TravelNote : BaseEntity<Guid>
{
    public Guid Id { get; set; }
    public Guid PlaceTravelLogid { get; set; }
    public string Text { get; set; }

    public PlaceTravelLog PlaceTravelLog { get; set; }
    public ICollection<TravelPhoto> TravelPhotos { get; set; }
}