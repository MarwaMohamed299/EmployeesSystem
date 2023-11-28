using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeSystem.BL.Dtos
{
    public class EmployeesAddDto
    {
        public int EmployeeId { get; set; }
        public string Name { get; set; } = string.Empty;
        public bool IsActivated { get; set; }
    }
}
