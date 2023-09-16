using ScadaSnusProject.Model;

namespace ScadaSnusProject.Services.Interfaces;

public interface ITagService
{
    public void AddAnalogInput(AnalogInput analogInput);
    public void AddAnalogOutput(AnalogOutput analogOutput);
    public void AddDigitalInput(DigitalInput digitalInput);
    public void AddDigitalOutput(DigitalOutput digitalOutput);
    public void DeleteTag(int tagId);
    public ICollection<Tag> GetAllInputs();
    public ICollection<Tag> GetAllOutputs();
    public void TurnOnScan(int tagId);
    public void TurnOffScan(int tagId);
    public ICollection<Tag> GetAllTags();
    public ICollection<DigitalInput> GetAllDigitalInputs();
    public ICollection<DigitalOutput> GetAllDigitalOutputs();
    public ICollection<AnalogInput> GetAllAnalogInputs();
    public ICollection<AnalogOutput> GetAllAnalogOutputs();
    public ICollection<Tag> GetAllOnScanInputs();
}