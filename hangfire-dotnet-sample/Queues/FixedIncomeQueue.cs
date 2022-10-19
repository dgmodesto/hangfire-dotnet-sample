using hangfire_dotnet_sample.Domain.Interfaces;

namespace hangfire_dotnet_sample.Queues
{
    public class FixedIncomeQueue : IFixedIncomeQueue
    {
        private readonly IInvestmentProductIntegration _investmentProductIntegration;

        public FixedIncomeQueue(IInvestmentProductIntegration investmentProductIntegration)
        {
            _investmentProductIntegration = investmentProductIntegration;
        }

        public Task StartQueue()
        {
            var fixedIncomeResult = _investmentProductIntegration.GetFixedIncomeProducts();

            /*Aqui poderiamos pegar o retorno dessas informações na variável
             * fixedIncomeResult e salvar no nosso banco de dados de base fria*/
            Thread.Sleep(20000);

            return Task.CompletedTask;
        }
    }
}
