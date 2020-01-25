using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinformsDBFirstLayered_Application.Dto
{
    public class DepartmentDto
    {
        [DisplayName("Κωδικός")]
        public int Id { get; set; }
        [DisplayName("Περιγραφή")]
        public string Name { get; set; }
    }
}
