using EmployeesLog.API.Models.Domain;

namespace EmployeesLog.API.Models.DTOs
{
    public class ReadAttendanceDto
    {
        
        public DateTime PunchDateTime { get; set; }
        //1 Check in, 2 Check out.
        public string PunchStatus { get; set; }
        public Employee Employee { get; set; }
    }
}
