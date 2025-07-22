using Employee.Models;

namespace Employee.Services
{
    public interface IEmployeeServices
    {
        Task<IEnumerable<Employees>> GetAllEmployeesAsync();
        Task<Employees?> GetAllEmployeeByIdAsync(int id);

        Task<Employees?> RegisterEmployeeAsync(Employees employee);


        Task<Employees?> UpdateEmployeeAsync(int id, Employees employee);
        Task<bool> DeleteEmployeeAsync(int id);
    }
}
