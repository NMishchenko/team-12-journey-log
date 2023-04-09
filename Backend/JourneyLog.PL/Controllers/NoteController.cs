using JourneyLog.BLL.Models.TravelLogPlaceNote;
using Microsoft.AspNetCore.Mvc;

namespace JourneyLog.PL.Controllers;

[ApiController]
[Route("api/travelLog")]
public class NoteController : ControllerBase
{
    [HttpPost]
    [Route("{id}/place/{xid}/note")]
    public async Task<IActionResult> CreateUpdateTravelLogPlaceNote(Guid id, string xid, [FromBody] CreateUpdateNoteModel note)
    {
        return Ok();
    }

    [HttpDelete]
    [Route("{id}/place/{xid}/note/{noteId}")]
    public async Task<IActionResult> DeleteTravelLogPlaceNote(Guid id, string xid, Guid noteId)
    {
        return Ok();
    }
}