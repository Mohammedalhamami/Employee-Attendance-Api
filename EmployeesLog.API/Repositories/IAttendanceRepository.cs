using EmployeesLog.API.Models.Domain;
using EmployeesLog.API.Models.DTOs;

namespace EmployeesLog.API.Repositories
{
   public interface IAttendanceRepository 
    {
       Task<Attendance?> CreateAsync(Attendance attendance);
       Task<ReadAttendanceDto?> ReadAsync(long id);
       Task<Attendance?> UpdateAsync(Attendance attendance, long id);
       Task<Attendance?> DeleteAsync(long id);

    }
}
