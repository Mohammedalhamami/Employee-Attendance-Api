using EmployeesLog.API.Data.Config;
using EmployeesLog.API.Models.Domain;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;
using System.Xml;

namespace EmployeesLog.API.Data
{
    public class EmployeesLogDbContext : DbContext
    {
        public EmployeesLogDbContext(DbContextOptions<EmployeesLogDbContext> options) : base(options)
        {
            
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeStatus> EmployeeStatuses { get; set; }
        public DbSet<Attendance> Attendances { get; set; }
        public DbSet<spReadEmployeeById> sp_ReadEmployeeById { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<spReadEmployeeById>().HasNoKey();
            modelBuilder.Entity<spReadEmployeeById>().Metadata.SetIsTableExcludedFromMigrations(true);
            modelBuilder.HasSequence<int>("EmployeeIdSequence")
                   .StartsAt(100000)
                   .IncrementsBy(1);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(EmployeeConfiguration).Assembly);

           
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="employeeId"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns>workHours int</returns>
        /// <exception cref="NotImplementedException"></exception>
        [DbFunction("fn_GetWorkHoursByEmployeeId", Schema ="dbo")]
        public int GetEmployeeWorkHours(int employeeId, DateOnly startDate, DateOnly endDate)
        {
            //implementation does not goes here. it is in attribute. EF core using function mapping.
            throw new NotImplementedException();
        }
    }
}
