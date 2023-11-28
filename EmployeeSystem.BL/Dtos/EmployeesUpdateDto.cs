using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeSystem.BL.Dtos
{
    public class EmployeesUpdateDto
    {
        public int EmployeeId { get; }
        public string Name { get; set; } = string.Empty;
        public bool IsActivated { get; set; }
    }
}
