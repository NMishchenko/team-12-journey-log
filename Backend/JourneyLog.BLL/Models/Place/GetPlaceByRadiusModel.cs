using Newtonsoft.Json;

namespace JourneyLog.BLL.Models.Place;

public class GetPlaceByRadiusModel
{
    public double lon { get; set; }
    public double lat { get; set; }
    public int radius { get; set; }
}