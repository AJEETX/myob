using MYOB.Demo.Model;
using Swashbuckle.AspNetCore.Examples;
using System.Collections.Generic;

namespace MYOB.Demo.Helper
{
    public class PayslipRequestExample : IExamplesProvider
    {
        public object GetExamples()
        {
            var sampleEmployees = new List<EmployeeDetails>
            {
                new EmployeeDetails { FirstName = "David", LastName = "Rudd", AnnualSalary = 60050, SuperRate = 9, PaymentStartDate = "01 March - 31 March" },
                new EmployeeDetails { FirstName = "Ryan", LastName = "Chen", AnnualSalary = 120000, SuperRate = 10, PaymentStartDate = "01 March - 31 March" }
            };

            return sampleEmployees;
        }
    }
}
