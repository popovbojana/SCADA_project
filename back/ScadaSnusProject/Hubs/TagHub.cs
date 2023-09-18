using Microsoft.AspNetCore.SignalR;
using ScadaSnusProject.Model;

namespace ScadaSnusProject.Hubs;

public class TagHub : Hub
{
    public async Task SendTagValue(TagValue tagValue)
    {
        await Clients.All.SendAsync("ReceiveTagValue", tagValue);
    }   
}