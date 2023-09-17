using System.Collections;
using ScadaSnusProject.DTOs;
using ScadaSnusProject.Model;

namespace ScadaSnusProject.Services.Interfaces;

public interface IReportService
{
    public ICollection<TagValue> GetAllTagValuesForTag(int tagId, TimeSortReportDTO dto);
    public ICollection<TagValue> GetAllLastValuesForDigitalInputs(TimeSortReportDTO dto);
    public ICollection<TagValue> GetAllLastValuesForAnalogInputs(TimeSortReportDTO dto);
    public ICollection<TagValue> GetAllTagValuesInTimeSpan(TimeSortWithTimeSpanDTO dto);
    public ICollection<AlarmActivation> GetAllAlarmsOfPriority(TimeSortAndAlarmPriorityDTO dto);
    public ICollection<AlarmActivation> GetAllAlarmsInTimespan(TimeSortAndAlarmSortWithTimeSpanDTO dto);
}