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
    public Tag? GetTagById(int tagId);
    public void DeleteTag(int tagId);
    public void AddDigitalInput(DigitalInput digitalInput);
    public void AddDigitalOutput(DigitalOutput digitalOutput);
    public void AddAnalogInput(AnalogInput analogInput);
    public void AddAnalogOutput(AnalogOutput analogOutput);

}