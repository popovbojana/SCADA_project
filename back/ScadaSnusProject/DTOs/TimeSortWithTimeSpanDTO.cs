namespace ScadaSnusProject.DTOs;

public class TimeSortWithTimeSpanDTO
{
    public TimeSort TimeSort { get; set; }
    public DateTime FromTime { get; set; }
    public DateTime UntilTime { get; set; }
}