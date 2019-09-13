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
        ///<summary>
        /// Gets all the employees salary detail of the given employees
        /// </summary>
        [HttpPost]
        [Produces("application/json")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(IEnumerable<EmployeePaySlip>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [SwaggerRequestExample(typeof(IEnumerable<EmployeeDetails>), typeof(EmployeeDetailsRequestExample))]
        [SwaggerResponseExample(StatusCodes.Status200OK, typeof(EmployeeSalaryExample))]
        public IActionResult Post(IEnumerable<EmployeeDetails> employeeDetails)
        {
            if ((!ModelState.IsValid || employeeDetails == null || employeeDetails.Count() == 0)) //always good to validate / check the input
            {
                return BadRequest(ModelState);
            }
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
