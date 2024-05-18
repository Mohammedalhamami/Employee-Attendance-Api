using AutoMapper;
using EmployeesLog.API.Models.Domain;
using EmployeesLog.API.Models.DTOs;
using EmployeesLog.API.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeesLog.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttendanceController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IAttendanceRepository attendanceRepository;

        public AttendanceController(IMapper mapper, IAttendanceRepository attendanceRepository)
        {
            this.mapper = mapper;
            this.attendanceRepository = attendanceRepository;
        }


        [HttpPost("Create")]
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
        [Route("{id:long}")]
        public async Task<IActionResult> Read([FromRoute] long id)
        {
            //db ==> domain.
            var attendanceDomainModel = await attendanceRepository.ReadAsync(id);

            if(attendanceDomainModel is null)
            {
                return NotFound();
            }
           
            return Ok(mapper.Map<ReadAttendanceDto>(attendanceDomainModel));

        }

        [HttpPut]
        [Route("{id:long}")]
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
        [Route("{id:long}")]
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
