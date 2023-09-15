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
        // return _context.Tags.ToList();
        List<Tag> allTags = new List<Tag>();
        foreach (var dInput in _context.DigitalInputs.ToList())
        {
            allTags.Add(dInput);
        }
        foreach (var dOutput in _context.DigitalOutputs.ToList())
        {
            allTags.Add(dOutput);
        }
        foreach (var aInput in _context.AnalogInputs.ToList())
        {
            allTags.Add(aInput);
        }
        foreach (var aOutput in _context.AnalogOutputs.ToList())
        {
            allTags.Add(aOutput);
        }
        return allTags;
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

    public ICollection<Tag> GetAllInputs()
    {
        List<Tag> allInputs = new List<Tag>();
        List<DigitalInput> allDigitalInputs = _context.DigitalInputs.ToList();
        List<AnalogInput> allAnalogInputs = _context.AnalogInputs.ToList();
        foreach (var dInput in allDigitalInputs)
        {
            allInputs.Add(dInput);
        }
        foreach (var aInput in allAnalogInputs)
        {
            allInputs.Add(aInput);
        }
        return allInputs;
    }

    public ICollection<Tag> GetAllOutputs()
    {List<Tag> allOutputs = new List<Tag>();
        List<DigitalOutput> allDigitalOutputs = _context.DigitalOutputs.ToList();
        List<AnalogOutput> allAnalogOutputs = _context.AnalogOutputs.ToList();
        foreach (var dOutput in allDigitalOutputs)
        {
            allOutputs.Add(dOutput);
        }
        foreach (var aOutput in allAnalogOutputs)
        {
            allOutputs.Add(aOutput);
        }
        return allOutputs;
    }

    public Tag? GetTagById(int tagId)
    {
        return _context.Tags.FirstOrDefault(t => t.Id == tagId);
    }

    public bool DeleteTag(int tagId)
    {
        var tag = GetTagById(tagId);
        if (tag != null)
        {
            _context.Tags.Remove(tag);
            _context.SaveChanges();
            return true;
        }

        return false;
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
    

    public DigitalInput? GetDigitalInputTagById(int tagId)
    {
        foreach (var dInput in _context.DigitalInputs.ToList())
        {
            if (dInput.Id == tagId)
            {
                return dInput;
            }
        }

        return null;
    }

    public AnalogInput? GetAnalogInputTagById(int tagId)
    {
        foreach (var aInput in _context.AnalogInputs.ToList())
        {
            if (aInput.Id == tagId)
            {
                return aInput;
            }
        }
        return null;
    }

    //true ako je uspesno izvrseno, false ako nije (ako ne postoji ili je vec off)
    public bool TurnOffScan(int tagId)
    {
        var tagA = GetAnalogInputTagById(tagId);
        if (tagA != null)
        {
            if (tagA.IsScanOn == true)
            {
                tagA.IsScanOn = false;
                _context.AnalogInputs.Update(tagA);
                _context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            var tagD = GetDigitalInputTagById(tagId);
            if (tagD != null)
            {
                if (tagD.IsScanOn == true)
                {
                    tagD.IsScanOn = false;
                    _context.DigitalInputs.Update(tagD);
                    _context.SaveChanges();
                    return true;
                }
            }
        }
        return false;
    }

    //true ako je uspesno izvrseno, false ako nije (ako ne postoji ili je vec on)
    public bool TurnOnScan(int tagId)
    {
        var tagA = GetAnalogInputTagById(tagId);
        if (tagA != null)
        {
            if (tagA.IsScanOn == false)
            {
                tagA.IsScanOn = true;
                _context.AnalogInputs.Update(tagA);
                _context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            var tagD = GetDigitalInputTagById(tagId);
            if (tagD != null)
            {
                if (tagD.IsScanOn == false)
                {
                    tagD.IsScanOn = true;
                    _context.DigitalInputs.Update(tagD);
                    _context.SaveChanges();
                    return true;
                }
            }
        }
        return false;
    }
}