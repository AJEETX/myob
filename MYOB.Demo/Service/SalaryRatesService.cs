using MYOB.Demo.Domain;
using System;
using System.Linq;

namespace MYOB.Demo.Service
{
    public interface ISalaryRatesService
    {
        ISalaryTaxTableHandler SalaryTaxTableHandler { get; }
    }
    // the implementation shall need not be public
    class SalaryRatesService : ISalaryRatesService
    {
        ISalaryConfigService _salaryConfigService;
        static ISalaryTaxTableHandler salaryRateHandler = null;
        public SalaryRatesService(ISalaryConfigService salaryConfigService)
        {
            _salaryConfigService = salaryConfigService;
        }
        public virtual ISalaryTaxTableHandler SalaryTaxTableHandler
        {
            get{
                try
                {
                    if (salaryRateHandler == null)
                    {
                        salaryRateHandler= GetSalaryHandler();
                    }
                }
                catch
                {
                    // Yell    Log    Catch  Throw  
                }
                return salaryRateHandler;
            }
        }
        ISalaryTaxTableHandler GetSalaryHandler()
        {
            var salaryRateHandlers = _salaryConfigService.GetSection<SalaryTaxTableHandlers>(nameof(SalaryTaxTableHandlers));

            for (int i = 0; i < salaryRateHandlers.TaxTable.Count() - 1; i++)

            {
                salaryRateHandlers.TaxTable.ElementAt(i).SetNextSalaryRateHandler(salaryRateHandlers.TaxTable.ElementAt(i + 1));
            }

            return salaryRateHandlers.TaxTable.First();
        }
    }
}
