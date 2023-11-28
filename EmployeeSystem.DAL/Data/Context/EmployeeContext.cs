using EmployeeSystem.DAL.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeSystem.DAL.Data.Context
{
    public class EmployeeContext :DbContext
    {
        public DbSet<Employee> Employees => Set<Employee>();

        public EmployeeContext( DbContextOptions<EmployeeContext> options) : base (options)
        {
            
        }
       

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Employee>().HasKey(x => x.EmployeeId);


            #region Seeding

            var Employees = new List<Employee>
            {
                new Employee
                {
                    EmployeeId = 1,
                    Name = "Michael",
                    IsActivated = true
                },
                 new Employee
                {
                    EmployeeId = 2,
                    Name = "Marwa",
                    IsActivated = true
                }, new Employee
                {
                    EmployeeId = 3,
                    Name = "Sara",
                    IsActivated = true
                },
            };


            #endregion

            modelBuilder.Entity<Employee>().HasData(Employees);
        }

    }
}
