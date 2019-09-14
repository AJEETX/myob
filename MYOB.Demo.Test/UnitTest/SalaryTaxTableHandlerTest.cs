using MYOB.Demo.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace MYOB.Demo.Test.UnitTest
{
    public class SalaryTaxTableHandlerTest
    {
        [Fact]
        public void SalaryTaxTableHandler_returns_salary_details()
        {
            //given
            var sut = new SalaryTaxTableHandler();

            sut.LowerSalaryLimit = 1000;
            sut.UpperSalaryLimit = 10000;
            sut.TaxRate = 10;
            sut.Taxbase = 100;

            //when
            var salary = sut.CalculateSalary(new Model.EmployeeDetails { AnnualSalary=5000 });

        }
    }
}
