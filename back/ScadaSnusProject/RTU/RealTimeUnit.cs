using ScadaSnusProject.Model;
using ScadaSnusProject.Repositories.Interfaces;

namespace ScadaSnusProject.RTU;

using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

public class RealTimeUnit : BackgroundService
{
    private readonly ILogger<RealTimeUnit> _logger;
    private static readonly Random Random = new Random();
    private readonly ITagRepository _tagRepository;

    public RealTimeUnit(ILogger<RealTimeUnit> logger, ITagRepository tagRepository)
    {
        _logger = logger;
        _tagRepository = tagRepository;
    }
    
    // public RealTimeUnit(ILogger<RealTimeUnit> logger)
    // {
    //     _logger = logger;
    // }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        _logger.LogInformation("RTU Background Service is starting.");

        while (!stoppingToken.IsCancellationRequested)
        {
            _logger.LogInformation("RTU Background Service is running.");
            
            bool isAnalog = Random.Next(2) == 0;
            
            if (isAnalog)
            {
                var tag = GenerateRandomAnalogInput();
                _tagRepository.AddAnalogInput(tag);
                _logger.LogInformation($"Analog input: Name:{tag.Name}, Description: {tag.Description}, IOAddress: {tag.IOAddress}, Value: {tag.Value}, ScanTime: {tag.ScanTime}, IsScanOn: {tag.IsScanOn}, LowLimit: {tag.LowLimit}, HighLimit: {tag.HighLimit}, Unit: {tag.Unit}");
            }
            else
            {
                var tag = GenerateRandomDigitalInput();
                _tagRepository.AddDigitalInput(tag);
                _logger.LogInformation(
                    $"Digital input: Name:{tag.Name}, Description: {tag.Description}, IOAddress: {tag.IOAddress}, Value: {tag.Value}, ScanTime: {tag.ScanTime}, IsScanOn: {tag.IsScanOn}");
            }
            
            await Task.Delay(TimeSpan.FromSeconds(1), stoppingToken);
        }

        _logger.LogInformation("RTU Background Service is stopping.");
    }
    
    //todo: dodati logiku za generisanje random inputa
    private static AnalogInput GenerateRandomAnalogInput()
    {
        return new AnalogInput()
        {
            Name = "analogni",
            Description = "proba",
            IOAddress = "adresa1",
            
            Value = 13.98,
            ScanTime = "2023-09-15T15:26:58",
            IsScanOn = true,
            LowLimit = 1,
            HighLimit = 100,
            Unit = "m"
        };
    }
    
    private static DigitalInput GenerateRandomDigitalInput()
    {
        return new DigitalInput()
        {
            Name = "digitalni",
            Description = "proba",
            IOAddress = "adresa2",
            Value = 0,
            ScanTime = "2023-09-15T15:27:58",
            IsScanOn = true
        };
    }
}
