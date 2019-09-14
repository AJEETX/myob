using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MYOB.Demo.Controllers;
using MYOB.Demo.Model;
using MYOB.Demo.Service;
using MYOB.Demo.Test.SampleData;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xunit;

namespace MYOB.Demo.Test.IntegrationTest
{
    public class SalaryControllerIntegrationTest
    {
        [Theory]
        [ClassData(typeof(IntegrationTestDataGenerator))]
        public void GetSalaryDetails_with_employee_details_input_returns_salary(IEnumerable<EmployeeDetails> employeeDetails)
        {
            //given
            var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

            var salaryConfigService = new SalaryConfigService(configuration);
            var salaryRatesService = new SalaryRatesService(salaryConfigService);
            var salaryCalculatorService = new SalaryCalculatorService();
            var salaryService= new SalaryService(salaryRatesService, salaryCalculatorService);
            var sut = new SalaryController(salaryService);

            //when
            var actualResult = sut.Post(employeeDetails);

            //then
            Assert.IsAssignableFrom<IActionResult>(actualResult);
        }
    }
}
