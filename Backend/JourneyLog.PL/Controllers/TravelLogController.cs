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
    public async Task<IActionResult> UpdateTravelLog(UpdateTravelLogModel travelLog)
    {
        return Ok();
    }

    [HttpDelete]
    [Route("{id}")]
    public async Task<IActionResult> DeleteTravelLog()
    {
        return Ok();
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<IActionResult> GetTravelLogById()
    {
        return Ok(new GetTravelLogByIdModel());
    }
}