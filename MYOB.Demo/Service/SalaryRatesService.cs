using MYOB.Demo.Domain;
using System.Linq;

namespace MYOB.Demo.Service
{
    public interface ISalaryRatesService
    {
        SalaryRateHandler SalaryRateHandler { get; }
    }
    class SalaryRatesService : ISalaryRatesService
    {
        ISalaryConfigService _salaryConfigService;
        static SalaryRateHandler salaryRateHandler = null;
        public SalaryRatesService(ISalaryConfigService salaryConfigService)
        {
            _salaryConfigService = salaryConfigService;
        }
        public SalaryRateHandler SalaryRateHandler
        {
            get{
                try
                {
                    if(salaryRateHandler == null) GetSalaryHandler();
                }
                catch
                {
                    // Yell    Log    Catch  Throw  
                }
                return salaryRateHandler;
            }
        }
        void GetSalaryHandler()
        {
            var salaryRateHandlers = _salaryConfigService.GetSection<SalaryRateHandlers>(nameof(SalaryRateHandlers));

            for (int i = 0; i < salaryRateHandlers.SalaryRateHandlerList.Count() - 1; i++)

                salaryRateHandlers.SalaryRateHandlerList.ElementAt(i).SetNextSalaryRateHandler(salaryRateHandlers.SalaryRateHandlerList.ElementAt(i + 1));

            salaryRateHandler= salaryRateHandlers.SalaryRateHandlerList.First();
        }
    }
}
