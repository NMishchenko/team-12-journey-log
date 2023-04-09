using JourneyLog.BLL.Models.TravelLog;
using JourneyLog.BLL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace JourneyLog.PL.Controllers;

[ApiController]
[Route("api/travelLog")]
public class TravelLogController : ControllerBase
{
    private readonly ITravelLogService _travelLogService;
    
    public TravelLogController(ITravelLogService travelLogService)
    {
        _travelLogService = travelLogService;
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateTravelLog([FromBody] CreateTravelLogModel createTravelLogModel, CancellationToken cancellationToken)
    {
        await _travelLogService.AddAsync(createTravelLogModel, cancellationToken);
        return Ok();
    }

    [HttpPut]
    [Route("{id}")]
    public async Task<IActionResult> UpdateTravelLog(Guid id, UpdateTravelLogModel updateTravelLogModel, CancellationToken cancellationToken)
    {
        await _travelLogService.UpdateAsync(id, updateTravelLogModel, cancellationToken);
        return Ok();
    }

    [HttpDelete]
    [Route("{id}")]
    public async Task<IActionResult> DeleteTravelLog(Guid id, CancellationToken cancellationToken)
    {
        await _travelLogService.DeleteAsync(id, cancellationToken);
        return Ok();
    }
    
    [HttpGet]
    [Route("~api/user/travelLogs")]
    public async Task<IActionResult> GetTravelLogsByCurrentUser()
    {
        var travelLogs = await _travelLogService.GetAllByCurrentUserAsync();
        return Ok(travelLogs);
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<IActionResult> GetTravelLogById(Guid id)
    {
        var travelLog = await _travelLogService.GetByIdAsync(id);
        return Ok(travelLog);
    }
}