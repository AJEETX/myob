using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MYOB.Demo.Model
{
    public class Person
    {
        [Required]
        [JsonProperty("first name")]
        public string FirstName { get; set; }

        [Required]
        [JsonProperty("last name")]
        public string LastName { get; set; }
    }
}
