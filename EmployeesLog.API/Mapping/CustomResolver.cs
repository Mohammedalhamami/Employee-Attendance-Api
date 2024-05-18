using AutoMapper;
using EmployeesLog.API.Models.Domain;
using EmployeesLog.API.Models.DTOs;

namespace EmployeesLog.API.Mapping
{
    public class CustomResolver : IValueResolver<CreateRequestEmployeeDto, Employee, DateOnly>
    {
        public DateOnly Resolve(CreateRequestEmployeeDto source, Employee destination, DateOnly destMember, ResolutionContext context)
        {
            return DateOnly.ParseExact(source.JoinDate, "yyyy-mm-dd");
        }
    }
}
