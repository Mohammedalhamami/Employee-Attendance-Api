using EmployeesLog.API.Data;
using EmployeesLog.API.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace EmployeesLog.API.Repositories
{
    public class SQLAttendanceRepository : IAttendanceRepository
    {
        private readonly EmployeesLogDbContext dbContext;

        public SQLAttendanceRepository(EmployeesLogDbContext employeesLogDbContext)
        {
            this.dbContext = employeesLogDbContext;
        }
        public async Task<Attendance?> CreateAsync(Attendance attendance)
        {
            await dbContext.Attendances.AddAsync(attendance);
            await dbContext.SaveChangesAsync();
            return attendance;
        }

        public async Task<Attendance?> ReadAsync(long id)
        {
          return await dbContext.Attendances.Include(x => x.Employee).FirstOrDefaultAsync(x => x.Id == id);
           
        }

        public async Task<Attendance?> UpdateAsync(Attendance attendance, long id)
        {
            var existingAttendance = await dbContext.Attendances.FirstOrDefaultAsync(x => x.Id == id);

            if(existingAttendance is not null)
            {
                existingAttendance.EmployeeId = attendance.EmployeeId;
                existingAttendance.PunchDateTime = attendance.PunchDateTime;
                existingAttendance.PunchStatus = attendance.PunchStatus;
                await dbContext.SaveChangesAsync();
            }
            return existingAttendance;

        }
    }
}
