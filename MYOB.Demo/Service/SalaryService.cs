using MYOB.Demo.Model;
using System.Collections.Generic;
using System.Linq;

namespace MYOB.Demo.Service
{
    public interface ISalaryService
    {
        IEnumerable<EmployeePaySlip> GetSalaryDetails(IEnumerable<EmployeeDetails> inputs);
    }
    class SalaryService : ISalaryService
    {
        ISalaryRatesService _salaryRatesService;
        ISalaryCalculatorService _salaryCalculatorService;
        public SalaryService(ISalaryRatesService salaryRatesService, ISalaryCalculatorService salaryCalculatorService)
        {
            _salaryRatesService = salaryRatesService;
            _salaryCalculatorService = salaryCalculatorService;
        }

        public IEnumerable<EmployeePaySlip> GetSalaryDetails(IEnumerable<EmployeeDetails> inputs)
        {
            var salaryData = default(IEnumerable<EmployeePaySlip>);

            if (inputs == null || inputs.Count()==0) return salaryData; //always good to validate / check the input
            try
            {
                if (_salaryRatesService.SalaryRateHandler == null)
                    return salaryData;

                salaryData = _salaryCalculatorService.CalculateSalary(inputs, _salaryRatesService.SalaryRateHandler);
            }
            catch
            {
                // Yell    Log    Catch  Throw  
            }
            return salaryData;
        }
    }
}
