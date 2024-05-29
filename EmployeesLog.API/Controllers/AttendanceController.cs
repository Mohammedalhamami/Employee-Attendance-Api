using AutoMapper;
using EmployeesLog.API.CustomActionFilters;
using EmployeesLog.API.Models.Domain;
using EmployeesLog.API.Models.DTOs;
using EmployeesLog.API.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace EmployeesLog.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class AttendanceController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IAttendanceRepository attendanceRepository;
        private readonly ILogger<AttendanceController> logger;

        public AttendanceController(IMapper mapper, IAttendanceRepository attendanceRepository,
                   ILogger<AttendanceController> logger)
        {
            this.mapper = mapper;
            this.attendanceRepository = attendanceRepository;
            this.logger = logger;
        }


        [HttpPost("Create")]
        [ValidateModel]
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> Create([FromBody] AddAttendanceRequestDto addAttendanceRequestDto)
        {
            //from dto to domain.
            var attendanceDomainModel = mapper.Map<Attendance>(addAttendanceRequestDto);

            //domain to db.
            attendanceDomainModel = await attendanceRepository.CreateAsync(attendanceDomainModel);

            if(attendanceDomainModel is null)
            {
                return BadRequest(ModelState);
            }
            //domain ==> dto.
            return Ok(mapper.Map<AttendanceDto>(attendanceDomainModel));
        }

        [HttpGet]
        [Route("Read/{id:long}")]
        //[Authorize(Roles = "Reader")]
        public async Task<IActionResult> Read([FromRoute] long id)
        {
            
                var attendanceDto = await attendanceRepository.ReadAsync(id);

                if(attendanceDto is null)
                {
                    return NotFound();
                }

            throw new Exception("This is a new fucking exception");

                return Ok(attendanceDto);
            
            //db ==>dto.

        }

        [HttpPut]
        [Route("Update/{id:long}")]
        [ValidateModel]
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> Update([FromBody] AttendanceDto attendanceDto, [FromRoute] long id)
        {
            //dto ==> domain
            var attendanceDomainModel = mapper.Map<Attendance>(attendanceDto);

            attendanceDomainModel = await attendanceRepository.UpdateAsync(attendanceDomainModel, id);

            if(attendanceDomainModel is null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<AttendanceDto>(attendanceDomainModel));
        }

        [HttpDelete]
        [Route("Delete/{id:long}")]
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> Delete([FromRoute] long id)
        {
            //from db to domain model.
            var attendanceDomainModel = await attendanceRepository.DeleteAsync(id);

            if( attendanceDomainModel is null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<AttendanceDto>(attendanceDomainModel));

        }

    }
}
