using EmployeesLog.API.Models.Domain;

namespace EmployeesLog.API.Repositories
{
    public interface IImageRepository
    {
        Task<Image> UploadAsync(Image image);
    }
}
