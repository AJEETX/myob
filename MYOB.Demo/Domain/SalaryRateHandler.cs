using System.Collections.Generic;

namespace MYOB.Demo.Domain
{
    public class SalaryRateHandler : SalaryRateHandlerBase
    {
        public override decimal LowerSalary { get; set; }
        public override decimal UpperSalary { get; set; }
        public override decimal Taxbase { get; set; }
        public override decimal TaxRate { get; set; }
    }
    public class SalaryRateHandlers
    {
        public IList<SalaryRateHandler> SalaryRateHandlerList { get; set; }
    }
}
