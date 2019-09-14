using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace MYOB.Demo.Test.SampleData
{
    public class IntegrationTestDataGenerator : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            var numberOfEmplopyees = new Random().Next(1, 10);
            yield return new object[]
            {
                EmployeesData.CorrectEmployeeDetails(numberOfEmplopyees)
            };
        }
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
