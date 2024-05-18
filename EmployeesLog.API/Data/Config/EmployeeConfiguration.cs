using EmployeesLog.API.Models.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace EmployeesLog.API.Data.Config
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                   .HasColumnType("VARCHAR")
                   .HasMaxLength(6)
                   .HasDefaultValueSql("NEXT VALUE FOR EmployeeIdSequence")
                   .ValueGeneratedOnAdd()
                   .IsRequired();

            
            
            builder.Property(x => x.Name).HasColumnType("NVARCHAR").HasMaxLength(128).IsRequired();
            builder.Property(x => x.Designation).HasColumnType("NVARCHAR").HasMaxLength(225);

            builder.Property(x => x.JoinDate).HasColumnType("date");

            builder.Property(x => x.Gender).HasColumnType("VARCHAR").HasMaxLength(1);

            builder.HasMany(x => x.Attendances)
                   .WithOne(x => x.Employee)
                   .HasForeignKey(x => x.EmployeeId);

            


        }
    }
}
