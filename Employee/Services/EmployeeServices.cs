using Employee.Models;
using Employee.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Employee.Data;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Employee.Services
{
    public class EmployeeServices : IEmployeeServices
    {
        private readonly MyDbContext _context;

        public EmployeeServices(MyDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Employees>> GetAllEmployeesAsync()
        {
            return await _context.Employees.ToListAsync();
        }

        public async Task<Employees?> GetAllEmployeeByIdAsync(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            return employee;
        }

        public async Task<Employees?> RegisterEmployeeAsync(Employees employee)
        {
            try
            {
                var checkEmail = await _context.Employees.FirstOrDefaultAsync(e => e.Email == employee.Email);
                var checkId = await _context.Employees.FirstOrDefaultAsync(e => e.Id == employee.Id);
                if (checkId != null)
                {
                    throw new DbUpdateException("Employee ID is already registered. Enter a unique ID.");
                }
                else if (checkEmail != null)
                {
                    throw new DbUpdateException("Employee Email is already registered. Enter a unique Email.");
                }



                if (employee == null)
                {
                    throw new NullReferenceException("Employee cannot be null");
                }
                _context.Employees.Add(employee);
                await _context.SaveChangesAsync();
                return employee;
            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                // Console.WriteLine("This Email is Already registered. Enter unique Email");
                return null;
            }

            catch (NullReferenceException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return null;
            }
        }

        public async Task<Employees?> UpdateEmployeeAsync(int id, Employees employee)
        {
            if (id != employee.Id)
            {
                return null; // or throw an exception
            }
            var existingEmployee = await _context.Employees.FindAsync(id);
            if (existingEmployee == null)
            {
                return null;
            }

            existingEmployee.Name = employee.Name;
            existingEmployee.Position = employee.Position;
            existingEmployee.Salary = employee.Salary;
            existingEmployee.Email = employee.Email;
            existingEmployee.DateOfJoining = employee.DateOfJoining;

            await _context.SaveChangesAsync();
            return existingEmployee;
        }

        public async Task<bool> DeleteEmployeeAsync(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee == null)
            {
                return false;
            }

            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}