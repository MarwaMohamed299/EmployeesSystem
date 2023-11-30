using EmployeeSystem.BL.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeSystem.BL.Managers
{
    public interface IEmployeesManager 
    {
        Task<IEnumerable<EmployeesReadDto>> GetAllEmployees();
        Task<EmployeesReadDto?> GetById(int EmployeeId);
        Task<string> Add(EmployeesAddDto employeesAddDto);
       // Task<string?> Update(EmployeesUpdateDto employee);
        Task<string?> UpdateEmployee(int EmployeeId);

         
    }
}
