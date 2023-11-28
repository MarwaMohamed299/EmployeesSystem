using EmployeeSystem.BL.Dtos;
using EmployeeSystem.DAL.Data.Models;
using EmployeeSystem.DAL.Repos;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeSystem.BL.Managers
{
    public class EmployeesManager :IEmployeesManager
    {
        private readonly IEmployeesRepo _employeeRepo;
        private readonly ILogger<EmployeesManager> _logger;

        public EmployeesManager(IEmployeesRepo employeesRepo, ILogger<EmployeesManager> logger)
        {
            _employeeRepo = employeesRepo;
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));

        }


        public async Task<IEnumerable<EmployeesReadDto>> GetAllEmployees()         /*GetAll*/
        {
            try
            {
                var employees = await _employeeRepo.GetAllEmployees();
                return employees.Select(e => new EmployeesReadDto
                {
                    EmployeeId = e.EmployeeId,
                    Name = e.Name,
                    IsActivated = e.IsActivated
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while getting all employees.");
                throw;
            }

        }

        public async Task<EmployeesReadDto?>GetById(int EmployeeId)                 /*GetById*/
        {
            try
            {
                var employee = await _employeeRepo.GetById(EmployeeId);
                if (employee == null)
                {
                    return null;
                }
                return new EmployeesReadDto
                {

                    EmployeeId = employee.EmployeeId,
                    Name = employee.Name,
                    IsActivated = employee.IsActivated
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error occurred while getting employee with ID {EmployeeId}.");
            throw;
            }


            
        }

        public async Task Add(EmployeesAddDto employeesAddDto)                          /*Add*/
        {
            try
            {
                var employee = new Employee
                {
                    Name = employeesAddDto.Name,
                    IsActivated = employeesAddDto.IsActivated
                };

                await _employeeRepo.Add(employee);
                 _employeeRepo.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while adding an employee.");
            }
        }

        public async Task Update(EmployeesUpdateDto employee)                       /*Update*/
        {
            try
            {

              
                var existingEmployee = await _employeeRepo.GetById(employee.EmployeeId);

                if (existingEmployee == null)
                {
                    _logger.LogWarning($"Employee with ID {employee.EmployeeId} not found.");
                }

                existingEmployee.Name = employee.Name;
                existingEmployee.IsActivated = employee.IsActivated;

               await _employeeRepo.Update(existingEmployee);
                _employeeRepo.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error occurred while updating employee with ID {employee.EmployeeId}.");
                throw;
            }
        }
        public async Task Delete(int EmployeeId)
        {
            try
            {
                var existingEmployee = await _employeeRepo.GetById(EmployeeId);

                if (existingEmployee == null)
                {
                    _logger.LogWarning($"Employee with ID {EmployeeId} not found.");
                }

                existingEmployee.IsActivated = false; // Soft delete by setting IsActivated to false

                await _employeeRepo.Update(existingEmployee);
                       _employeeRepo.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error occurred while soft deleting employee with ID {EmployeeId}.");
                throw;
            }
        }



    }
}
