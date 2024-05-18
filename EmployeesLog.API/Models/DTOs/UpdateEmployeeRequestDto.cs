using System.ComponentModel.DataAnnotations;

namespace EmployeesLog.API.Models.DTOs
{
    public class UpdateEmployeeRequestDto
    {
        [Required, Length(3, 128, ErrorMessage = "Text Size between 3 and 128 Character!")]
        public string Name { get; set; } = null!;

        [Required, Length(2, 225, ErrorMessage = "Text Size between 10 and 225 Character!")]
        public string Designation { get; set; } = null!;


        [Required(ErrorMessage = "{0} is required")]
        public string JoinDate { get; set; } = null!;


        [Required, Range(1, 4, ErrorMessage = "Enter Value from 1 to 4")]
        public int StatusId { get; set; }

        [Required(ErrorMessage = "Please Enter F or M")]
        public char Gender { get; set; }
    }
}
