namespace MYOB.Demo.Domain
{
    class SalaryTaxTableHandler : SalaryTaxTableHandlerBase,ISalaryTaxTableHandler
    {
        public override decimal LowerSalaryLimit { get; set; }
        public override decimal UpperSalaryLimit { get; set; }
        public override decimal Taxbase { get; set; }
        public override decimal TaxRate { get; set; }
    }
}
