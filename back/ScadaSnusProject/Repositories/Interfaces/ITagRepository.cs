using System.Collections;
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
    public bool DeleteTag(int tagId);
    public void AddDigitalInput(DigitalInput digitalInput);
    public void AddDigitalOutput(DigitalOutput digitalOutput);
    public void AddAnalogInput(AnalogInput analogInput);
    public void AddAnalogOutput(AnalogOutput analogOutput);
    public DigitalInput? GetDigitalInputTagById(int tagId);
    public AnalogInput? GetAnalogInputTagById(int tagId);
    public bool TurnOffScan(int tagId);
    public bool TurnOnScan(int tagId);

}