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

        public virtual IEnumerable<EmployeePaySlip> GetSalaryDetails(IEnumerable<EmployeeDetails> employeeDetails)
        {
            var salaryData = default(IEnumerable<EmployeePaySlip>);

            if (employeeDetails == null || employeeDetails.Count() == 0) //always good to validate / check the input
            {
                return salaryData; 
            }
            try
            {
                var salaryHandler = _salaryRatesService.SalaryTaxTableHandler;

                if (salaryHandler == null)
                {
                    return salaryData;
                }

                salaryData = _salaryCalculatorService.CalculateSalary(employeeDetails, salaryHandler);
            }
            catch
            {
                // Yell    Log    Catch  Throw  
            }
            return salaryData;
        }
    }
}
