using MYOB.Demo.Model;
using System;

namespace MYOB.Demo.Domain
{
    public abstract class SalaryTaxTableHandlerBase
    {
        const int totalMonthInYear = 12,hundred = 100,zero=0;
        protected SalaryTaxTableHandlerBase _nextHandler;
        public abstract decimal LowerSalaryLimit { get; set; }
        public abstract decimal UpperSalaryLimit { get; set; }
        public abstract decimal Taxbase { get; set; }
        public abstract decimal TaxRate { get; set; }
        public void SetNextSalaryRateHandler(SalaryTaxTableHandlerBase nextHandler)
        {
            _nextHandler = nextHandler;
        }
        public EmployeePaySlip CalculateSalary(EmployeeDetails  employeeDetails)
        {
            EmployeePaySlip employeePaySlip = default(EmployeePaySlip);

            if (employeeDetails == null || employeeDetails.AnnualSalary == zero) //always good to validate / check the input
            {
                return employeePaySlip;
            }
            try
            {
                if (employeeDetails.AnnualSalary > LowerSalaryLimit && (employeeDetails.AnnualSalary <= UpperSalaryLimit))
                {
                    var grossIncome = employeeDetails.AnnualSalary / totalMonthInYear;
                    var incomeTax = (Taxbase + (employeeDetails.AnnualSalary - LowerSalaryLimit) * (TaxRate / hundred)) / totalMonthInYear;

                    employeePaySlip= new EmployeePaySlip
                    {
                        Name = employeeDetails.FirstName + " " + employeeDetails.LastName,
                        PayPeriod = employeeDetails.PaymentStartDate,
                        GrossIncome = Math.Round(grossIncome, zero),
                        Incometax = Math.Round(incomeTax, zero),
                        NetIncome = Math.Round(grossIncome - incomeTax, zero),
                        Super = Math.Round(grossIncome * (employeeDetails.SuperRate / hundred))
                    };
                }
                else if (_nextHandler != null)
                {
                    return _nextHandler.CalculateSalary(employeeDetails);
                }
                else return null;
            }
            catch
            {
                // Yell    Log    Catch  Throw  
            }
            return employeePaySlip;
        }
    }

}
