namespace ScadaSnusProject.Hubs;

public interface ITagValueClient
{
    Task SendTagValue(object data);
}