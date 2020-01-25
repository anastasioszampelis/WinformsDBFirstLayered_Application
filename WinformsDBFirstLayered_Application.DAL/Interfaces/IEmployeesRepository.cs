using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinformsDBFirstLayered_Application.Dto;

namespace WinformsDBFirstLayered_Application.DAL.Interfaces
{
    public interface IEmployeesRepository
    {
        Tuple<ResponseDto, List<EmployeeDto>> GetEmployees();
        ResponseDto AddEmployee(EmployeeDto selectedEmployee);
        ResponseDto DeleteEmployee(EmployeeDto selectedEmployee);

    }
}
