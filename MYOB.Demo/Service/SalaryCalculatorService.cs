using MYOB.Demo.Domain;
using MYOB.Demo.Model;
using System.Collections.Generic;
using System.Linq;

namespace MYOB.Demo.Service
{
    public interface ISalaryCalculatorService
    {
        IEnumerable<EmployeePaySlip> CalculateSalary(IEnumerable<EmployeeDetails> inputs, ISalaryTaxTableHandler salaryRate);
    }
    // the implementation shall need not be public
    class SalaryCalculatorService : ISalaryCalculatorService
    {
        public virtual IEnumerable<EmployeePaySlip> CalculateSalary(IEnumerable<EmployeeDetails> employeeDetails, ISalaryTaxTableHandler salaryRate)
        {
            IEnumerable<EmployeePaySlip> employeePaySlips = default(IEnumerable<EmployeePaySlip>);

            if (employeeDetails == null || employeeDetails.Count() == 0 || salaryRate == null) //always good to validate / check the input
            {
                return employeePaySlips;
            }

            try
            {
                employeePaySlips = employeeDetails.Select(empDetail => salaryRate.CalculateSalary(empDetail));
            }
            catch
            {
                // Yell    Log    Catch  Throw  
            }

            return employeePaySlips;
        }
    }
}
