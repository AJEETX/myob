using Moq;
using MYOB.Demo.Domain;
using MYOB.Demo.Model;
using MYOB.Demo.Service;
using MYOB.Demo.Test.SampleData;
using System.Collections.Generic;
using Xunit;

namespace MYOB.Demo.Test.UnitTest
{
    public class SalaryServiceUnitTest
    {
        [Theory]
        [ClassData(typeof(UnitTestDataGenerator))]
        public void GetSalaryDetails_with_employee_details_input_returns_salary(IEnumerable<EmployeeDetails> employeeDetails, IEnumerable<EmployeePaySlip> EmployeePaySlips)
        {
            //given
            var moqSalaryRatesService = new Mock<ISalaryRatesService>();
            moqSalaryRatesService.Setup(m => m.SalaryTaxTableHandler).Returns(new SalaryTaxTableHandler());

            var moqSalaryCalculatorService = new Mock<ISalaryCalculatorService>();
            moqSalaryCalculatorService.Setup(m => m.CalculateSalary(It.IsAny<IEnumerable<EmployeeDetails>>(), It.IsAny<SalaryTaxTableHandler>())).Returns(EmployeePaySlips);

            var sut = new SalaryService(moqSalaryRatesService.Object, moqSalaryCalculatorService.Object);

            //when
            var actualResult = sut.GetSalaryDetails(employeeDetails);

            //then
            Assert.IsAssignableFrom<IEnumerable<EmployeePaySlip>>(actualResult);
            moqSalaryRatesService.Verify(v => v.SalaryTaxTableHandler, Times.Once);
            moqSalaryCalculatorService.Verify(v => v.CalculateSalary(It.IsAny<IEnumerable<EmployeeDetails>>(), It.IsAny<SalaryTaxTableHandler>()), Times.Once);
        }
    }
}
