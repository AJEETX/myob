using MYOB.Demo.Domain;
using MYOB.Demo.Model;
using MYOB.Demo.Test.SampleData;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace MYOB.Demo.Test.UnitTest
{
    public class SalaryTaxTableHandlerTest
    {
        [Theory]
        [ClassData(typeof(UnitTestDataGenerator))]
        public void SalaryTaxTableHandler_returns_salary_details(IEnumerable<EmployeeDetails> employeeDetails, IEnumerable<EmployeePaySlip> employeePaySlips)
        {
            //given
            var sut = new SalaryTaxTableHandler();
            
            sut.LowerSalaryLimit = 100000;
            sut.UpperSalaryLimit = 2000000;
            sut.TaxRate = 10;
            sut.Taxbase = 100;

            //when
            var salary = sut.CalculateSalary(employeeDetails.First());

            //then
            Assert.IsType<EmployeePaySlip>(salary);
        }
    }
}
