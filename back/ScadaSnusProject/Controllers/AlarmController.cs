using Microsoft.AspNetCore.Mvc;
using ScadaSnusProject.Model;
using ScadaSnusProject.Services.Interfaces;

namespace ScadaSnusProject.Controllers;

[ApiController]
[Route("api/alarm")]
public class AlarmController : Controller
{
    private readonly IAlarmService _alarmService;

    public AlarmController(IAlarmService alarmService)
    {
        _alarmService = alarmService;
    }

    [HttpPost]
    [Route("add-alarm")]
    public ActionResult AddAlarm(Alarm alarm)
    {
        try
        {
            _alarmService.AddAlarm(alarm);
            return Ok(new { Message = "Successfully added new alarm!" });
        }
        catch (Exception e)
        {
            return BadRequest(new { e.Message });
        }
    }
    
    [HttpDelete]
    [Route("remove-alarm-{tagId}")]
    public ActionResult RemoveAlarm(int tagId)
    {
        try
        {
            _alarmService.RemoveAlarm(tagId);
            return Ok(new { Message = $"Successfully removed alarm with id: {tagId}!" });
        }
        catch (Exception e)
        {
            return BadRequest(new { e.Message });
        }
    }
    
    [HttpGet]
    [Route("")]
    public ActionResult GetAllAlarms()
    {
        return Ok(_alarmService.GetAllAlarms());
    }
}