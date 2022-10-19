using hangfire_dotnet_sample.Domain.Interfaces;

namespace hangfire_dotnet_sample.Integration
{
    public class InvestmentProductIntegration : IInvestmentProductIntegration
    {
        public Task<string[]> GetEquitiesProducts()
        {
            return Task.FromResult(new string[]
            {
                "Produto Renda Variável 1", 
                "Produto Renda Variável 2", 
                "Produto Renda Variável 3", 
                "Produto Renda Variável 4", 
                "Produto Renda Variável 5", 
            });
        }

        public Task<string[]> GetFixedIncomeProducts()
        {
            return Task.FromResult(new string[]
            {
                "Produto Renda Fixa 1",
                "Produto Renda Fixa 2",
                "Produto Renda Fixa 3",
                "Produto Renda Fixa 4",
                "Produto Renda Fixa 5",
            });
        }

        public Task<string[]> GetFundsProducts()
        {
            return Task.FromResult(new string[]
        {
                "Produto Fundos 1",
                "Produto Fundos 2",
                "Produto Fundos 3",
                "Produto Fundos 4",
                "Produto Fundos 5",
        });
        }
    }
}
