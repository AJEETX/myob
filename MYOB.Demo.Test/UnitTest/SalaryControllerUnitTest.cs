using Microsoft.AspNetCore.Mvc;
using Moq;
using MYOB.Demo.Controllers;
using MYOB.Demo.Model;
using MYOB.Demo.Service;
using MYOB.Demo.Test.SampleData;
using System.Collections.Generic;
using Xunit;
namespace MYOB.Demo.Test.UnitTest
{
    public class SalaryControllerUnitTest
    {
        [Theory]
        [ClassData(typeof(TestDataGenerator))]
        public void SalaryController_Post_returns_employee_salary(IEnumerable<EmployeeDetails> employeeDetails,IEnumerable<EmployeePaySlip> employeePaySlips)
        {
            //given
            var moqSalaryService = new Mock<ISalaryService>();
            moqSalaryService.Setup(m => m.GetSalaryDetails(It.IsAny<IEnumerable<EmployeeDetails>>())).Returns(employeePaySlips);
            var sut = new SalaryController(moqSalaryService.Object);

            //when
            var actualResult = sut.Post(employeeDetails);

            //then
            Assert.IsAssignableFrom<IActionResult>(actualResult);
        }
    }
}
