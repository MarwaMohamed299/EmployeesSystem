using EmployeeSystem.DAL.Data.Context;
using EmployeeSystem.DAL.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeSystem.DAL.Repos
{
    public class EmployeesRepo :IEmployeesRepo
    {
        private readonly EmployeeContext _employeeContext;

        public EmployeesRepo(EmployeeContext employeeContext)
        {
            _employeeContext = employeeContext;
        }

        public async Task<IEnumerable<Employee>> GetAllEmployees()
        {
           return await _employeeContext.Employees.ToListAsync();

        }

        public async Task<Employee?> GetById(int employeeId)
        {
            return await _employeeContext.Employees.FindAsync(employeeId);
        }

      
        public async Task Add(Employee employee)
        {
             await _employeeContext.Employees.AddAsync(employee);
            await _employeeContext.SaveChangesAsync();

        }
        public async Task UpdateEmployee(Employee employee)
        {
            _employeeContext.Employees.Update(employee);
            await _employeeContext.SaveChangesAsync();

        }
       
        public int SaveChanges()
        {
            return _employeeContext.SaveChanges();
        }



    }
}
