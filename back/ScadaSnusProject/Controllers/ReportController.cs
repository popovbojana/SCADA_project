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

    [HttpGet]
    [Route("alarms-timespan")]
    public ActionResult GetAllAlarmsInTimespan([FromQuery] TimeSort timeSort,[FromQuery] AlarmSort alarmSort,[FromQuery] DateTime fromTime,[FromQuery] DateTime untilTime)
    {
    
        var dto = new TimeSortAndAlarmSortWithTimeSpanDTO
        {
            TimeSort = timeSort,
            AlarmSort = alarmSort,
            FromTime = fromTime,
            UntilTime = untilTime
        };
    
        return Ok(_reportService.GetAllAlarmsInTimespan(dto));
    }


    [HttpGet]
    [Route("alarms-priority")]
    public ActionResult GetAllAlarmsOfPriority(TimeSortAndAlarmPriorityDTO dto)
    {
        return Ok(_reportService.GetAllAlarmsOfPriority(dto));
    }

    [HttpGet]
    [Route("tag-values-timespan")]
    public ActionResult GetAllTagValuesInTimeSpan(TimeSortWithTimeSpanDTO dto)
    {
        return Ok(_reportService.GetAllTagValuesInTimeSpan(dto));
    }

    [HttpGet]
    [Route("last-values-analog-inputs")]
    public ActionResult GetAllLastValuesForAnalogInputs(TimeSortReportDTO dto)
    {
        return Ok(_reportService.GetAllLastValuesForAnalogInputs(dto));
    }

    [HttpGet]
    [Route("last-values-digital-inputs")]
    public ActionResult GetAllLastValuesForDigitalInputs(TimeSortReportDTO dto)
    {
        return Ok(_reportService.GetAllLastValuesForDigitalInputs(dto));
    }

    [HttpGet]
    [Route("tag-values-{tagId}")]
    public ActionResult GetAllTagValuesForTag(int tagId, TimeSortReportDTO dto)
    {
        return Ok(_reportService.GetAllTagValuesForTag(tagId, dto));
    }

}