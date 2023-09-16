using Microsoft.AspNetCore.Mvc;
using ScadaSnusProject.Model;
using ScadaSnusProject.Services.Interfaces;

namespace ScadaSnusProject.Controllers;

[ApiController]
[Route("api/tag")]
public class TagController : Controller
{
    private readonly ITagService _tagService;

    public TagController(ITagService tagService)
    {
        _tagService = tagService;
    }

    [HttpPost]
    [Route("add-analog-input")]
    public ActionResult AddAnalogInput(AnalogInput analogInput)
    {
        try
        {
            _tagService.AddAnalogInput(analogInput);
            return Ok(new { Message = "Successfully added new analog input!" });
        }
        catch (Exception e)
        {
            return BadRequest(new { Message = e.Message });
        }
    }
    
    [HttpPost]
    [Route("add-analog-output")]
    public ActionResult AddAnalogOutput(AnalogOutput analogOutput)
    {
        try
        {
            _tagService.AddAnalogOutput(analogOutput);
            return Ok(new { Message = "Successfully added new analog output!" });
        }
        catch (Exception e)
        {
            return BadRequest(new { Message = e.Message });
        }
    }
    
    [HttpPost]
    [Route("add-digital-input")]
    public ActionResult AddDigitalInput(DigitalInput digitalInput)
    {
        try
        {
            _tagService.AddDigitalInput(digitalInput);
            return Ok(new { Message = "Successfully added new digital input!" });
        }
        catch (Exception e)
        {
            return BadRequest(new { Message = e.Message });
        }
    }
    
    [HttpPost]
    [Route("add-digital-output")]
    public ActionResult AddDigitalOutput(DigitalOutput digitalOutput)
    {
        try
        {
            _tagService.AddDigitalOutput(digitalOutput);
            return Ok(new { Message = "Successfully added new digital output!" });
        }
        catch (Exception e)
        {
            return BadRequest(new { Message = e.Message });
        }
    }

    [HttpDelete]
    [Route("remove-tag-{tagId}")]
    public ActionResult RemoveTag(int tagId)
    {
        try
        {
            _tagService.DeleteTag(tagId);
            return Ok(new { Message = $"Successfully removed tag with id: {tagId}" });
        } 
        catch (Exception e)
        {
            return BadRequest(new { Message = e.Message });
        }
    }

    [HttpPut]
    [Route("scan-on-{tagId}")]
    public ActionResult TurnOnScan(int tagId)
    {
        try
        {
            _tagService.TurnOnScan(tagId);
            return Ok(new { Message = $"Successfully turned on scan for tag with id: {tagId}" });
        }
        catch (Exception e)
        {
            return BadRequest(new { Message = e.Message });
        }
    }
    
    [HttpPut]
    [Route("scan-off-{tagId}")]
    public ActionResult TurnOffScan(int tagId)
    {
        try
        {
            _tagService.TurnOffScan(tagId);
            return Ok(new { Message = $"Successfully turned off scan for tag with id: {tagId}" });
        }
        catch (Exception e)
        {
            return BadRequest(new { Message = e.Message });
        }
    }

    [HttpGet]
    [Route("")]
    public ActionResult GetAllTags()
    {
        return Ok(_tagService.GetAllTags());
    }
    
    [HttpGet]
    [Route("all-inputs")]
    public ActionResult GetAllInputs()
    {
        return Ok(_tagService.GetAllInputs());
    }
    
    [HttpGet]
    [Route("all-outputs")]
    public ActionResult GetAllOutputs()
    {
        return Ok(_tagService.GetAllOutputs());
    }
    
    [HttpGet]
    [Route("all-analog-inputs")]
    public ActionResult GetAllAnalogInputs()
    {
        return Ok(_tagService.GetAllAnalogInputs());
    }
    
    [HttpGet]
    [Route("all-analog-outputs")]
    public ActionResult GetAllAnalogOutputs()
    {
        return Ok(_tagService.GetAllAnalogOutputs());
    }
    
    [HttpGet]
    [Route("all-digital-inputs")]
    public ActionResult GetAllDigitalInputs()
    {
        return Ok(_tagService.GetAllDigitalInputs());
    }
    
    [HttpGet]
    [Route("all-digital-outputs")]
    public ActionResult GetAllDigitalOutputs()
    {
        return Ok(_tagService.GetAllDigitalOutputs());
    }
    
}