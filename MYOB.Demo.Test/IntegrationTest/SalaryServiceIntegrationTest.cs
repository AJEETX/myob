using Microsoft.Extensions.Configuration;
using MYOB.Demo.Model;
using MYOB.Demo.Service;
using MYOB.Demo.Test.SampleData;
using System.Collections.Generic;
using System.IO;
using Xunit;
namespace MYOB.Demo.Test.IntegrationTest
{
    public class SalaryServiceIntegrationTest
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
            var sut = new SalaryService(salaryRatesService, salaryCalculatorService);


            //when
            var actualResult = sut.GetSalaryDetails(employeeDetails);

            ////then
            Assert.IsAssignableFrom<IEnumerable<EmployeePaySlip>>(actualResult);
        }
    }
}
