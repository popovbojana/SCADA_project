using ScadaSnusProject.Model;

namespace ScadaSnusProject.Services.Interfaces;

public interface IAlarmService
{
    public ICollection<Alarm> GetAllAlarms();
    public void AddAlarm(Alarm alarm);
    public bool RemoveAlarm(int id);
}