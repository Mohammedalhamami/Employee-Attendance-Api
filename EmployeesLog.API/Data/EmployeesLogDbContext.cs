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

    }
}
