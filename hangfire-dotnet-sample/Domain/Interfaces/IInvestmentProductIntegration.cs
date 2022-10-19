namespace hangfire_dotnet_sample.Domain.Interfaces
{
    public interface IInvestmentProductIntegration
    {
        public Task<string[]> GetFixedIncomeProducts();
        public Task<string[]> GetEquitiesProducts();
        public Task<string[]> GetFundsProducts();
    }
}
