using JourneyLog.BLL.Models.TravelLog;
using Microsoft.AspNetCore.Mvc;

namespace JourneyLog.PL.Controllers;

[ApiController]
[Route("api/travelLog")]
public class TravelLogController : ControllerBase
{

    [HttpPost]
    public async Task<IActionResult> CreateTravelLog([FromBody] CreateTravelLogModel travelLog)
    {
        return Ok();
    }

    [HttpPut]
    [Route("{id}")]
    public async Task<IActionResult> UpdateTravelLog(Guid id, UpdateTravelLogModel travelLog)
    {
        return Ok();
    }

    [HttpDelete]
    [Route("{id}")]
    public async Task<IActionResult> DeleteTravelLog(Guid id)
    {
        return Ok();
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<IActionResult> GetTravelLogById(Guid id)
    {
        return Ok(new GetTravelLogByIdModel());
    }
}