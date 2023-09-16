using System.ComponentModel.DataAnnotations;

namespace ScadaSnusProject.Model;

public class AlarmActivation
{
    [Key]
    public int Id { get; set; }
    public string Timestamp { get; set; }
    public int AlarmId { get; set; }
    public Alarm? Alarm { get; set; }

    public AlarmActivation(int id, string timestamp, int alarmId)
    {
        Id = id;
        Timestamp = timestamp;
        AlarmId = alarmId;
    }
    
    public AlarmActivation(string timestamp, int alarmId)
    {
        Timestamp = timestamp;
        AlarmId = alarmId;
    }
}