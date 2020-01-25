using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinformsDBFirstLayered_Application.Dto
{
    public class EmployeeDto
    {
        [DisplayName("Κωδικός")]
        public int Id { get; set; }
        [DisplayName("Όνομα")]
        public string Name { get; set; }
        [DisplayName("Επώνυμο")]
        public string Surname { get; set; }
        [DisplayName("Τμήμα")]
        public string DepartmentName { get; set; }
    }
}
