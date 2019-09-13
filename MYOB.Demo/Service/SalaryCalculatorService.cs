using MYOB.Demo.Domain;
using MYOB.Demo.Model;
using System.Collections.Generic;
using System.Linq;

namespace MYOB.Demo.Service
{
    public interface ISalaryCalculatorService
    {
        IEnumerable<EmployeePaySlip> CalculateSalary(IEnumerable<EmployeeDetails> inputs, SalaryTaxTableHandler salaryRate);
    }
    class SalaryCalculatorService : ISalaryCalculatorService
    {
        public IEnumerable<EmployeePaySlip> CalculateSalary(IEnumerable<EmployeeDetails> inputs, SalaryTaxTableHandler salaryRate)
        {
            EmployeePaySlip employeePaySlip = default(EmployeePaySlip);

            if (inputs == null || inputs.Count() == 0 || salaryRate == null) //always good to validate / check the input
                yield return employeePaySlip;


            foreach (var input in inputs)
            {
                try
                {
                    employeePaySlip = salaryRate.CalculateSalary(input);
                }
                catch
                {
                    // Yell    Log    Catch  Throw     
                }
                yield return employeePaySlip;
            }
        }
    }
}
