using System.Collections;
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
        var success = _tagRepository.AddAnalogInput(analogInput);
        if (!success)
        {
            throw new Exception("This IOAddress is already in use!");
        }
    }

    public void AddAnalogOutput(AnalogOutput analogOutput)
    {
        var success = _tagRepository.AddAnalogOutput(analogOutput);
        if (!success)
        {
            throw new Exception("This IOAddress is already in use!");
        }
    }

    public void AddDigitalInput(DigitalInput digitalInput)
    {
        var success = _tagRepository.AddDigitalInput(digitalInput);
        if (!success)
        {
            throw new Exception("This IOAddress is already in use!");
        }
    }

    public void AddDigitalOutput(DigitalOutput digitalOutput)
    {
        var success = _tagRepository.AddDigitalOutput(digitalOutput);
        if (!success)
        {
            throw new Exception("This IOAddress is already in use!");
        }
    }

    public void DeleteTag(int tagId)
    {
        var success = _tagRepository.DeleteTag(tagId);
        if (!success)
        {
            throw new Exception("Tag with this id does not exist!");
        }
    }

    public ICollection<Tag> GetAllInputs()
    {
        return _tagRepository.GetAllInputs();
    }

    public ICollection<Tag> GetAllOutputs()
    {
        return _tagRepository.GetAllOutputs();
    }

    public void TurnOnScan(int tagId)
    {
        var success = _tagRepository.TurnOnScan(tagId);
        if (!success)
        {
            throw new Exception("Tag with this id does not exist or is already turned on!");
        }
    }

    public void TurnOffScan(int tagId)
    {
        var success = _tagRepository.TurnOffScan(tagId);
        if (!success)
        {
            throw new Exception("Tag with this id does not exist or is already turned off!");
        }
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

    public ICollection<Tag> GetAllOnScanInputs()
    {
        return _tagRepository.GetAllOnScanInputs();
    }
}