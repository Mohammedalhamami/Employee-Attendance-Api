namespace Employee_Attendance_Tracker.Models.DTO
{
    public class EmployeeDto
    {
        
        public string Name { get; set; } = null!;
        public string Designation { get; set; } = null!;
        public DateOnly JoinDate { get; set; }
        public string Status { get; set; } = null!;
        public string Gender { get; set; } = null!;
    }
}
