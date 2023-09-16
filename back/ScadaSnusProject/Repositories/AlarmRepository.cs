using ScadaSnusProject.DbContext;
using ScadaSnusProject.Model;
using ScadaSnusProject.Repositories.Interfaces;

namespace ScadaSnusProject.Repositories;

public class AlarmRepository : IAlarmRepository
{
    private readonly AppDbContext _context;
    private readonly ITagRepository _tagRepository;
    public AlarmRepository(AppDbContext context, ITagRepository tagRepository)
    {
        _context = context;
        _tagRepository = tagRepository;
    }
    public ICollection<Alarm> GetAllAlarms()
    {
        return _context.Alarms.ToList();
    }

    public Alarm? GetAlarmById(int id)
    {
        return _context.Alarms.FirstOrDefault(a => a.Id == id);
    }

    public bool AddAlarm(Alarm alarm)
    {
        var tag = _tagRepository.GetTagById(alarm.TagId);
        if (tag == null)
        {
            return false;
        }
        _context.Alarms.Add(alarm);
        _context.SaveChanges();
        return true;
    }

    public bool RemoveAlarm(int id)
    {
        var alarm = GetAlarmById(id);
        if (alarm != null)
        {
            _context.Alarms.Remove(alarm);
            _context.SaveChanges();
            return true;
        }

        return false;
    }
}