using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace ScadaSnusProject.Hubs;

public class AlarmHub : Hub
{
    public async Task SendAlarmActivation(string data)
    {
        await Clients.All.SendAsync("ReceiveRealTimeData", data);
    }
}