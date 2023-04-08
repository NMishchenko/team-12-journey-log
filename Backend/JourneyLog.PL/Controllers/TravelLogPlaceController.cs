using JourneyLog.BLL.Models.TravelLog;
using Microsoft.AspNetCore.Mvc;

namespace JourneyLog.PL.Controllers;

[ApiController]
[Route("api/travelLog")]
public class TravelLogPlaceController : ControllerBase
{
    [HttpPost]
    [Route("{id}/place/{xid}")]
    public async Task<IActionResult> AddPlaceToTravelLog()
    {
        return Ok();
    }

    [HttpPut]
    [Route("{id}/place/{xid}")]
    public async Task<IActionResult> UpdatePlaceInTravelLog(UpdateTravelLogPlaceInfoModel placeInfo)
    {
        return Ok();
    }

    [HttpDelete]
    [Route("{id}/place/{xid}")]
    public async Task<IActionResult> DeletePlaceFromTravelLog()
    {
        return Ok();
    }
}