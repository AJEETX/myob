using Bogus;
using MYOB.Demo.Model;
using System;
using System.Collections.Generic;

namespace MYOB.Demo.Test.SampleData
{
    class EmployeesData
    {
        public static IEnumerable<EmployeeDetails> CorrectEmployeeDetails(int numberOfEmplopyees)
        {
                var salaryForTheMonth = SalaryForTheMonth(new Random().Next(0,11));
                var employeeDetail = new Faker<EmployeeDetails>()
                    .RuleFor(p => p.FirstName, f => f.Person.FirstName)
                    .RuleFor(p => p.LastName, f => f.Person.LastName)
                    .RuleFor(p => p.AnnualSalary, f =>Math.Round(f.Random.Decimal(0,1000000),2))
                    .RuleFor(p => p.PaymentStartDate, f => salaryForTheMonth)
                    .RuleFor(p=>p.SuperRate,f=>Math.Round(f.Random.Decimal(0,50),2));
                return employeeDetail.Generate(numberOfEmplopyees);
        }

        static string SalaryForTheMonth(int month)
        {
            DateTime now =new DateTime(2017,7,1).AddMonths(month);
            return new DateTime(now.Year, now.Month, 1).ToString("dd MMMM") + " - " + new DateTime(now.Year, now.Month, 1).AddMonths(1).AddDays(-1).ToString("dd MMMM");
        }
        public static IEnumerable<EmployeePaySlip> EmployeePaySlips(int numberOfEmplopyees)
        {
                var payPeriod = SalaryForTheMonth(new Random().Next(0, 11));

                var employeeSalarySlip = new Faker<EmployeePaySlip>()
                    .RuleFor(p => p.Name, f => f.Name.FullName())
                    .RuleFor(p => p.PayPeriod, f => payPeriod)
                    .RuleFor(p => p.GrossIncome, f => f.Finance.Amount(500, 10000, 2))
                    .RuleFor(p => p.NetIncome, f => f.Finance.Amount(400, 9000, 2))
                    .RuleFor(p => p.Incometax, f => f.Finance.Amount(100, 400, 2))
                    .RuleFor(p => p.Super, f => f.Finance.Amount(10, 90, 2));

                return employeeSalarySlip.Generate(numberOfEmplopyees);

        }
    }
}
