using EmployeeSystem.DAL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeSystem.DAL.Repos
{
    public interface IEmployeesRepo
    {
        Task <IEnumerable<Employee>> GetAllEmployees();
        Task<Employee?> GetById(int employeeId);

        Task Add(Employee employee);
        Task Update(Employee employee);
        Task Delete(Employee employee);
        int SaveChanges();



    }
}
