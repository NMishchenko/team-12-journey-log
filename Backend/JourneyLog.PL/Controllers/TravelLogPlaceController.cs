using JourneyLog.BLL.Models.TravelLog;
using JourneyLog.BLL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace JourneyLog.PL.Controllers;

[ApiController]
[Route("api/travelLog")]
public class TravelLogPlaceController : ControllerBase
{
    private readonly ITravelLogPlaceService _travelLogPlaceService;
    
    public TravelLogPlaceController(ITravelLogPlaceService travelLogPlaceService)
    {
        _travelLogPlaceService = travelLogPlaceService;
    }
    
    [HttpPost]
    [Route("{id}/place/{xid}")]
    public async Task<IActionResult> AddPlaceToTravelLog(Guid id, string xid, CancellationToken cancellationToken)
    {
        await _travelLogPlaceService.AddAsync(id, xid, cancellationToken);
        return Ok();
    }

    [HttpPut]
    [Route("{id}/place/{xid}")]
    public async Task<IActionResult> UpdatePlaceInTravelLog(Guid id, string xid, UpdateTravelLogPlaceInfoModel updateTravelLogPlaceInfoModel, CancellationToken cancellationToken)
    {
        await _travelLogPlaceService.UpdateAsync(id, xid, updateTravelLogPlaceInfoModel, cancellationToken);
        return Ok();
    }

    [HttpDelete]
    [Route("{id}/place/{xid}")]
    public async Task<IActionResult> DeletePlaceFromTravelLog(Guid id, string xid, CancellationToken cancellationToken)
    {
        await _travelLogPlaceService.DeleteAsync(id, xid, cancellationToken);
        return Ok();
    }
}