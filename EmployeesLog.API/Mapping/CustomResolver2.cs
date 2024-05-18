using AutoMapper;
using EmployeesLog.API.Models.Domain;
using EmployeesLog.API.Models.DTOs;

public class CustomResolver2 : IValueResolver<Employee, EmployeeDto, string>
{
    public string Resolve(Employee source, EmployeeDto destination, string destMember, ResolutionContext context)
    {
        return source.JoinDate.ToString();
    }
}