using ScadaSnusProject.DbContext;
using ScadaSnusProject.Model;
using ScadaSnusProject.Repositories.Interfaces;

namespace ScadaSnusProject.Repositories;

public class AlarmRepository : IAlarmRepository
{
    private readonly AppDbContext _context;
    public AlarmRepository(AppDbContext context)
    {
        _context = context;
    }
    public ICollection<Alarm> GetAllAlarms()
    {
        return _context.Alarms.ToList();
    }

    public Alarm? GetAlarmById(int id)
    {
        return _context.Alarms.FirstOrDefault(a => a.Id == id);
    }

    public void AddAlarm(Alarm alarm)
    {
        _context.Alarms.Add(alarm);
        _context.SaveChanges();
    }

    public void RemoveAlarm(int id)
    {
        var alarm = GetAlarmById(id);
        if (alarm != null)
        {
            _context.Alarms.Remove(alarm);
            _context.SaveChanges();
        }
    }
}