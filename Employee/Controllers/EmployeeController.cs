using Employee.Models;
using Employee.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Employee.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeServices _services;

        public EmployeeController(IEmployeeServices services)
        {
            _services = services;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employees>>> GetAllEmployees()
        {
            var employees = await _services.GetAllEmployeesAsync();
            return Ok(employees);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Employees>> GetEmployeeById(int id)
        {
            var employee = await _services.GetAllEmployeeByIdAsync(id);
            if (employee == null)
            {
                return NotFound();
            }
            return Ok(employee);
        }

        [HttpPost]
        public async Task<ActionResult<Employees>> RegisterEmployee(Employees employee)
        {
            var createdEmployee = await _services.RegisterEmployeeAsync(employee);
            if (createdEmployee == null)
            {
                return BadRequest("Employee Email/Id is already registered. Enter a unique Email.");
            }
            return CreatedAtAction(nameof(GetEmployeeById), new { id = createdEmployee.Id }, createdEmployee);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmployee(int id, Employees employee)
        {
            if (id != employee.Id)
            {
                return BadRequest("Employee ID mismatch.");
            }
            var updatedEmployee = await _services.UpdateEmployeeAsync(id, employee);
            if (updatedEmployee == null)
            {
                return NotFound("Employee not found or update failed.");
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var deleted = await _services.DeleteEmployeeAsync(id);
            if(!deleted)
            {
                return NotFound("Employee not found.");
            }
            return NoContent();
        }
    }
}