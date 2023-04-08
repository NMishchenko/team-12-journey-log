namespace JourneyLog.BLL.Models.External;

public class FeatureModel
{
    public string Id { get; set; }
    public GeometryModel Geometry { get; set; }
    public PlaceModel Properties { get; set; }
}