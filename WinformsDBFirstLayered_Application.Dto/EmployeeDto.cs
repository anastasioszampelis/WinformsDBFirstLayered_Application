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
        [DisplayName("Id")]
        public int Id { get; set; }
        [DisplayName("Name")]
        public string Name { get; set; }
        [DisplayName("Surname")]
        public string Surname { get; set; }
        [DisplayName("Department")]
        public string DepartmentName { get; set; }
    }
}
