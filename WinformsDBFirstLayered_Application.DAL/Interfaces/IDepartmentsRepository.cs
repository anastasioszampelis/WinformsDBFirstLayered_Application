using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinformsDBFirstLayered_Application.DAL.Data;
using WinformsDBFirstLayered_Application.Dto;

namespace WinformsDBFirstLayered_Application.DAL.Interfaces
{
    public interface IDepartmentsRepository
    {
        Tuple<ResponseDto, Department> GetDepartmentByName(string name);
        
        Tuple<ResponseDto, List<DepartmentDto>> GetDepartments();
    }
}
