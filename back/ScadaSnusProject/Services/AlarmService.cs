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
        var success = _alarmRepository.AddAlarm(alarm);
        if (!success)
        {
            throw new Exception("Can't create new alarm because tag with this id doesn't exist!");
        }
    }

    public void RemoveAlarm(int id)
    {
        var success = _alarmRepository.RemoveAlarm(id);
        if (!success)
        {
            throw new Exception("Alarm with this id does not exist!");
        }
    }
}