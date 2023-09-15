using ScadaSnusProject.Model;
using ScadaSnusProject.Repositories.Interfaces;
using ScadaSnusProject.Services.Interfaces;

namespace ScadaSnusProject.Services;

public class AlarmService : IAlarmService
{
    private readonly IAlarmRepository _alarmRepository;

    public AlarmService(IAlarmRepository alarmRepository)
    {
        _alarmRepository = alarmRepository;
    }
    public ICollection<Alarm> GetAllAlarms()
    {
        return _alarmRepository.GetAllAlarms();
    }

    public void AddAlarm(Alarm alarm)
    {
        _alarmRepository.AddAlarm(alarm);
    }

    public bool RemoveAlarm(int id)
    {
        return _alarmRepository.RemoveAlarm(id);
    }
}