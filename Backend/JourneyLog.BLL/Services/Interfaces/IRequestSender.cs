using JourneyLog.BLL.Models.External;
using JourneyLog.BLL.Models.Place;

namespace JourneyLog.BLL.Services.Interfaces;

public interface IRequestSender
{
    Task<IEnumerable<PlaceCoordinatesModel>> GetPlaceByRadiusAsync(
        GetPlaceByRadiusModel model,
        CancellationToken cancellationToken);
    
    Task<IEnumerable<PlaceCoordinatesModel>> GetPlaceByBBoxAsync(
        GetPlaceByBBoxModel model,
        CancellationToken cancellationToken);

    Task<PlaceModel> GetPlaceByXidAsync(
        string xid,
        CancellationToken cancellationToken);
}