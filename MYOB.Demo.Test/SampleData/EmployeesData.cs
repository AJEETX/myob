using Bogus;
using MYOB.Demo.Model;
using System;
using System.Collections.Generic;

namespace MYOB.Demo.Test.SampleData
{
    class EmployeesData
    {
        public static IEnumerable<EmployeeDetails> CorrectEmployeeDetails
        {
            get
            {
                var salaryForTheMonth = SalaryForTheMonth(new Random().Next(0,11));
                var employeeDetail = new Faker<EmployeeDetails>()
                    .RuleFor(p => p.FirstName, f => f.Person.FirstName)
                    .RuleFor(p => p.LastName, f => f.Person.LastName)
                    .RuleFor(p => p.AnnualSalary, f =>Math.Round(f.Random.Decimal(0,1000000),2))
                    .RuleFor(p => p.PaymentStartDate, f => salaryForTheMonth)
                    .RuleFor(p=>p.SuperRate,f=>Math.Round(f.Random.Decimal(0,50),2));
                return employeeDetail.Generate(new Random().Next(1,10));
            }
        }

        static string SalaryForTheMonth(int month)
        {
            DateTime now =new DateTime(2017,7,1).AddMonths(month);
            return new DateTime(now.Year, now.Month, 1).ToString("dd MMMM") + " - " + new DateTime(now.Year, now.Month, 1).AddMonths(1).AddDays(-1).ToString("dd MMMM");
        }
        public static IEnumerable<EmployeePaySlip> EmployeePaySlips
        {
            get
            {
                return new List<EmployeePaySlip> { };
            }
        }
    }
}
