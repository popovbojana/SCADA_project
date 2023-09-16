using Microsoft.AspNetCore.SignalR;
using Microsoft.VisualBasic.CompilerServices;
using ScadaSnusProject.Hubs;
using ScadaSnusProject.Model;
using ScadaSnusProject.Repositories.Interfaces;
using ScadaSnusProject.Global;

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
    private readonly IHubContext<TagHub> _hubContext;

    public RealTimeUnit(ILogger<RealTimeUnit> logger, ITagRepository tagRepository, IHubContext<TagHub> hubContext)
    {
        _logger = logger;
        _tagRepository = tagRepository;
        _hubContext = hubContext;
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
                // var tag = GenerateRandomAnalogInput();
                // _tagRepository.AddAnalogInput(tag);
                // _logger.LogInformation($"Analog input: Name:{tag.Name}, Description: {tag.Description}, IOAddress: {tag.IOAddress}, Value: {tag.Value}, ScanTime: {tag.ScanTime}, IsScanOn: {tag.IsScanOn}, LowLimit: {tag.LowLimit}, HighLimit: {tag.HighLimit}, Unit: {tag.Unit}");
                // await _hubContext.Clients.All.SendAsync("AnalogInputUpdate", tag);

            }
            else
            {
                // var tag = GenerateRandomDigitalInput();
                // _tagRepository.AddDigitalInput(tag);
                // _logger.LogInformation($"Digital input: Name:{tag.Name}, Description: {tag.Description}, IOAddress: {tag.IOAddress}, Value: {tag.Value}, ScanTime: {tag.ScanTime}, IsScanOn: {tag.IsScanOn}");
                // await _hubContext.Clients.All.SendAsync("DigitalInputUpdate", tag);

            }
            
            await Task.Delay(TimeSpan.FromSeconds(5), stoppingToken);
        }

        _logger.LogInformation("RTU Background Service is stopping.");
    }
    
    // private static AnalogInput GenerateRandomAnalogInput()
    // {
    //     int number = Random.Next(1, 4);
    //     AnalogInput analogInput = new AnalogInput();
    //     switch (number)
    //     {
    //         case 1:
    //             analogInput.Name = "Analog Temp";
    //             analogInput.Description = Global.AnalogGlobalValues.TemperatureDescription;
    //             analogInput.IOAddress = "adresa1";
    //             analogInput.Value = Random.Next(0, 100);
    //             analogInput.ScanTime = DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ss");
    //             analogInput.IsScanOn = true;
    //             analogInput.LowLimit = Global.AnalogGlobalValues.TemperatureMinValue;
    //             analogInput.HighLimit = Global.AnalogGlobalValues.TemperatureMaxValue;
    //             analogInput.Unit = Global.AnalogGlobalValues.C;
    //             break;
    //         
    //         case 2:
    //             analogInput.Name = "Analog depth";
    //             analogInput.Description = Global.AnalogGlobalValues.DepthDescription;
    //             analogInput.IOAddress = "adresa1";
    //             analogInput.Value = Random.Next(20, 50);
    //             analogInput.ScanTime = DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ss");
    //             analogInput.IsScanOn = true;
    //             analogInput.LowLimit = Global.AnalogGlobalValues.DepthMinValue;
    //             analogInput.HighLimit = Global.AnalogGlobalValues.DepthMaxValue;
    //             analogInput.Unit = Global.AnalogGlobalValues.M;
    //             break;
    //         
    //         case 3:
    //             analogInput.Name = "Analog density";
    //             analogInput.Description = Global.AnalogGlobalValues.DensityDescription;
    //             analogInput.IOAddress = "adresa1";
    //             analogInput.Value = Random.Next(900, 1100);
    //             analogInput.ScanTime = DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ss");
    //             analogInput.IsScanOn = true;
    //             analogInput.LowLimit = Global.AnalogGlobalValues.DepthMinValue;
    //             analogInput.HighLimit = Global.AnalogGlobalValues.DepthMaxValue;
    //             analogInput.Unit = Global.AnalogGlobalValues.KgM3;
    //             break;
    //
    //     }
    //
    //     return analogInput;
    // }
    //
    // private static DigitalInput GenerateRandomDigitalInput()
    // {
    //     
    //     int number = Random.Next(1, 3);
    //     DigitalInput digitalInput = new DigitalInput();
    //     switch (number)
    //     {
    //         case 1:
    //             digitalInput.Name = "Digital open-closed";
    //             digitalInput.Description = Global.DigitalGlobalValues.OpenClosedDescription;
    //             digitalInput.IOAddress = "adresa1";
    //             digitalInput.Value = Random.Next(2);
    //             digitalInput.ScanTime = DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ss");
    //             digitalInput.IsScanOn = true;
    //             break;
    //     
    //         case 2:
    //             digitalInput.Name = "Digital on-off";
    //             digitalInput.Description = Global.DigitalGlobalValues.OnOffDescription;
    //             digitalInput.IOAddress = "adresa1";
    //             digitalInput.Value = Random.Next(2);
    //             digitalInput.ScanTime = DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ss");
    //             digitalInput.IsScanOn = true;
    //             break;
    //             
    //     }
    //
    //     return digitalInput;
    // }
}
