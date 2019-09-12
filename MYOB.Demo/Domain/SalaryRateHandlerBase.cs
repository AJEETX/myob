using MYOB.Demo.Model;
using System;

namespace MYOB.Demo.Domain
{
    public abstract class SalaryRateHandlerBase
    {
        const int totalMonthInYear = 12;
        protected SalaryRateHandlerBase _nextHandler;
        public abstract decimal LowerSalary { get; set; }
        public abstract decimal UpperSalary { get; set; }
        public abstract decimal Taxbase { get; set; }
        public abstract decimal TaxRate { get; set; }
        public void SetNextHandler(SalaryRateHandlerBase nextHandler)
        {
            _nextHandler = nextHandler;
        }
        public EmployeePaySlip CalculateSalary(EmployeeDetails input)
        {
            if (input == null || input.AnnualSalary==0) return null;

            if (input.AnnualSalary > LowerSalary && (input.AnnualSalary <= UpperSalary ))
            {
                var grossIncome = input.AnnualSalary / totalMonthInYear;
                var incometax = (Taxbase + (input.AnnualSalary - LowerSalary) * (TaxRate / 100))/ totalMonthInYear;

                return new EmployeePaySlip {
                    Name =input.FirstName+ " "+input.LastName,
                    PayPeriod =input.PaymentStartDate,
                    GrossIncome =Math.Round(grossIncome,0),
                    Incometax=Math.Round(incometax,0),
                    NetIncome =Math.Round(grossIncome-incometax,0),
                    Super =Math.Round( grossIncome*(input.SuperRate/100))
                };
            }
            else if(_nextHandler!=null) return _nextHandler.CalculateSalary(input);
            else return  null; 
        }
    }

}
