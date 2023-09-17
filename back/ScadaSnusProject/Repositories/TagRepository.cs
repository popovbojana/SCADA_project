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

    public Tag? GetTagByIOAddress(string address)
    {
        return _context.Tags.FirstOrDefault(t => t.IOAddress == address);
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

    public bool AddDigitalInput(DigitalInput digitalInput)
    {
        var existingTag = GetTagByIOAddress(digitalInput.IOAddress);
        if (existingTag != null)
        {
            return false;
        }
        _context.DigitalInputs.Add(digitalInput);
        _context.SaveChanges();
        return true;
    }

    public bool AddDigitalOutput(DigitalOutput digitalOutput)
    {
        var existingTag = GetTagByIOAddress(digitalOutput.IOAddress);
        if (existingTag != null)
        {
            return false;
        }
        _context.DigitalOutputs.Add(digitalOutput);
        _context.SaveChanges();
        return true;
    }

    public bool AddAnalogInput(AnalogInput analogInput)
    {
        var existingTag = GetTagByIOAddress(analogInput.IOAddress);
        if (existingTag != null)
        {
            return false;
        }
        _context.AnalogInputs.Add(analogInput);
        _context.SaveChanges();
        return true;
    }

    public bool AddAnalogOutput(AnalogOutput analogOutput)
    {
        var existingTag = GetTagByIOAddress(analogOutput.IOAddress);
        if (existingTag != null)
        {
            return false;
        }
        _context.AnalogOutputs.Add(analogOutput);
        _context.SaveChanges();
        return true;
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
            if (tagA.IsScanOn)
            {
                tagA.IsScanOn = false;
                _context.AnalogInputs.Update(tagA);
                _context.SaveChanges();
                return true;
            }
            return false;
        }
        var tagD = GetDigitalInputTagById(tagId);
        if (tagD != null)
        {
            if (tagD.IsScanOn)
            {
                tagD.IsScanOn = false;
                _context.DigitalInputs.Update(tagD);
                _context.SaveChanges();
                return true;
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
            return false;
        }
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
        return false;
    }

    public ICollection<Tag> GetAllOnScanInputs()
    {
        List<Tag> allOnScanInputs = new List<Tag>();
        List<DigitalInput> allDigitalInputs = _context.DigitalInputs.ToList();
        List<AnalogInput> allAnalogInputs = _context.AnalogInputs.ToList();
        foreach (var dInput in allDigitalInputs)
        {
            if (dInput.IsScanOn)
            {
                allOnScanInputs.Add(dInput);
            }
        }
        foreach (var aInput in allAnalogInputs)
        {
            if (aInput.IsScanOn)
            {
                allOnScanInputs.Add(aInput);
            }
        }
        return allOnScanInputs;
    }

    public void AddNewTagValue(TagValue tagValue)
    {
        _context.TagValues.Add(tagValue);
        _context.SaveChanges();
    }

    public void UpdateTagValue(int tagId, double newValue)
    {
        var tag = GetTagById(tagId);
        tag.Value = newValue;
        _context.Tags.Update(tag);
        _context.SaveChanges();
    }

    public ICollection<TagValue> GetAllTagValuesForTag(int tagId)
    {
        List<TagValue> tagValues = new List<TagValue>();
        foreach (var value in _context.TagValues.ToList())
        {
            if (value.TagId == tagId)
            {
                tagValues.Add(value);
            }
        }

        return tagValues;
    }

    public ICollection<TagValue> GetAllTagValues()
    {
        return _context.TagValues.ToList();
    }

}