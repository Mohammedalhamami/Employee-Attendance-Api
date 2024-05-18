using EmployeesLog.API.Models.Domain;

namespace EmployeesLog.API.Repositories
{
   public interface IAttendanceRepository 
    {
       Task<Attendance?> CreateAsync(Attendance attendance);
       Task<Attendance?> ReadAsync(long id);
       Task<Attendance?> UpdateAsync(Attendance attendance, long id);
       Task<Attendance?> DeleteAsync(long id);

    }
}
