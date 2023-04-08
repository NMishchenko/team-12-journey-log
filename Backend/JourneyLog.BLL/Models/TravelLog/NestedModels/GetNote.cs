using JourneyLog.DAL.Entities;

namespace JourneyLog.BLL.Models.TravelLog.NestedModels;

public class GetNote
{
    public string Text { get; set; }
    public IEnumerable<GetPhoto> Photos { get; set; }
}