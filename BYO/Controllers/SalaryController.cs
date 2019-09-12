using System.Collections.Generic;
using System.Linq;
using MYOB.Demo.Helper;
using MYOB.Demo.Model;
using MYOB.Demo.Service;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Examples;

namespace MYOB.Demo.Controllers
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
            if ((!ModelState.IsValid || json == null || json.Count()==0)) return BadRequest();
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
