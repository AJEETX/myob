using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace MYOB.Demo.Test.SampleData
{
    public class TestDataGenerator : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            var numberOfEmplopyees = new Random().Next(1, 10);
            yield return new object[]
            {
                EmployeesData.CorrectEmployeeDetails(numberOfEmplopyees),EmployeesData.EmployeePaySlips(numberOfEmplopyees)
            };
        }
        IEnumerator IEnumerable.GetEnumerator()=> GetEnumerator();
    }
}
