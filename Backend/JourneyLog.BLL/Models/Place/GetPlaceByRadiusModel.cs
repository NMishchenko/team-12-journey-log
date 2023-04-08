namespace JourneyLog.BLL.Models.Place;

public class GetPlaceByRadiusModel
{
    public double Longitude { get; set; }
    public double Latitude { get; set; }
    public int Radius { get; set; }
}