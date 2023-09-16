// using Microsoft.AspNetCore.SignalR;
// using ScadaSnusProject.Hubs;

using System.Collections.ObjectModel;
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

    private readonly IAlarmRepository _alarmRepository;
    // private readonly IHubContext<TagHub> _hubContext;

    public RealTimeUnit(ILogger<RealTimeUnit> logger, ITagRepository tagRepository, IAlarmRepository alarmRepository)
    {
        _logger = logger;
        _tagRepository = tagRepository;
        _alarmRepository = alarmRepository;
    }
    
    // public RealTimeUnit(ILogger<RealTimeUnit> logger, ITagRepository tagRepository, IHubContext<TagHub> hubContext, IAlarmRepository _alarmRepository)
    // {
    //     _logger = logger;
    //     _tagRepository = tagRepository;
    //     _hubContext = hubContext;
    //     _alarmRepository = alarmRepository;
    // }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        _logger.LogInformation("RTU Background Service is starting.");

        while (!stoppingToken.IsCancellationRequested)
        {
            _logger.LogInformation("RTU Background Service is running.");
            var digitalInputs = _tagRepository.GetAllDigitalInputs(); 
            var analogInputs = _tagRepository.GetAllAnalogInputs();

            var generateDigitalValuesTasks = digitalInputs.Select(input => GenerateDigitalValuesAsync(input, stoppingToken));

            var generateAnalogValuesTasks = analogInputs.Select(input => GenerateAnalogValuesAsync(input, stoppingToken));

            await Task.WhenAll(generateDigitalValuesTasks.Concat(generateAnalogValuesTasks));
        }

        _logger.LogInformation("RTU Background Service is stopping.");
    }

    private async Task GenerateDigitalValuesAsync(DigitalInput digitalInput, CancellationToken cancellationToken)
    {
        while (!cancellationToken.IsCancellationRequested)
        {
            DateTime currentTime = DateTime.Now;
            string currentTimeString = currentTime.ToString("yyyy-MM-ddTHH:mm:ss");
            int randomValue = Random.Next(2);
            var tagValue = new TagValue(currentTimeString, randomValue, digitalInput.Id);
            
            // _tagRepository.AddNewTagValue(tagValue);
            // _tagRepository.UpdateTagValue(digitalInput.Id, randomValue);
            
            _logger.LogInformation($"Digital input value: TagId:{tagValue.TagId}, ScanTime: {digitalInput.ScanTime}, TimeStamp: {tagValue.Timestamp}, Value: {tagValue.Value}");
            
            await Task.Delay(TimeSpan.FromSeconds(digitalInput.ScanTime), cancellationToken);
        }
    }

    private async Task GenerateAnalogValuesAsync(AnalogInput analogInput, CancellationToken cancellationToken)
    {
        while (!cancellationToken.IsCancellationRequested)
        {
            DateTime currentTime = DateTime.Now;
            string currentTimeString = currentTime.ToString("yyyy-MM-ddTHH:mm:ss");
            double minValue = analogInput.LowLimit - 50;
            double maxValue = analogInput.HighLimit + 50;
            double randomValue = minValue + (Random.NextDouble() * (maxValue - minValue));
            var tagValue = new TagValue(currentTimeString, randomValue, analogInput.Id);
            
            // _tagRepository.AddNewTagValue(tagValue);
            // _tagRepository.UpdateTagValue(analogInput.Id, randomValue);
            
            _logger.LogInformation($"Analog input value: TagId:{tagValue.TagId}, ScanTime: {analogInput.ScanTime}, TimeStamp: {tagValue.Timestamp}, Value: {tagValue.Value}");

            //todo: trigerovati alarm
            // ICollection<Alarm> alarms = _alarmRepository.GetAllAlarmsForInput(analogInput.Id);
            //
            // if (randomValue < analogInput.LowLimit)
            // {
            //     var alarmActivation = new AlarmActivation();
            // }
            
            await Task.Delay(TimeSpan.FromSeconds(analogInput.ScanTime), cancellationToken);
        }
    }

}
