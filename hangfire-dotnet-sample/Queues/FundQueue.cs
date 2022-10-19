using hangfire_dotnet_sample.Domain.Interfaces;

namespace hangfire_dotnet_sample.Queues
{
    public class FundQueue : IFundQueue
    {
        private readonly IInvestmentProductIntegration _investmentProductIntegration;

        public FundQueue(IInvestmentProductIntegration investmentProductIntegration)
        {
            _investmentProductIntegration = investmentProductIntegration;
        }

        public Task StartQueue()
        {
            var fundsResult = _investmentProductIntegration.GetFundsProducts();

            /*Aqui poderiamos pegar o retorno dessas informações na variável
             * fundsResult  e salvar no nosso banco de dados de base fria*/
            Thread.Sleep(20000);

            return Task.CompletedTask;
        }
    }
}
