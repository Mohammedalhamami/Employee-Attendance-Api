using AutoMapper;
using EmployeesLog.API.Models.Domain;
using EmployeesLog.API.Models.DTOs;

namespace EmployeesLog.API.Mapping
{
    public class CustomResolver3 : IValueResolver<UpdateEmployeeRequestDto, Employee, DateOnly>
    {
        public DateOnly Resolve(UpdateEmployeeRequestDto source, Employee destination, DateOnly destMember, ResolutionContext context)
        {
            return DateOnly.ParseExact(source.JoinDate, "yyyy-mm-dd");
        }
    }
}
