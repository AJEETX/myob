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
            yield return new object[]
            {
                EmployeesData.CorrectEmployeeDetails
            };
        }
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
