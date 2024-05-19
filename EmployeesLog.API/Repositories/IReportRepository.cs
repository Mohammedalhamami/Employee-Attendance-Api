namespace EmployeesLog.API.Repositories
{
    public interface IReportRepository
    {
        int? GetEmployeeWorkHours(int employeeId, DateOnly startDate, DateOnly endDate);
        bool? isEmployeeAbsent(int employeeId, DateOnly checkingDate);
    }
}
