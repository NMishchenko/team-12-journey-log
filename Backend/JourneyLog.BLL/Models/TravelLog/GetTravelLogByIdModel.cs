using JourneyLog.BLL.Models.TravelLog.NestedModels;

namespace JourneyLog.BLL.Models.TravelLog;

public class GetTravelLogByIdModel
{
    public string Name { get; set; }
    public string? Description { get; set; }
    public DateTime CreationDate { get; set; }
    public IEnumerable<GetPlace> Places { get; set; }
}