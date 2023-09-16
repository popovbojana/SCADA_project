using ScadaSnusProject.Model;

namespace ScadaSnusProject.Repositories.Interfaces;

public interface IAlarmRepository
{
    public ICollection<Alarm> GetAllAlarms();
    public Alarm? GetAlarmById(int id);
    public bool AddAlarm(Alarm alarm);
    public bool RemoveAlarm(int id);
    public void AddNewAlarmActivation(AlarmActivation alarmActivation);
    public ICollection<Alarm> GetAllAlarmsForInput(int id);

}