
using EmployeesLog.API.Data;
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
    }
}
