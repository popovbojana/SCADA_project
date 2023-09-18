using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;
using ScadaSnusProject.Model;

namespace ScadaSnusProject.Hubs;

public class AlarmHub : Hub
{
    public async Task SendAlarmActivation(AlarmActivation alarmActivation)
    {
        await Clients.All.SendAsync("ReceiveAlarmActivation", alarmActivation);
    }
}