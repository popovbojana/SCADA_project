using System.Text.Json.Serialization;

namespace ScadaSnusProject.DTOs;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum TimeSort
{
    Desc,
    Asc
}

public class TimeSortReportDTO
{
    public TimeSort TimeSort { get; set; }
}