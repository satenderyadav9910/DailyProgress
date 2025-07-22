using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
namespace Employee.Models
{
    [Index(nameof(Email), IsUnique = true)]
    public class Employees
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Position { get; set; }
        public decimal Salary { get; set; }

        public string? Email { get; set; }
        public DateTime DateOfJoining { get; set; }
    }
}