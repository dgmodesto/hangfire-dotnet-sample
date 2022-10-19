using hangfire_dotnet_sample.Domain.Interfaces;

namespace hangfire_dotnet_sample.Queues
{
    public class EquityQueue : IEquityQueue
    {
        private readonly IInvestmentProductIntegration _investmentProductIntegration;

        public EquityQueue(IInvestmentProductIntegration investmentProductIntegration)
        {
            _investmentProductIntegration = investmentProductIntegration;
        }

        public Task StartQueue()
        {
            var equitiesResult = _investmentProductIntegration.GetEquitiesProducts();

            /*Aqui poderiamos pegar o retorno dessas informações na variável
             * equitiesResult  e salvar no nosso banco de dados de base fria*/
            Thread.Sleep(20000);
            return Task.CompletedTask;
        }
    }
}
