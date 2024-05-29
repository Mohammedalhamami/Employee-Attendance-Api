using EmployeesLog.API.Data;
using EmployeesLog.API.Models.Domain;
using EmployeesLog.API.Models.DTOs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System.Threading.Tasks.Dataflow;

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
        public async Task<ReadAttendanceDto?> ReadAsync(long id)
        {
            return await dbContext.Attendances.Include(x => x.Employee).Where(x => x.Id == id).Select(x => new ReadAttendanceDto
            {
                employeeName = x.Employee.Name,
                JoinDate = x.Employee.JoinDate,
                Gender = x.Employee.Gender == 'M' ? "Male" : "Female",
                Designation = x.Employee.Designation,
                PunchDateTime = x.PunchDateTime,
                PunchStatus = x.PunchStatus == 1 ? "Check In" : "Check Out"
             
            }).SingleOrDefaultAsync();
           
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
        public async Task<Attendance?> DeleteAsync(long id)
        {
            var existingAttendance  = await dbContext.Attendances.FirstOrDefaultAsync(x => x.Id == id);

            if(existingAttendance is not null)
            {
                dbContext.Attendances.Remove(existingAttendance);
                await dbContext.SaveChangesAsync();
            }
            
            return existingAttendance;
        }
    }
}
