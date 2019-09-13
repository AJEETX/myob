using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace MYOB.Demo.Model
{
    public class EmployeeDetails
    {
        [Required]
        [JsonProperty("first name")]
        public string FirstName { get; set; }
        [Required]
        [JsonProperty("last name")]
        public string LastName { get; set; }
        public Person Person { get; set; }
        [Required]
        [JsonProperty("annual salary")]
        public decimal AnnualSalary { get; set; }
        [Required]
        [JsonProperty("super rate")]
        public decimal SuperRate { get; set; }
        [Required]
        [JsonProperty("payment start date")]
        public string PaymentStartDate { get; set; }
    }
}
