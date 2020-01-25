using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinformsDBFirstLayered_Application.DAL;
using WinformsDBFirstLayered_Application.DAL.Interfaces;
using WinformsDBFirstLayered_Application.Dto;

namespace WinformsDBFirstLayered_Application.BLL
{
    public class AddEmployeeBLL
    {
        private readonly IEmployeesRepository employeesRepository;
        private readonly IDepartmentsRepository departmentsRepository;
        public AddEmployeeBLL(IEmployeesRepository _employeesRepository, IDepartmentsRepository _departmentsRepository)
        {
            employeesRepository = _employeesRepository;
            departmentsRepository = _departmentsRepository;
        }

        public Tuple<ResponseDto, List<DepartmentDto>> GetDepartments()
        {
            return departmentsRepository.GetDepartments();
        }

        public ResponseDto AddEmployee(EmployeeDto selectedEmployee)
        {
            return employeesRepository.AddEmployee(selectedEmployee);
        }
    }
}
