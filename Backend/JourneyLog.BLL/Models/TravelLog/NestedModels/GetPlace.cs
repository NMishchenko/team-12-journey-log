using Microsoft.EntityFrameworkCore.Metadata;

namespace JourneyLog.BLL.Models.TravelLog.NestedModels;

public class GetPlace
{
    public string PlaceId { get; set; }
    public int VisitingOrder { get; set; }
    public DateTime PlannedDate { get; set; }
    public IEnumerable<GetNote> Notes { get; set; }
    
}