using ScadaSnusProject.Model;
using ScadaSnusProject.Repositories.Interfaces;
using ScadaSnusProject.Services.Interfaces;

namespace ScadaSnusProject.Services;

public class TagService : ITagService
{
    private readonly ITagRepository _tagRepository;

    public TagService(ITagRepository tagRepository)
    {
        _tagRepository = tagRepository;
    }
    public void AddAnalogInput(AnalogInput analogInput)
    {
        _tagRepository.AddAnalogInput(analogInput);
    }

    public void AddAnalogOutput(AnalogOutput analogOutput)
    {
        _tagRepository.AddAnalogOutput(analogOutput);
    }

    public void AddDigitalInput(DigitalInput digitalInput)
    {
        _tagRepository.AddDigitalInput(digitalInput);
    }

    public void AddDigitalOutput(DigitalOutput digitalOutput)
    {
        _tagRepository.AddDigitalOutput(digitalOutput);
    }

    public void DeleteTag(int tagId)
    {
        _tagRepository.DeleteTag(tagId);
    }

    public ICollection<Tag> GetAllInputs()
    {
        return _tagRepository.GetAllInputs();
    }

    public ICollection<Tag> GetAllOutputs()
    {
        return _tagRepository.GetAllOutputs();
    }

    public bool TurnOnScan(int tagId)
    {
        return _tagRepository.TurnOnScan(tagId);
    }

    public bool TurnOffScan(int tagId)
    {
        return _tagRepository.TurnOffScan(tagId);
    }

    public ICollection<Tag> GetAllTags()
    {
        return _tagRepository.GetAllTags();
    }

    public ICollection<DigitalInput> GetAllDigitalInputs()
    {
        return _tagRepository.GetAllDigitalInputs();
    }

    public ICollection<DigitalOutput> GetAllDigitalOutputs()
    {
        return _tagRepository.GetAllDigitalOutputs();
    }

    public ICollection<AnalogInput> GetAllAnalogInputs()
    {
        return _tagRepository.GetAllAnalogInputs();
    }

    public ICollection<AnalogOutput> GetAllAnalogOutputs()
    {
        return _tagRepository.GetAllAnalogOutputs();
    }
}