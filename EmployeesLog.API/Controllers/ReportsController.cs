using EmployeesLog.API.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeesLog.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class ReportsController : ControllerBase
    {
        private readonly IReportRepository reportRepository;

        public ReportsController(IReportRepository reportRepository)
        {
            this.reportRepository = reportRepository;
        }
        [HttpGet]
        [Route("Workedhours/{employeeId:int}")]
        [Authorize(Roles = "Reader")]
        public IActionResult GeEmployeeWorkHours([FromRoute] int employeeId, [FromQuery] DateOnly startDate, [FromQuery] DateOnly endDate)
        {
           var employeeWorkHours = reportRepository.GetEmployeeWorkHours(employeeId, startDate, endDate);

            if(employeeWorkHours is null)
            {
                return NotFound();
            }
            return Ok(employeeWorkHours);
        }


        [HttpGet]
        [Route("absence/{employeeId:int}")]
        [Authorize(Roles = "Reader")]
        public IActionResult CheckEmployeeAvailablity([FromRoute] int employeeId, [FromRoute]DateOnly checkingDate)
        {
            var result = reportRepository.isEmployeeAbsent(employeeId, checkingDate);
            
            if(result is null)
            {
                return BadRequest();
            }

            return Ok(result);
        }
    }
}
