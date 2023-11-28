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
        Task Add(EmployeesAddDto employeesAddDto);
        Task Update(EmployeesUpdateDto employee);
        Task Delete(int EmployeeId);

         
    }
}
