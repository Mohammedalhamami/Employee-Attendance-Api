namespace EmployeesLog.API.Models.DTOs
{

    public class ReadEmployeeDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Designation { get; set; } = null!;
        public DateOnly JoinDate { get; set; }
        public int StatusId { get; set; } 
        public string Status { get; set; } = null!;
        public char Gender { get; set; } 
    }
}
