namespace EmployeesLog.API.Models.Domain
{
    public class Attendance
    {
        //auto number.
        public long Id { get; set; }
        public int EmployeeId { get; set; }
        public DateTime PunchDateTime { get; set; }
        //1 Check in, 2 Check out.
        public int PunchStatus { get; set; }
        public Employee Employee { get; set; } 

    }
}
