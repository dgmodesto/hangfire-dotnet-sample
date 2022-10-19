namespace hangfire_dotnet_sample.Domain.Interfaces
{
    public interface IQueue
    {
        Task StartQueue();
    }
}
