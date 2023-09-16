using Microsoft.AspNetCore.Mvc;
using ScadaSnusProject.DTOs;
using ScadaSnusProject.Services.Interfaces;

namespace ScadaSnusProject.Controllers;

[ApiController]
[Route("api/report")]
public class ReportController : Controller
{
    private readonly IReportService _reportService;
    
    public ReportController(IReportService reportService)
    {
        _reportService = reportService;
    }
    
    // [HttpPost]
    // [Route("registration")]
    // public ActionResult Registration(RegisterUserDTO registerUser)
    // {
    //     try
    //     {
    //         var user = _userService.RegisterNewUser(registerUser);
    //         return Ok( new {Message = $"Successfully registered as {user.Username}!" });
    //     }
    //     catch (Exception e)
    //     {
    //         return BadRequest(new { e.Message });
    //     }
    // }

    [HttpGet]
    [Route("alarms-timespan")]
    public ActionResult GetAllAlarmsInTimespan()
    {
        return null;
    }

    [HttpGet]
    [Route("alarms-priority")]
    public ActionResult GetAllAlarmsOfPriority()
    {
        return null;
    }

    [HttpGet]
    [Route("tag-values-timespan")]
    public ActionResult GetAllTagValuesInTimeSpan()
    {
        return null;
    }

    [HttpGet]
    [Route("last-values-analog-inputs")]
    public ActionResult GetAllLastValuesForAnalogInputs()
    {
        return null;
    }

    [HttpGet]
    [Route("last-values-digital-inputs")]
    public ActionResult GetAllLastValuesForDigitalInputs(TimeSortReportDTO dto)
    {
        return null;
    }

    [HttpGet]
    [Route("tag-values-{tagId}")]
    public ActionResult GetAllTagValuesForTag(int tagId, TimeSortReportDTO dto)
    {
        return Ok(_reportService.GetAllTagValuesForTag(tagId, dto));
    }

}