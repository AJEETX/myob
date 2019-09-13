using MYOB.Demo.Model;
using System;

namespace MYOB.Demo.Domain
{
    public abstract class SalaryTaxTableHandlerBase
    {
        const int totalMonthInYear = 12;
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

            if (employeeDetails == null || employeeDetails.AnnualSalary==0) return employeePaySlip;  //always good to validate / check the input
            try
            {
                if (employeeDetails.AnnualSalary > LowerSalaryLimit && (employeeDetails.AnnualSalary <= UpperSalaryLimit))
                {
                    var grossIncome = employeeDetails.AnnualSalary / totalMonthInYear;
                    var incometax = (Taxbase + (employeeDetails.AnnualSalary - LowerSalaryLimit) * (TaxRate / 100)) / totalMonthInYear;

                    employeePaySlip= new EmployeePaySlip
                    {
                        Name = employeeDetails.FirstName + " " + employeeDetails.LastName,
                        PayPeriod = employeeDetails.PaymentStartDate,
                        GrossIncome = Math.Round(grossIncome, 0),
                        Incometax = Math.Round(incometax, 0),
                        NetIncome = Math.Round(grossIncome - incometax, 0),
                        Super = Math.Round(grossIncome * (employeeDetails.SuperRate / 100))
                    };
                }
                else if (_nextHandler != null)
                    return _nextHandler.CalculateSalary(employeeDetails);
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
