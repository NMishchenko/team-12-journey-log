using Flurl;
using Flurl.Http;
using JourneyLog.BLL.Models.External;
using JourneyLog.BLL.Models.Place;
using JourneyLog.PL.Services.Interfaces;

namespace JourneyLog.PL.Services;

public class RequestSender: IRequestSender
{
    private readonly IConfiguration _configuration;

    public RequestSender(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public async Task<IEnumerable<PlaceModel>> GetPlaceByRadiusAsync(GetPlaceByRadiusModel model, CancellationToken cancellationToken)
    {
        var url = _configuration.GetConnectionString("OPEN_TRIP_MAP_API_URL");
        var apiKey = _configuration.GetSection("ACCESS_KEYS")["OPEN_TRIP_MAP_API_ACCESS_KEY"];
        
        var response = await url
            .SetQueryParams(model)
            .SetQueryParam("apikey", apiKey)
            .GetAsync(cancellationToken);

        return null;
    }
}