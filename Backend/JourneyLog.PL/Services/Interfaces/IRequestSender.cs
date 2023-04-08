using JourneyLog.BLL.Models.External;
using JourneyLog.BLL.Models.Place;

namespace JourneyLog.PL.Services.Interfaces;

public interface IRequestSender
{
    Task<IEnumerable<PlaceModel>> GetPlaceByRadiusAsync(
        GetPlaceByRadiusModel model,
        CancellationToken cancellationToken);
}