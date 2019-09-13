using System.Collections.Generic;
using System.Linq;
using MYOB.Demo.Helper;
using MYOB.Demo.Model;
using MYOB.Demo.Service;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Examples;
using Microsoft.AspNetCore.Http;

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

        /// <param name="employeeDetails"></param>
        /// <returns></returns>
        [HttpPost]
        [SwaggerRequestExample(typeof(IEnumerable<EmployeeDetails>), typeof(PayslipRequestExample))]
        public IActionResult Post(IEnumerable<EmployeeDetails> employeeDetails)
        {
            if ((!ModelState.IsValid || employeeDetails == null || employeeDetails.Count()==0)) return BadRequest();
            try
            {
                var salaryDetails = _salaryService.GetSalaryDetails(employeeDetails);
                var response = new { salaryDetails };
                return Ok(response);
            }
            catch
            {
                // Yell    Log    Catch  Throw  
            }
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }
}
