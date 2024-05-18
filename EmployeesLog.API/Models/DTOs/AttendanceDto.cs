using EmployeesLog.API.Models.Domain;

namespace EmployeesLog.API.Models.DTOs
{
    public class AttendanceDto
    {
        public int EmployeeId { get; set; }
        public DateTime PunchDateTime { get; set; }
        //1 Check in, 2 Check out.
        public int PunchStatus { get; set; }
    }
}
