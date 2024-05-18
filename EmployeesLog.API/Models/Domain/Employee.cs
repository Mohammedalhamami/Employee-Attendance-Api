namespace EmployeesLog.API.Models.Domain
{
    public class Employee
    {
        //6 digits. seed value 1000000, auto number.
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Designation { get; set; } = null!;
        public DateOnly JoinDate { get; set; }
        public int StatusId { get; set; }
        //F 0, M 1.
        public char Gender { get; set; }
        public ICollection<Attendance> Attendances { get; set; } = new List<Attendance>();
    }
}
