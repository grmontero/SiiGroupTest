using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using SiiTestBLL.Interfaces;
namespace SiiTestBackEndDotNetCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeesBll EmployeeService;

        public EmployeesController(IEmployeesBll employeeService)
        {
            this.EmployeeService = employeeService;
        }
        /// <summary>
        /// getEmployees
        /// </summary>
        /// <returns></returns>
        [HttpGet("getEmployees")]
        [EnableCors("AllowOrigin")]
        public async Task<IActionResult> getEmployees()
        {
            return Ok(await this.EmployeeService.getEmployees());
        }
        /// <summary>
        /// getEmployeesById
        /// </summary>
        /// <param name="idEmployee"></param>
        /// <returns></returns>
        [HttpGet("getEmployees/{idEmployee}")]
        [EnableCors("AllowOrigin")]
        public async Task<IActionResult> getEmployeesById(string idEmployee)
        {
            return Ok(await this.EmployeeService.getEmployeesById(idEmployee));
        }

    }
}