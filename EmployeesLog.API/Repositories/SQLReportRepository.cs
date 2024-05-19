
using EmployeesLog.API.Data;
using EmployeesLog.API.Models.Domain;
using EmployeesLog.API.Models.DTOs;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.Xml;

namespace EmployeesLog.API.Repositories
{
    public class SQLReportRepository : IReportRepository
    {
        private readonly EmployeesLogDbContext dbContext;

        public SQLReportRepository(EmployeesLogDbContext employeesLogDbContext)
        {
            this.dbContext = employeesLogDbContext;
        }
        public int? GetEmployeeWorkHours(int employeeId, DateOnly startDate, DateOnly endDate)
        {
            //var Id = new SqlParameter("@employeeId", employeeId);
            //var start = new SqlParameter("@startDate", startDate);
            //var end = new SqlParameter("@endDate", endDate);

            int? result =  dbContext.Database.SqlQuery<int?>($"SELECT dbo.fn_GetWorkHoursByEmployeeId({employeeId}, {startDate}, {endDate})").AsEnumerable()
            .FirstOrDefault();
            return result;
        }

        public bool? isEmployeeAbsent(int employeeId, DateOnly checkingDate)
        {
            //var employeeAttandingDateTime = dbContext
            //          .Attendances?
            //          .Where(x => x.EmployeeId == employeeId)?
            //          .Where(x => x.PunchStatus == 1)?
            //          .FirstOrDefault(x => DateOnly.FromDateTime(x.PunchDateTime).Equals(checkingDate))?
            //          .PunchDateTime;

            var employeeAttandingDateTime = from x in dbContext.Attendances
                                            where x.EmployeeId == employeeId
                                            where x.PunchStatus == 1
                                            select x.PunchDateTime;

            if (employeeAttandingDateTime == null)
            {
                return null;
            }
            if(employeeAttandingDateTime.Any(x => x.Hour > 9))
            {
                return true;
            }
            return false;
        }
    }
}
