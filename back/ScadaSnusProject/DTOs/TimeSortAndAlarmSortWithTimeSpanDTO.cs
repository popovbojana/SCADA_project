using System.Text.Json.Serialization;

namespace ScadaSnusProject.DTOs;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum AlarmSort
{
    Asc,
    Desc
}

public class TimeSortAndAlarmSortWithTimeSpanDTO
{
    public TimeSort TimeSort { get; set; }
    public AlarmSort AlarmSort { get; set; }
    public DateTime FromTime { get; set; }
    public DateTime UntilTime { get; set; }
}