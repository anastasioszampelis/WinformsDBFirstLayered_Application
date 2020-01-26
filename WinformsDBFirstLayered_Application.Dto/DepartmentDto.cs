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
        [DisplayName("Id")]
        public int Id { get; set; }
        [DisplayName("Description")]
        public string Name { get; set; }
    }
}
