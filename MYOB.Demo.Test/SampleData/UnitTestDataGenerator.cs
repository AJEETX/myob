using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace MYOB.Demo.Test.SampleData
{
    public class UnitTestDataGenerator : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[]
            {
                EmployeesData.CorrectEmployeeDetails,EmployeesData.EmployeePaySlips
            };
        }
        IEnumerator IEnumerable.GetEnumerator()=> GetEnumerator();
    }
}
