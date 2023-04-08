using JourneyLog.BLL.Models.TravelLog;
using Microsoft.AspNetCore.Mvc;

namespace JourneyLog.PL.Controllers;

[ApiController]
[Route("api/travelLog")]
public class TravelLogPlaceController : ControllerBase
{
    [HttpPost]
    [Route("{id}/place/{xid}")]
    public async Task<IActionResult> AddPlaceToTravelLog(Guid id, string xid)
    {
        return Ok();
    }

    [HttpPut]
    [Route("{id}/place/{xid}")]
    public async Task<IActionResult> UpdatePlaceInTravelLog(Guid id, string xid, UpdateTravelLogPlaceInfoModel placeInfo)
    {
        return Ok();
    }

    [HttpDelete]
    [Route("{id}/place/{xid}")]
    public async Task<IActionResult> DeletePlaceFromTravelLog(Guid id, string xid)
    {
        return Ok();
    }
}