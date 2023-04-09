using JourneyLog.BLL.Models.Place;
using JourneyLog.BLL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace JourneyLog.PL.Controllers;


[ApiController]
[Route("api/places")]
public class PlaceController : ControllerBase
{
    private readonly IRequestSender _requestSender;

    public PlaceController(IRequestSender requestSender)
    {
        _requestSender = requestSender;
    }

    [HttpGet]
    [Route("radius")]
    public async Task<IActionResult> GetPlacesByRadius(
        [FromQuery] GetPlaceByRadiusModel radiusModel,
        CancellationToken cancellationToken)
    {
        var coordinates =
            await _requestSender.GetPlaceByRadiusAsync(radiusModel, cancellationToken);
        return Ok(coordinates);
    }

    [HttpGet]
    [Route("bbox")]
    public async Task<IActionResult> GetPlacesByBBox(
        [FromQuery] GetPlaceByBBoxModel bBoxModel,
        CancellationToken cancellationToken)
    {
        var coordinates =
            await _requestSender.GetPlaceByBBoxAsync(bBoxModel, cancellationToken);
        return Ok(coordinates);
    }

    [HttpGet]
    [Route("{xid}")]
    public async Task<IActionResult> GetPlaceInfoByXid(string xid, CancellationToken cancellationToken)
    {
        var placeInfo =
            await _requestSender.GetPlaceByXidAsync(xid, cancellationToken);
        return Ok(placeInfo);
    }

    [HttpPost]
    [Route("{xid}/review")]
    public async Task<IActionResult> CreateUpdatePlaceReview([FromBody] CreateUpdatePlaceReview placeReview)
    {
        return Ok();
    }
    
    [HttpPost]
    [Route("{xid}/rating")]
    public async Task<IActionResult> CreateUpdatePlaceRating([FromBody] CreateUpdatePlaceRating placeRating)
    {
        return Ok();
    }

}