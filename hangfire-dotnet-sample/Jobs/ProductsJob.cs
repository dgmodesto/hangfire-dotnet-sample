using hangfire_dotnet_sample.Domain.Interfaces;

namespace hangfire_dotnet_sample.Jobs
{
    public class ProductsJob : IProductsJob
    {
        private readonly IFixedIncomeQueue _fixedIncomeQueue;   
        private readonly IEquityQueue _equityQueue;
        private readonly IFundQueue _fundQueue;

        public ProductsJob(
            IFixedIncomeQueue fixedIncomeQueue, 
            IEquityQueue equityQueue, 
            IFundQueue fundQueue)
        {
            _fixedIncomeQueue = fixedIncomeQueue;
            _equityQueue = equityQueue;
            _fundQueue = fundQueue;
        }

        public async Task StartJob()
        {
            //Executar Queue de Renda Fixa 
            await _fixedIncomeQueue.StartQueue();

            //Executar Queue de Renda Fixa 
            await _equityQueue.StartQueue();

            //Executar Queue de Renda Fixa 
            await _fundQueue.StartQueue();
        }
    }
}
