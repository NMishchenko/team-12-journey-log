using JourneyLog.BLL.Models.TravelLogPlaceNotePhotos;
using Microsoft.AspNetCore.Mvc;

namespace JourneyLog.PL.Controllers;

[ApiController]
[Route("api/travelLog")]
public class NotePhotoController : ControllerBase
{
    
    [HttpPost]
    [Route("{id}/place/{xid}/note/{noteId}/photo")]
    public async Task<IActionResult> CreateNotePhoto(Guid id, string xid, Guid noteId, [FromBody] CreateNotePhotoModel photo)
    {
        return Ok();
    }
    
    [HttpDelete]
    [Route("{id}/place/{xid}/note/{noteId}/photo/{photoId}")]
    public async Task<IActionResult> DeleteNotePhoto(Guid id, string xid, Guid noteId, Guid photoId)
    {
        return Ok();
    }
}