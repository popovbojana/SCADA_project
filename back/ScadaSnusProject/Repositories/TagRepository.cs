using ScadaSnusProject.DbContext;
using ScadaSnusProject.Model;
using ScadaSnusProject.Repositories.Interfaces;

namespace ScadaSnusProject.Repositories;

public class TagRepository : ITagRepository
{
    private readonly AppDbContext _context;
    public TagRepository(AppDbContext context)
    {
        _context = context;
    }
    public ICollection<Tag> GetAllTags()
    {
        return _context.Tags.ToList();
    }

    public ICollection<DigitalInput> GetAllDigitalInputs()
    {
        return _context.DigitalInputs.ToList();
    }

    public ICollection<DigitalOutput> GetAllDigitalOutputs()
    {
        return _context.DigitalOutputs.ToList();
    }

    public ICollection<AnalogInput> GetAllAnalogInputs()
    {
        return _context.AnalogInputs.ToList();
    }

    public ICollection<AnalogOutput> GetAllAnalogOutputs()
    {
        return _context.AnalogOutputs.ToList();
    }

    public Tag? GetTagById(int tagId)
    {
        return _context.Tags.FirstOrDefault(t => t.Id == tagId);
    }

    public void DeleteTag(int tagId)
    {
        var tag = GetTagById(tagId);
        if (tag != null)
        {
            _context.Tags.Remove(tag);
            _context.SaveChanges();
        }
    }

    public void AddDigitalInput(DigitalInput digitalInput)
    {
        _context.DigitalInputs.Add(digitalInput);
        _context.SaveChanges();
    }

    public void AddDigitalOutput(DigitalOutput digitalOutput)
    {
        _context.DigitalOutputs.Add(digitalOutput);
        _context.SaveChanges();
    }

    public void AddAnalogInput(AnalogInput analogInput)
    {
        _context.AnalogInputs.Add(analogInput);
        _context.SaveChanges();
    }

    public void AddAnalogOutput(AnalogOutput analogOutput)
    {
        _context.AnalogOutputs.Add(analogOutput);
        _context.SaveChanges();
    }
}