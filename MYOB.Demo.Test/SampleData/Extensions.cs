using System;
using System.Collections.Generic;
using System.Text;

namespace MYOB.Demo.Test.SampleData
{
    public static class Extensions
    {
        public static string SalaryDateForTheMonth(this int month)
        {
            DateTime now = new DateTime(2017, 7, 1).AddMonths(month);
            return new DateTime(now.Year, now.Month, 1).ToString("dd MMMM") + " - " + new DateTime(now.Year, now.Month, 1).AddMonths(1).AddDays(-1).ToString("dd MMMM");
        }
    }
}
