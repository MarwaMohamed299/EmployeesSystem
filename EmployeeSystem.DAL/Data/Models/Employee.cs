using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeSystem.DAL.Data.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string Name { get; set; } = string.Empty;
        public bool IsActivated { get; set; }
    }
}
