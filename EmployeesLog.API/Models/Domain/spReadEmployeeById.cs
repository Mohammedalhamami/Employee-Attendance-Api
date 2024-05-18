namespace EmployeesLog.API.Models.Domain
{
    
    public class spReadEmployeeById
    {
        public string Name { get; set; } = null!;
        public string Designation { get; set; } = null!;
        public DateTime JoinDate { get; set; }
        public string Status { get; set; } = null!;
        public string Gender { get; set; } = null!;
    }
}
