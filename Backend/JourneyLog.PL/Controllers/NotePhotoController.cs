using JourneyLog.BLL.Models.TravelLogPlaceNotePhotos;
using JourneyLog.BLL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace JourneyLog.PL.Controllers;

[ApiController]
[Route("api/travelLog")]
public class NotePhotoController : ControllerBase
{
    private readonly INotePhotoService _notePhotoService;
    
    public NotePhotoController(INotePhotoService notePhotoService)
    {
        _notePhotoService = notePhotoService;
    }
    
    [HttpPost]
    [Route("{id}/place/{xid}/note/{noteId}/photo")]
    public async Task<IActionResult> CreateNotePhoto(Guid id, string xid, Guid noteId, [FromBody] CreateNotePhotoModel photo, CancellationToken cancellationToken)
    {
        await _notePhotoService.CreateAsync(noteId, photo, cancellationToken);
        return Ok();
    }
    
    [HttpDelete]
    [Route("{id}/place/{xid}/note/{noteId}/photo/{photoId}")]
    public async Task<IActionResult> DeleteNotePhoto(Guid id, string xid, Guid noteId, Guid photoId, CancellationToken cancellationToken)
    {
        await _notePhotoService.DeleteAsync(photoId, cancellationToken);
        return Ok();
    }
}