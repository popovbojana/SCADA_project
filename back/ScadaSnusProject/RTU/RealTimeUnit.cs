using Microsoft.AspNetCore.SignalR;
using ScadaSnusProject.Hubs;
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
    private readonly ITagRepository _tagRepository;
    private readonly IAlarmRepository _alarmRepository;
    private readonly Random _random = new Random();
    private readonly IHubContext<AlarmHub> _alarmHub;
    private readonly IHubContext<TagHub, ITagValueClient> _tagHub;
    private readonly IServiceProvider _serviceProvider;


    public RealTimeUnit(
        ILogger<RealTimeUnit> logger,
        ITagRepository tagRepository,
        IAlarmRepository alarmRepository,
        IHubContext<AlarmHub> alarmHub,
        IHubContext<TagHub, ITagValueClient> tagHub,
        IServiceProvider serviceProvider)
    {
        _logger = logger;
        _tagRepository = tagRepository;
        _alarmRepository = alarmRepository;
        _alarmHub = alarmHub;
        _tagHub = tagHub;
        _serviceProvider = serviceProvider;
    }

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
    
    private async Task SendTagValueToClients(TagValue tagValue)
    {
        await _tagHub.Clients.All.SendTagValue(tagValue);
    }


    private async Task GenerateDigitalValuesAsync(DigitalInput digitalInput, CancellationToken cancellationToken)
    {
        while (!cancellationToken.IsCancellationRequested)
        {
            int randomValue = _random.Next(2);
            var tagValue = new TagValue(DateTime.Now, randomValue, digitalInput.Id);
            _tagRepository.UpdateTagValue(digitalInput.Id, randomValue);
            _tagRepository.AddNewTagValue(tagValue);
            _logger.LogInformation($"Digital input value: TagId:{tagValue.TagId}, ScanTime: {digitalInput.ScanTime}, TimeStamp: {tagValue.Timestamp}, Value: {tagValue.Value}");

            await SendTagValueToClients(tagValue);
            await Task.Delay(TimeSpan.FromSeconds(digitalInput.ScanTime), cancellationToken);
        }
    }

    private async Task GenerateAnalogValuesAsync(AnalogInput analogInput, CancellationToken cancellationToken)
    {
        while (!cancellationToken.IsCancellationRequested)
        {
            double minValue = analogInput.LowLimit - 50;
            double maxValue = analogInput.HighLimit + 50;
            double randomValue = minValue + (_random.NextDouble() * (maxValue - minValue));
            var tagValue = new TagValue(DateTime.Now, randomValue, analogInput.Id);
            _tagRepository.UpdateTagValue(analogInput.Id, randomValue);
            _tagRepository.AddNewTagValue(tagValue);
            _logger.LogInformation($"Analog input value: TagId:{tagValue.TagId}, ScanTime: {analogInput.ScanTime}, TimeStamp: {tagValue.Timestamp}, Value: {tagValue.Value}");
            ICollection<Alarm> alarms = _alarmRepository.GetAllAlarmsForInput(analogInput.Id);
            List<Alarm> listAlarms = alarms.ToList();

            if (randomValue <= analogInput.LowLimit || randomValue >= analogInput.HighLimit)
            {
                ActivateAlarm(analogInput, randomValue, DateTime.Now, listAlarms);
            }

            await SendTagValueToClients(tagValue);
            await Task.Delay(TimeSpan.FromSeconds(analogInput.ScanTime), cancellationToken);
        }
    }
    
    private async void ActivateAlarm(AnalogInput analogInput, double value, DateTime currentTime, List<Alarm> alarms)
    {
        if (value <= alarms[0].Value && value > alarms[1].Value)
        {
            var alarmActivation = new AlarmActivation(currentTime, alarms[0].Id, analogInput.Id, value); 
            _alarmRepository.AddNewAlarmActivation(alarmActivation); 
            _logger.LogInformation("ACTIVATED: " + alarmActivation.Tag.Id + " Alarm " + alarmActivation.Alarm.Id + " Value " +alarmActivation.Value);
            await _alarmHub.Clients.All.SendAsync("ReceiveAlarmActivation", alarmActivation);
            await WriteAlarmActivationToFile(alarmActivation);
        }
        else if (value <= alarms[1].Value && value > alarms[2].Value)
        {
            var alarmActivation = new AlarmActivation(currentTime, alarms[1].Id, analogInput.Id, value); 
            _alarmRepository.AddNewAlarmActivation(alarmActivation); 
            _logger.LogInformation("ACTIVATED: " + alarmActivation.Tag.Id + " Alarm " + alarmActivation.Alarm.Id + " Value " +alarmActivation.Value);
            await _alarmHub.Clients.All.SendAsync("ReceiveAlarmActivation", alarmActivation);
            await WriteAlarmActivationToFile(alarmActivation);
        }
        else if (value <= alarms[2].Value)
        {
            var alarmActivation = new AlarmActivation(currentTime, alarms[2].Id, analogInput.Id, value); 
            _alarmRepository.AddNewAlarmActivation(alarmActivation); 
            _logger.LogInformation("ACTIVATED: " + alarmActivation.Tag.Id + " Alarm " + alarmActivation.Alarm.Id + " Value " +alarmActivation.Value);
            await _alarmHub.Clients.All.SendAsync("ReceiveAlarmActivation", alarmActivation);
            await WriteAlarmActivationToFile(alarmActivation);
        }
        else if (value >= alarms[3].Value && value < alarms[4].Value)
        { 
            var alarmActivation = new AlarmActivation(currentTime, alarms[3].Id, analogInput.Id, value); 
            _alarmRepository.AddNewAlarmActivation(alarmActivation); 
            _logger.LogInformation("ACTIVATED: " + alarmActivation.Tag.Id + " Alarm " + alarmActivation.Alarm.Id + " Value " +alarmActivation.Value);
            await _alarmHub.Clients.All.SendAsync("ReceiveAlarmActivation", alarmActivation);
            await WriteAlarmActivationToFile(alarmActivation);
        }
        else if (value >= alarms[4].Value && value < alarms[5].Value) 
        { 
            var alarmActivation = new AlarmActivation(currentTime, alarms[4].Id, analogInput.Id, value); 
            _alarmRepository.AddNewAlarmActivation(alarmActivation); 
            _logger.LogInformation("ACTIVATED: " + alarmActivation.Tag.Id + " Alarm " + alarmActivation.Alarm.Id + " Value " +alarmActivation.Value);
            await _alarmHub.Clients.All.SendAsync("ReceiveAlarmActivation", alarmActivation);
            await WriteAlarmActivationToFile(alarmActivation);
        }
        else if (value >= alarms[5].Value) 
        { 
            var alarmActivation = new AlarmActivation(currentTime, alarms[5].Id, analogInput.Id, value); 
            _alarmRepository.AddNewAlarmActivation(alarmActivation); 
            _logger.LogInformation("ACTIVATED: " + alarmActivation.Tag.Id + " Alarm " + alarmActivation.Alarm.Id + " Value " +alarmActivation.Value);
            await _alarmHub.Clients.All.SendAsync("ReceiveAlarmActivation", alarmActivation);
            await WriteAlarmActivationToFile(alarmActivation);
        }
    }
    
    private async Task WriteAlarmActivationToFile(AlarmActivation alarmActivation)
    {
        string filePath = "alarm_activations.txt";

        try
        {
            using (StreamWriter writer = File.AppendText(filePath))
            {
                string logMessage = $"ACTIVATED: TagId {alarmActivation.Tag.Id}, Alarm {alarmActivation.Alarm.Id}, Value {alarmActivation.Value}, TimeStamp {alarmActivation.Timestamp}";
                await writer.WriteLineAsync(logMessage);
            }
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error writing to file: {ex.Message}");
        }
    }
}

