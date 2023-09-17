using System.ComponentModel.DataAnnotations;

namespace ScadaSnusProject.Model;

public class AlarmActivation
{
    [Key]
    public int Id { get; set; }
    public DateTime Timestamp { get; set; }
    public int AlarmId { get; set; }
    public Alarm? Alarm { get; set; }

    public AlarmActivation(int id, DateTime timestamp, int alarmId)
    {
        Id = id;
        Timestamp = timestamp;
        AlarmId = alarmId;
    }
    
    public AlarmActivation(DateTime timestamp, int alarmId)
    {
        Timestamp = timestamp;
        AlarmId = alarmId;
    }
}