using ScadaSnusProject.Model;

namespace ScadaSnusProject.Repositories.Interfaces;

public interface ITagRepository
{
    public ICollection<Tag> GetAllTags();
    public ICollection<DigitalInput> GetAllDigitalInputs();
    public ICollection<DigitalOutput> GetAllDigitalOutputs();
    public ICollection<AnalogInput> GetAllAnalogInputs();
    public ICollection<AnalogOutput> GetAllAnalogOutputs();
    public ICollection<Tag> GetAllInputs();
    public ICollection<Tag> GetAllOutputs();
    public Tag? GetTagById(int tagId);
    public Tag? GetTagByIOAddress(string address);
    public bool DeleteTag(int tagId);
    public bool AddDigitalInput(DigitalInput digitalInput);
    public bool AddDigitalOutput(DigitalOutput digitalOutput);
    public bool AddAnalogInput(AnalogInput analogInput);
    public bool AddAnalogOutput(AnalogOutput analogOutput);
    public DigitalInput? GetDigitalInputTagById(int tagId);
    public AnalogInput? GetAnalogInputTagById(int tagId);
    public bool TurnOffScan(int tagId);
    public bool TurnOnScan(int tagId);
    public ICollection<Tag> GetAllOnScanInputs();
    public void AddNewTagValue(TagValue tagValue);
    public void UpdateTagValue(int tagId, double newValue);
}