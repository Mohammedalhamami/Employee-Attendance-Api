using EmployeesLog.API.Models.Domain;
using System.ComponentModel.DataAnnotations;

namespace EmployeesLog.API.Models.DTOs
{
    public class AddAttendanceRequestDto
    {
        [Required, Range(100000, 999999, ErrorMessage ="Out of range input, please enter between 100000 and 999999")]
        public long EmployeeId { get; set; }

        [Required, DataType(DataType.DateTime)]
        public DateTime PunchDateTime { get; set; }

        [Required, Range(1, 2, ErrorMessage ="Pleaes enter 1 for check in, 2 for check out.")]
        //1 Check in, 2 Check out.
        public int PunchStatus { get; set; }
        
    }
}
