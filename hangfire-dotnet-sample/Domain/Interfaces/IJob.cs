namespace hangfire_dotnet_sample.Domain.Interfaces
{
    public interface IJob
    {
        public Task StartJob();
    }
}
