using Microsoft.AspNetCore.SignalR;
using ScadaSnusProject.Model;

namespace ScadaSnusProject.Hubs;

public class TagHub : Hub<ITagValueClient>{
    public TagHub() { }
    public async Task SendTagValue(TagValue tagValue)
        {
            await Clients.All.SendTagValue(tagValue);
        }   

    
}