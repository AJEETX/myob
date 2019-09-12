using MYOB.Demo.Domain;
using MYOB.Demo.Model;
using System.Collections.Generic;
using System.Linq;

namespace MYOB.Demo.Service
{
    public interface ISalaryCalculatorService
    {
        IEnumerable<EmployeePaySlip> CalculateSalary(IEnumerable<EmployeeDetails> inputs, SalaryRateHandler salaryRate);
    }
    public class SalaryCalculatorService : ISalaryCalculatorService
    {
        public IEnumerable<EmployeePaySlip> CalculateSalary(IEnumerable<EmployeeDetails> inputs, SalaryRateHandler salaryRate)
        {
            EmployeePaySlip output= null;

            if (inputs == null || inputs.Count() == 0 || salaryRate == null) yield return null;

            foreach (var input in inputs)
            {
                try
                {
                    output =salaryRate.CalculateSalary(input);
                }
                catch
                {
                    // Yell    Log    Catch  Throw     
                }
                yield return output;
            }
        }
    }
}
