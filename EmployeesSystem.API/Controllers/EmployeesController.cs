using EmployeeSystem.BL.Dtos;
using EmployeeSystem.BL.Managers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeesSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeesManager _employeeManager;

        public EmployeesController(IEmployeesManager employeeManager)
        {
            _employeeManager = employeeManager ?? throw new ArgumentNullException(nameof(employeeManager)); 
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeesReadDto>>> GetAllEmployees()
        {
            try
            {
                var employees = await _employeeManager.GetAllEmployees();
                return Ok(employees);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeesReadDto>> GetEmployeeById(int id)
        {
            try
            {
                var employee = await _employeeManager.GetById(id);

                if (employee == null)
                    return NotFound();

                return Ok(employee);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<ActionResult<string>> Add([FromBody] EmployeesAddDto employeeDto)
        {
            try
            {
                var result = await _employeeManager.Add(employeeDto);

                if (result !=null)
                    return Ok("Employee is Added Successfully ");
                else
                    return BadRequest("Failed to add employee");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update( [FromBody] EmployeesUpdateDto employeeDto)
        {
            try
            {

                var result = await _employeeManager.Update(employeeDto);

                if (result!=null )
                    return Ok("Employee is Updated Successfully ");
                else
                    return BadRequest("Failed to update employee");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<string>> Delete(int id) /*Soft Delete*/
        {
            try
            {

                var result = await _employeeManager.Delete(id);

                if (result !=null)
                    return Ok("Employee is De Activated Successfully ");
                else
                    return NotFound("Failed to DeActivate Employee");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error: {ex.Message}");
            }
        }
    }
}
