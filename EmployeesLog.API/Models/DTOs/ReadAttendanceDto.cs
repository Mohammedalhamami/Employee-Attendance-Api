using EmployeesLog.API.Models.Domain;

namespace EmployeesLog.API.Models.DTOs
{
    public class ReadAttendanceDto
    {
        
        public string employeeName { get; set; }
        public string Gender { get; set; }
        public DateOnly JoinDate { get; set; }
        public string Designation { get; set; } = null!;
        public DateTime PunchDateTime { get; set; }
        //1 Check in, 2 Check out.
        public string PunchStatus { get; set; }
       
        //F 0, M 1.
    }
}
