using Moq;
using MYOB.Demo.Domain;
using MYOB.Demo.Model;
using MYOB.Demo.Service;
using MYOB.Demo.Test.SampleData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace MYOB.Demo.Test.Test
{
    public class SalaryServiceTest
    {
        [Theory]
        [ClassData(typeof(TestDataGenerator))]
        public void GetSalaryDetails_given_correct_employee_details_returns_salary(IEnumerable<EmployeeDetails> employeeDetails, IEnumerable<EmployeePaySlip> EmployeePaySlips)
        {
            //given
            var moqSalaryRatesService = new Mock<ISalaryRatesService>();
            moqSalaryRatesService.Setup(m => m.SalaryRateHandler).Returns(new SalaryRateHandler());

            var moqSalaryCalculatorService = new Mock<ISalaryCalculatorService>();
            moqSalaryCalculatorService.Setup(m => m.CalculateSalary(It.IsAny<IEnumerable<EmployeeDetails>>(), It.IsAny<SalaryRateHandler>())).Returns(EmployeePaySlips);

            var sut = new SalaryService(moqSalaryRatesService.Object, moqSalaryCalculatorService.Object);


            //when
            var actualResult = sut.GetSalaryDetails(employeeDetails);

            //then
            Assert.IsAssignableFrom<IEnumerable<EmployeePaySlip>>(actualResult);
            moqSalaryRatesService.Verify(v => v.SalaryRateHandler, Times.Exactly(employeeDetails.Count()));
            moqSalaryCalculatorService.Verify(v => v.CalculateSalary(It.IsAny<IEnumerable<EmployeeDetails>>(), It.IsAny<SalaryRateHandler>()), Times.Once);
        }
    }
}
