﻿using JourneyLog.BLL.Models.Place;
using JourneyLog.BLL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace JourneyLog.PL.Controllers;


[ApiController]
[Route("api/place")]
public class PlaceController : ControllerBase
{
    private readonly IRequestSender _requestSender;
    private readonly IUserPlaceService _userPlaceService;
    
    public PlaceController(IRequestSender requestSender,
        IUserPlaceService userPlaceService)
    {
        _requestSender = requestSender;
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
    public async Task<IActionResult> CreateUpdatePlaceReview([FromBody] CreateUpdatePlaceReview placeReview)
    {
        return Ok();
    }
    
    [HttpPost]
    [Route("{xid}/rating")]
    public async Task<IActionResult> CreateUpdatePlaceRating([FromBody] CreateUpdatePlaceRating placeRating, CancellationToken cancellationToken)
    {
        return Ok();
    }

}