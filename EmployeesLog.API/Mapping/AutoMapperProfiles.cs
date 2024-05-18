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
            CreateMap<CreateRequestEmployeeDto, Employee>().ForMember(dest => dest.JoinDate, opt => opt.MapFrom<CustomResolver>()).ReverseMap();
            CreateMap<Employee, EmployeeDto>().ForMember(dest => dest.JoinDate, opt => opt.MapFrom<CustomResolver2>()).ReverseMap();
            CreateMap<UpdateEmployeeRequestDto, Employee>().ForMember(dest => dest.JoinDate, opt => opt.MapFrom<CustomResolver3>()).ReverseMap();


            //Attendance Model.
            CreateMap<AddAttendanceRequestDto, Attendance>().ReverseMap();
            CreateMap<Attendance, AttendanceDto>().ReverseMap();
            CreateMap<Attendance, ReadAttendanceDto>().ReverseMap();
        }
    }
}
