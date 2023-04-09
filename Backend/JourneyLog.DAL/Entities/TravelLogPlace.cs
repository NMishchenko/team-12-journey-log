namespace JourneyLog.DAL.Entities;

public class TravelLogPlace : BaseEntity<Guid>
{
    public Guid TravelLogId { get; set; }
    public string PlaceId { get; set; }
    public DateTime VisitedDate { get; set; }
    public DateTime PlannedDate { get; set; }
    public int? VisitingOrder { get; set; }

    public TravelNote? TravelNote { get; set; }
    public TravelLog TravelLog { get; set; }
}