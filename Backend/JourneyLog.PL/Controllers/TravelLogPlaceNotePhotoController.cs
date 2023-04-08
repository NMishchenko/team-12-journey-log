using JourneyLog.BLL.Models.TravelLogPlaceNotePhotos;
using Microsoft.AspNetCore.Mvc;

namespace JourneyLog.PL.Controllers;

[ApiController]
[Route("api/travelLog")]
public class TravelLogPlaceNotePhotoController : ControllerBase
{
    
    [HttpPost]
    [Route("{id}/place/{xid}/note/{id}/photo")]
    public async Task<IActionResult> CreateNotePhoto([FromBody] CreateNotePhotoModel photo)
    {
        return Ok();
    }
    
    [HttpDelete]
    [Route("{id}/place/{xid}/note/{id}/photo/{id}")]
    public async Task<IActionResult> DeleteNotePhoto()
    {
        return Ok();
    }
}