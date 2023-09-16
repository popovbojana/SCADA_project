using System.ComponentModel.DataAnnotations;

namespace ScadaSnusProject.Model;

public class AlarmActivation
{
    [Key]
    public int Id { get; set; }
    public string Timestamp { get; set; }
    public int AlarmId { get; set; }
    public Alarm? Alarm { get; set; }
}