using Newtonsoft.Json;

namespace MYOB.Demo.Model
{
    public class EmployeePaySlip
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("pay period")]
        public string PayPeriod{ get; set; }
        [JsonProperty("gross income")]
        public decimal GrossIncome { get; set; }
        [JsonProperty("income tax")]
        public decimal Incometax { get; set; }
        [JsonProperty("net income")]
        public decimal NetIncome { get; set; }
        [JsonProperty("super")]
        public decimal Super { get; set; }
    }
}
