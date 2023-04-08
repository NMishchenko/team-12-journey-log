﻿using JourneyLog.BLL.Models.Place;
using Microsoft.AspNetCore.Mvc;

namespace JourneyLog.PL.Controllers;


[ApiController]
[Route("api/place")]
public class PlaceController : ControllerBase
{

    [HttpGet]
    [Route("radius")]
    public async Task<IActionResult> GetPlacesByRadius([FromBody] GetPlaceByRadiusModel radiusModel)
    {
        return Ok();
    }

    [HttpGet]
    [Route("bbox")]
    public async Task<IActionResult> GetPlacesByBBox([FromBody] GetPlaceByBBoxModel bBoxModel)
    {
        return Ok();
    }

    [HttpGet]
    [Route("{xid}")]
    public async Task<IActionResult> GetPlaceInfoByXid()
    {
        return Ok();
    }

    [HttpPost]
    [Route("{xid}/review")]
    public async Task<IActionResult> CreatePlaceReview()
    {
        return Ok();
    }

}