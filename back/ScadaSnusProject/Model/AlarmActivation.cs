using System.ComponentModel.DataAnnotations;

namespace ScadaSnusProject.Model;

public class AlarmActivation
{
    [Key]
    public int Id { get; set; }
    public DateTime Timestamp { get; set; }
    public int AlarmId { get; set; }
    public Alarm? Alarm { get; set; }
    
    public int TagId { get; set; }
    
    public Tag? Tag { get; set; }
    
    public double Value { get; set; }

    public AlarmActivation() {}

    public AlarmActivation(int id, DateTime timestamp, int alarmId, int tagId, double value)
    {
        Id = id;
        Timestamp = timestamp;
        AlarmId = alarmId;
        TagId = tagId;
        Value = value;
    }

    public AlarmActivation(DateTime timestamp, int alarmId, int tagId, double value)
    {
        Timestamp = timestamp;
        AlarmId = alarmId;
        TagId = tagId;
        Value = value;
    }
}