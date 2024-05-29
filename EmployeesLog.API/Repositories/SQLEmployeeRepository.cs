using EmployeesLog.API.Data;
using EmployeesLog.API.Models.Domain;
using EmployeesLog.API.Models.DTOs;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace EmployeesLog.API.Repositories
{
    public class SQLEmployeeRepository : IEmployeeRepository
    {
        private readonly EmployeesLogDbContext dbContext;

        public SQLEmployeeRepository(EmployeesLogDbContext employeesLogDbContext)
        {
            this.dbContext = employeesLogDbContext;
        }
        public async Task<Employee?> CreateAsync(Employee employee)
        {

            await dbContext.Employees.AddAsync(employee);
            await dbContext.SaveChangesAsync();

            return employee;
        }

        public async Task<Employee?> DeleteByIdAsync(int id)
        {
           var existingEmployee = await dbContext.Employees.FirstOrDefaultAsync(x => x.Id == id);

            if(existingEmployee is null)
            {
                return null;
            }
            dbContext.Employees.Remove(existingEmployee);

            await dbContext.SaveChangesAsync();

            return existingEmployee;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>List<spReadEmployeeById>?</returns>
        public async Task<List<ReadEmployeeDto>?> ReadAllAsync()
        {
          return  await dbContext.Employees.Join(dbContext.EmployeeStatuses,
                                           employee => employee.StatusId, empStatus => empStatus.Id
                                           , (employee, empStatus) => new ReadEmployeeDto
                                           {
                                               Id = employee.Id,
                                               Name = employee.Name,
                                               Designation = employee.Designation,
                                               JoinDate = employee.JoinDate,
                                               Gender = employee.Gender,
                                               Status = empStatus.Name,
                                               StatusId = empStatus.Id
                                           }).ToListAsync();
        }

        public async Task<ReadEmployeeDto?> ReadByIdAsync(int id)
        {
            
            var existingEmployee =  await  dbContext.Employees.Where(employee => employee.Id == id).Join(dbContext.EmployeeStatuses,
										   employee => employee.StatusId, empStatus => empStatus.Id
										   , (employee, empStatus) => new ReadEmployeeDto
										   {
											   Id = employee.Id,
											   Name = employee.Name,
											   Designation = employee.Designation,
											   JoinDate = employee.JoinDate,
											   Gender = employee.Gender,
											   Status = empStatus.Name,
											   StatusId = empStatus.Id
										   }).FirstOrDefaultAsync();

             
           return existingEmployee;
        }
   
        public async Task<Employee?> UpdateByIdAsync(Employee? employee, int id)
        {
            var existingEmployee = await dbContext.Employees.FirstOrDefaultAsync(x => x.Id == id);

            if (existingEmployee is null)
            {
                return null;
            }

            existingEmployee.Name = employee.Name;
            existingEmployee.Designation = employee.Designation;
            existingEmployee.JoinDate = employee.JoinDate;
            existingEmployee.StatusId = employee.StatusId;
            existingEmployee.Gender = employee.Gender;

            await dbContext.SaveChangesAsync();

            return existingEmployee;
        }
    
    }
}
