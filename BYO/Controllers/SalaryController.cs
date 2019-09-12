using System.Collections.Generic;
using System.Linq;
using BYO.Model;
using BYO.Service;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Examples;

namespace BYO.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalaryController : ControllerBase
    {
        ISalaryService _salaryService;
        public SalaryController(ISalaryService  salaryService)
        {
            _salaryService = salaryService;
        }

        /// <summary>
        /// testing
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        [HttpPost]
        [SwaggerRequestExample(typeof(IEnumerable<EmployeeDetails>), typeof(PayslipRequestExample))]
        public IActionResult Post(IEnumerable<EmployeeDetails> json)
        {
            if ((json == null || json.Count()==0)) return BadRequest();
            {
                try
                {
                    var salaryDetail = _salaryService.GetSalaryDetails(json);
                    return Ok(new { salaryDetail });
                }
                catch
                {
                    //Shot // Lof // throw
                }
            }
            return BadRequest();
        }
    }
}
