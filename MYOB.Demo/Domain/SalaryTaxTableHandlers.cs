using System.Collections.Generic;

namespace MYOB.Demo.Domain
{
    class SalaryTaxTableHandlers
    {
        public IList<SalaryTaxTableHandler> TaxTable { get; set; }
        public int Year { get; set; }
    }
}
