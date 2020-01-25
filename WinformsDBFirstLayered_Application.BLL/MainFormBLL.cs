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
    public class MainFormBLL
    {
        private readonly IEmployeesRepository employeesRepository;
        public MainFormBLL(IEmployeesRepository _employeesRepository)
        {
            this.employeesRepository = _employeesRepository;
        }

        public Tuple<ResponseDto, List<EmployeeDto>> GetEmployees()
        {
            return employeesRepository.GetEmployees();
        }

        public ResponseDto DeleteEmployee(EmployeeDto selectedEmployee)
        {
            return employeesRepository.DeleteEmployee(selectedEmployee);
        }

    }
}
