using MYOB.Demo.Domain;
using System.Linq;

namespace MYOB.Demo.Service
{
    public interface ISalaryRatesService
    {
        SalaryTaxTableHandler SalaryRateHandler { get; }
    }
    class SalaryRatesService : ISalaryRatesService
    {
        ISalaryConfigService _salaryConfigService;
        static SalaryTaxTableHandler salaryRateHandler = null;
        public SalaryRatesService(ISalaryConfigService salaryConfigService)
        {
            _salaryConfigService = salaryConfigService;
        }
        public SalaryTaxTableHandler SalaryRateHandler
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
        SalaryTaxTableHandler GetSalaryHandler()
        {
            var salaryRateHandlers = _salaryConfigService.GetSection<SalaryTaxTableHandlers>(nameof(SalaryTaxTableHandlers));

            for (int i = 0; i < salaryRateHandlers.TaxTable.Count() - 1; i++)

                salaryRateHandlers.TaxTable.ElementAt(i).SetNextSalaryRateHandler(salaryRateHandlers.TaxTable.ElementAt(i + 1));

            return salaryRateHandlers.TaxTable.First();
        }
    }
}
