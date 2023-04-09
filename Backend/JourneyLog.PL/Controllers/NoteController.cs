using JourneyLog.BLL.Models.TravelLogPlaceNote;
using JourneyLog.BLL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace JourneyLog.PL.Controllers;

[ApiController]
[Route("api/travelLog")]
public class NoteController : ControllerBase
{
    private readonly ITravelNoteService _travelNoteService;
    
    public NoteController(ITravelNoteService travelNoteService)
    {
        _travelNoteService = travelNoteService;
    }
    
    [HttpPost]
    [Route("{id}/place/{xid}/note")]
    public async Task<IActionResult> CreateUpdateTravelLogPlaceNote(Guid id, string xid, [FromBody] CreateUpdateNoteModel createUpdateNoteModel, CancellationToken cancellationToken)
    {
        await _travelNoteService.UpsertAsync(id, xid, createUpdateNoteModel, cancellationToken);
        return Ok();
    }

    [HttpDelete]
    [Route("{id}/place/{xid}/note/{noteId}")]
    public async Task<IActionResult> DeleteTravelLogPlaceNote(Guid id, string xid, Guid noteId, CancellationToken cancellationToken)
    {
        await _travelNoteService.DeleteAsync(noteId, cancellationToken);
        return Ok();
    }
}