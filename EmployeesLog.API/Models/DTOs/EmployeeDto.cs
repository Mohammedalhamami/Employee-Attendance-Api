using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace EmployeesLog.API.Models.DTOs
{
    public class EmployeeDto
    {
        [Required, Length(3, 128, ErrorMessage = "Text Size between 3 and 128 Character!")]
        public string Name { get; set; } = null!;

        [Required, Length(2, 225, ErrorMessage = "Text Size between 10 and 225 Character!")]
        public string Designation { get; set; } = null!;

        [Required]
        public string JoinDate { get; set; }

        [Required]
        public string Status { get; set; }

        [Required(ErrorMessage = "Please Enter F or M")]
        public char Gender { get; set; }
    }
}
