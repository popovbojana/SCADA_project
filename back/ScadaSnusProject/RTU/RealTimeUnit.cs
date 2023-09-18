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
            int randomValue = Random.Next(2);
            var tagValue = new TagValue(DateTime.Now, randomValue, digitalInput.Id);
            
            // _tagRepository.UpdateTagValue(digitalInput.Id, randomValue);
            // _tagRepository.AddNewTagValue(tagValue);

            _logger.LogInformation($"Digital input value: TagId:{tagValue.TagId}, ScanTime: {digitalInput.ScanTime}, TimeStamp: {tagValue.Timestamp}, Value: {tagValue.Value}");
            
            await Task.Delay(TimeSpan.FromSeconds(digitalInput.ScanTime), cancellationToken);
        }
    }

    private async Task GenerateAnalogValuesAsync(AnalogInput analogInput, CancellationToken cancellationToken)
    {
        while (!cancellationToken.IsCancellationRequested)
        {
            double minValue = analogInput.LowLimit - 50;
            double maxValue = analogInput.HighLimit + 50;
            double randomValue = minValue + (Random.NextDouble() * (maxValue - minValue));
            var tagValue = new TagValue(DateTime.Now, randomValue, analogInput.Id);
            
            // _tagRepository.UpdateTagValue(analogInput.Id, randomValue);
            // _tagRepository.AddNewTagValue(tagValue);

            _logger.LogInformation($"Analog input value: TagId:{tagValue.TagId}, ScanTime: {analogInput.ScanTime}, TimeStamp: {tagValue.Timestamp}, Value: {tagValue.Value}");

            ICollection<Alarm> alarms = _alarmRepository.GetAllAlarmsForInput(analogInput.Id);
            List<Alarm> listAlarms = alarms.ToList();

            if (randomValue <= analogInput.LowLimit || randomValue >= analogInput.HighLimit)
            {
                ActivateAlarm(analogInput, randomValue, DateTime.Now, listAlarms);
            }

            await Task.Delay(TimeSpan.FromSeconds(analogInput.ScanTime), cancellationToken);
        }
    }

    private void PrintAlarmsOfTag(List<Alarm> alarms)
    {
        foreach (var alarm in alarms)
        {
            _logger.LogInformation("Id " + alarm.Id + " value " + alarm.Value);
        }
    }

    private void ActivateAlarm(AnalogInput analogInput, double value, DateTime currentTime, List<Alarm> alarms)
    {
        if (value <= alarms[0].Value && value > alarms[1].Value)
        {
            var alarmActivation = new AlarmActivation(currentTime, alarms[0].Id, analogInput.Id, value); 
            _alarmRepository.AddNewAlarmActivation(alarmActivation); 
            _logger.LogInformation("ACTIVATED: " + alarmActivation.Tag.Id + " Alarm " + alarmActivation.Alarm.Id + " Value " +alarmActivation.Value);
        }
        else if (value <= alarms[1].Value && value > alarms[2].Value)
        {
            var alarmActivation = new AlarmActivation(currentTime, alarms[1].Id, analogInput.Id, value); 
            _alarmRepository.AddNewAlarmActivation(alarmActivation); 
            _logger.LogInformation("ACTIVATED: " + alarmActivation.Tag.Id + " Alarm " + alarmActivation.Alarm.Id + " Value " +alarmActivation.Value);
        }
        else if (value <= alarms[2].Value)
        {
            var alarmActivation = new AlarmActivation(currentTime, alarms[2].Id, analogInput.Id, value); 
            _alarmRepository.AddNewAlarmActivation(alarmActivation); 
            _logger.LogInformation("ACTIVATED: " + alarmActivation.Tag.Id + " Alarm " + alarmActivation.Alarm.Id + " Value " +alarmActivation.Value);
        }
        else if (value >= alarms[3].Value && value < alarms[4].Value)
        { 
            var alarmActivation = new AlarmActivation(currentTime, alarms[3].Id, analogInput.Id, value); 
            _alarmRepository.AddNewAlarmActivation(alarmActivation); 
            _logger.LogInformation("ACTIVATED: " + alarmActivation.Tag.Id + " Alarm " + alarmActivation.Alarm.Id + " Value " +alarmActivation.Value);

        }
        else if (value >= alarms[4].Value && value < alarms[5].Value) 
        { 
            var alarmActivation = new AlarmActivation(currentTime, alarms[4].Id, analogInput.Id, value); 
            _alarmRepository.AddNewAlarmActivation(alarmActivation); 
            _logger.LogInformation("ACTIVATED: " + alarmActivation.Tag.Id + " Alarm " + alarmActivation.Alarm.Id + " Value " +alarmActivation.Value);

        }
        else if (value >= alarms[5].Value) 
        { 
            var alarmActivation = new AlarmActivation(currentTime, alarms[5].Id, analogInput.Id, value); 
            _alarmRepository.AddNewAlarmActivation(alarmActivation); 
            _logger.LogInformation("ACTIVATED: " + alarmActivation.Tag.Id + " Alarm " + alarmActivation.Alarm.Id + " Value " +alarmActivation.Value);
        }
    }
}
