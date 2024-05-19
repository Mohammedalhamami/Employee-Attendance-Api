using EmployeesLog.API.Repositories;
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
        public IActionResult GeEmployeeWorkHours([FromRoute] int employeeId, [FromQuery] DateOnly startDate, [FromQuery] DateOnly endDate)
        {
           var employeeWorkHours = reportRepository.GetEmployeeWorkHours(employeeId, startDate, endDate);

            if(employeeWorkHours is null)
            {
                return NotFound();
            }
            return Ok(employeeWorkHours);
        }
    }
}
