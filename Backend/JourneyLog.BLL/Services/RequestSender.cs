using Flurl;
using Flurl.Http;
using JourneyLog.BLL.Models.External;
using JourneyLog.BLL.Models.Place;
using JourneyLog.BLL.Services.Interfaces;
using Microsoft.Extensions.Configuration;

namespace JourneyLog.BLL.Services;

public class RequestSender: IRequestSender
{
    private readonly string _apiUrl;
    private readonly string _accessKey;

    public RequestSender(IConfiguration configuration)
    {
        _apiUrl = configuration.GetConnectionString("OPEN_TRIP_MAP_API_URL");
        _accessKey = configuration.GetSection("AccessKeys")["OPEN_TRIP_MAP_API_ACCESS_KEY"];
    }

    public async Task<IEnumerable<PlaceCoordinatesModel>> GetPlaceByRadiusAsync(GetPlaceByRadiusModel model, CancellationToken cancellationToken)
    {
        var response = await (_apiUrl + "radius")
            .SetQueryParams(model)
            .SetQueryParam("apikey", _accessKey)
            .GetAsync(cancellationToken)
            .ReceiveJson<FeatureCollection>();

        var placeCoordinatesModel = response.Features
            .Select(f => new PlaceCoordinatesModel
                { Lon = f.Geometry.Coordinates[0], Lat = f.Geometry.Coordinates[1], Xid = f.Properties.Xid})
            .ToList();
            
        return placeCoordinatesModel;
    }

    public async Task<IEnumerable<PlaceCoordinatesModel>> GetPlaceByBBoxAsync(GetPlaceByBBoxModel model, CancellationToken cancellationToken)
    {
        var response = await (_apiUrl + "bbox")
            .SetQueryParams(model)
            .SetQueryParam("apikey", _accessKey)
            .SetQueryParam("limit", 200)
            .GetAsync(cancellationToken)
            .ReceiveJson<FeatureCollection>();

        var placeCoordinatesModel = response.Features
            .Select(f => new PlaceCoordinatesModel
                { Lon = f.Geometry.Coordinates[0], Lat = f.Geometry.Coordinates[1], Xid = f.Properties.Xid })
            .ToList();
            
        return placeCoordinatesModel;
    }

    public async Task<PlaceModel> GetPlaceByXidAsync(string xid, CancellationToken cancellationToken)
    {
        var placeInfoModel = await (_apiUrl + "xid/" + xid)
            .SetQueryParam("apikey", _accessKey)
            .GetAsync(cancellationToken)
            .ReceiveJson<PlaceModel>();

        return placeInfoModel;
    }
}