using AutoMapper;
using EmployeesLog.API.Models.Domain;
using EmployeesLog.API.Models.DTOs;

namespace EmployeesLog.API.Mapping
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            //Employee Model.
            CreateMap<CreateRequestEmployeeDto, Employee>().ReverseMap();
            CreateMap<Employee, EmployeeDto>().ReverseMap();
            CreateMap<UpdateEmployeeRequestDto, Employee>().ReverseMap();


            //Attendance Model.
            CreateMap<AddAttendanceRequestDto, Attendance>().ReverseMap();
            CreateMap<Attendance, AttendanceDto>().ReverseMap();
            CreateMap<Attendance, ReadAttendanceDto>().ReverseMap();
        }
    }
}
