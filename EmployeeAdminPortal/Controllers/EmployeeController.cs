using Microsoft.EntityFrameworkCore;
using EmployeeAdminPortal.Models;
using EmployeeAdminPortal.Data;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeAdminPortal.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;

        public EmployeeController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public ResponseModel<List<Employee>> GetAllEmployees()
        {
            var employees = dbContext.Employees.ToList();
            return new ResponseModel<List<Employee>>(true, "Execution is Successful", data: employees);

        }

        [HttpGet]
        [Route("{id:guid}")]
        // This route will match GET requests like /api/employee/{id}
        public ResponseModel<Employee> GetEmployeeById(Guid id)
        {
            var employee = dbContext.Employees.Find(id);

            if (employee == null)
            {
                return new ResponseModel<Employee>(false, $"Employee with ID {id} not found.");
            }

            return new ResponseModel<Employee>(true, "Execution is Successful",  data: employee);
        }

        [HttpPost]
        public ResponseModel<Employee> AddEmployee(AddEmployeeDto addEmployDto)
        {
            var employeeEntity = new Employee()
            {
                Name = addEmployDto.Name,
                Email = addEmployDto.Email,
                Phone = addEmployDto.Phone,
                Salary = addEmployDto.Salary
            };

            dbContext.Employees.Add(employeeEntity);
            dbContext.SaveChanges();
            return new ResponseModel<Employee>(true, "Execution is Successful", data: employeeEntity);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public ResponseModel<Employee> UpdateEmployee(Guid id, UpdateEmployeeDto updateEmployeeDto)
        {
            var employee = dbContext.Employees.Find(id);
            if (employee == null)
            {
                return new ResponseModel<Employee>(false, $"Employee with ID {id} not found.");
            }

            employee.Name = updateEmployeeDto.Name;
            employee.Email = updateEmployeeDto.Email;
            employee.Phone = updateEmployeeDto.Phone;
            employee.Salary = updateEmployeeDto.Salary;

            dbContext.SaveChanges();
            return new ResponseModel<Employee>(true, "Execution is Successful", data: employee);
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public ResponseModel<Employee> DeleteEmployee(Guid id)
        {
            var employee = dbContext.Employees.Find(id);
            if (employee == null)
            {
                return new ResponseModel<Employee>(false, $"Employee with ID {id} not found.");
            }

            dbContext.Employees.Remove(employee);
            dbContext.SaveChanges();
            return new ResponseModel<Employee>(true, "Execution is Successful", data: employee);
        }
    }
}