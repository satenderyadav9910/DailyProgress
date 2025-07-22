using MySqlApiDemo.Models;

namespace MySqlApiDemo.Services
{
    public interface IVehicleService
    {
        Task<IEnumerable<Vehicle>> GetAllVehiclesAsync();
        Task<Vehicle?> GetVehicleByIdAsync(int id);
        Task<Vehicle?> AddVehicleAsync(Vehicle vehicle);
        Task<Vehicle?> UpdateVehicleAsync(int id, Vehicle vehicle);
        Task<bool> DeleteVehicleAsync(int id);
    }
}
