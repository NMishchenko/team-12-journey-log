using JourneyLog.BLL.Models.Place;
using JourneyLog.BLL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace JourneyLog.PL.Controllers;


[ApiController]
[Route("api/place")]
public class PlaceController : ControllerBase
{
    private readonly IUserPlaceService _userPlaceService;
    
    public PlaceController(IUserPlaceService userPlaceService)
    {
        _userPlaceService = userPlaceService;
    }

    [HttpGet]
    [Route("radius")]
    public async Task<IActionResult> GetPlacesByRadius([FromQuery] GetPlaceByRadiusModel radiusModel)
    {
        return Ok();
    }

    [HttpGet]
    [Route("bbox")]
    public async Task<IActionResult> GetPlacesByBBox([FromQuery] GetPlaceByBBoxModel bBoxModel)
    {
        return Ok();
    }

    [HttpGet]
    [Route("{xid}")]
    public async Task<IActionResult> GetPlaceInfoByXid()
    {
        return Ok(new GetPlaceInfoModel());
    }

    [HttpPost]
    [Route("{xid}/review")]
    public async Task<IActionResult> CreateUpdatePlaceReview([FromBody] CreateUpdatePlaceReview placeReview, CancellationToken cancellationToken)
    {
        return Ok();
    }
    
    [HttpPost]
    [Route("{xid}/rating")]
    public async Task<IActionResult> CreateUpdatePlaceRating(CreateUpdatePlaceRating placeRating, CancellationToken cancellationToken)
    {
        return Ok();
    }

}