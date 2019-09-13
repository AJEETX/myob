using System.Collections.Generic;

namespace MYOB.Demo.Domain
{
    public class SalaryRateHandler : SalaryRateHandlerBase
    {
        public override decimal LowerSalaryLimit { get; set; }
        public override decimal UpperSalaryLimit { get; set; }
        public override decimal Taxbase { get; set; }
        public override decimal TaxRate { get; set; }
    }
    class SalaryRateHandlers
    {
        public IList<SalaryRateHandler> SalaryRateHandlerList { get; set; }
    }
}
