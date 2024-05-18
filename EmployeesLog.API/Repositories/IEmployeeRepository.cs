using EmployeesLog.API.Models.Domain;
using EmployeesLog.API.Models.DTOs;
using System.Runtime.InteropServices;

namespace EmployeesLog.API.Repositories
{
    public interface IEmployeeRepository
    {
       Task<Employee?> CreateAsync(Employee employee);
       spReadEmployeeById? ReadAsync(int id);
       Task<Employee?> UpdateByIdAsync(Employee employee, int id);
       Task<Employee?> DeleteByIdAsync(int id);
    }
}