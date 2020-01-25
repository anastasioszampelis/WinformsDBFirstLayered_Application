using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinformsDBFirstLayered_Application.DAL.Data;
using WinformsDBFirstLayered_Application.DAL.Interfaces;
using WinformsDBFirstLayered_Application.Dto;

namespace WinformsDBFirstLayered_Application.DAL
{
    public class EmployeesRepository : IEmployeesRepository
    {
        private readonly IMapper _iMapper;
        private readonly IDepartmentsRepository departmentsRepository;

        public EmployeesRepository(IMapper mapper, IDepartmentsRepository _departmentsRepository)
        {
            //var config = new MapperConfiguration(cfg =>
            //{
            //    cfg.CreateMap<Employee, EmployeeDto>()
            //        .ForMember(dest => dest.DepartmentName, opt => opt.MapFrom(src => src.Department.Name));
            //});
            //_iMapper = config.CreateMapper();
            this._iMapper = mapper;
            this.departmentsRepository = _departmentsRepository;
    
        }

        public Tuple<ResponseDto, List<EmployeeDto>> GetEmployees()
        {
            
            List<EmployeeDto> employeesResult = new List<EmployeeDto>();
            ResponseDto response = new ResponseDto();
            try
            {
                using (var context = new EmployeesEntities())
                {
                    var employeesSelected = context.Employees.Include("Department").ToList();
                    employeesResult = _iMapper.Map<List<Employee>, List<EmployeeDto>>(employeesSelected);
                }
                response.Result = true;
            }
            catch (Exception ex)
            {
                response.Result = false;
                response.Message = ex.Message;
            }
            return new Tuple<ResponseDto, List<EmployeeDto>>(response, employeesResult);
        }

        public ResponseDto AddEmployee(EmployeeDto selectedEmployee)
        {
            ResponseDto response = new ResponseDto();
            var departmentResponse = departmentsRepository.GetDepartmentByName(selectedEmployee.DepartmentName);
            if (departmentResponse.Item1.Result)
            {
                try 
                {
                    using (var context = new EmployeesEntities())
                    {
                        var emp = new Employee()
                        {
                            Name = selectedEmployee.Name,
                            Surname = selectedEmployee.Surname,
                            DepartmentId = departmentResponse.Item2.Id
                        };
                        context.Employees.Add(emp);
                        context.SaveChanges();
                    }
                    response.Result = true;
                }
                catch (Exception ex)
                {
                    response.Result = false;
                    response.Message = ex.Message;
                }
            }
            else
            {
                response.Result = false;
                response.Message = departmentResponse.Item1.Message;
            }
            return response;
        }

        public ResponseDto DeleteEmployee(EmployeeDto selectedEmployee)
        {
            ResponseDto response = new ResponseDto();
            try
            {
                using (var context = new EmployeesEntities())
                {
                    var emp = context.Employees.Where(d => d.Id == selectedEmployee.Id).FirstOrDefault();
                    context.Employees.Remove(emp);
                    context.SaveChanges();
                }
                response.Result = true;
            }
            catch (Exception ex)
            {
                response.Result = false;
                response.Message = ex.Message;
            }

            return response;
        }
    }
}
