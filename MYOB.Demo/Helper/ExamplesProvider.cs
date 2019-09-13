using MYOB.Demo.Model;
using Swashbuckle.AspNetCore.Examples;
using System.Collections.Generic;

namespace MYOB.Demo.Helper
{
    public class EmployeeDetailsRequestExample : IExamplesProvider
    {
        public object GetExamples()
        {
            return new List<EmployeeDetails>
            {
                new EmployeeDetails { FirstName = "David", LastName = "Rudd", AnnualSalary = 60050, SuperRate = 9, PaymentStartDate = "01 March - 31 March" },
                new EmployeeDetails { FirstName = "Ryan", LastName = "Chen", AnnualSalary = 120000, SuperRate = 10, PaymentStartDate = "01 March - 31 March" }
            };
        }
    }

    public class EmployeeSalaryExample : IExamplesProvider
    {
        public object GetExamples()
        {
            return new List<EmployeePaySlip>
            {
                new EmployeePaySlip { Name = "David Rudd", PayPeriod="01 March - 31 March", GrossIncome=5004, Incometax=922,NetIncome=4082, Super=450 },
                new EmployeePaySlip { Name = "Ryan Chen", PayPeriod="01 March - 31 March", GrossIncome=10000, Incometax=2669,NetIncome=7331, Super=1000  }
            };
        }
    }
}
