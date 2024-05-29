namespace EmployeesLog.API.Models.DTOs
{
    public record LogInResponseDto
    {
        public required string jwtToken { get; set; } = null!;
    }
}
