using JourneyLog.BLL.Models.TravelLogPlaceNote;
using Microsoft.AspNetCore.Mvc;

namespace JourneyLog.PL.Controllers;

[ApiController]
[Route("api/travelLog")]
public class TravelLogPlaceNoteController : ControllerBase
{
    [HttpPost]
    [Route("{id}/place/{xid}/note/{id}")]
    public async Task<IActionResult> CreateUpdateTravelLogPlaceNote([FromBody] CreateUpdateTravelLogPlaceNoteModel note)
    {
        return Ok();
    }

    [HttpDelete]
    [Route("{id}/place/{xid}/note/{id}")]
    public async Task<IActionResult> DeleteTravelLogPlaceNote()
    {
        return Ok();
    }
}