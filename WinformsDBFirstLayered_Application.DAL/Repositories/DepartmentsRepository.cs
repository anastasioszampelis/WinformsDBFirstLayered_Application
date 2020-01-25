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
    public class DepartmentsRepository : IDepartmentsRepository
    {
        private readonly IMapper _iMapper;

        public DepartmentsRepository(IMapper mapper)
        {
            this._iMapper = mapper;
            //var config = new MapperConfiguration(cfg =>
            //{
            //    cfg.CreateMap<Department, DepartmentDto>();
            //});
            //_iMapper = config.CreateMapper();
        }

        public Tuple<ResponseDto, Department> GetDepartmentByName(string name)
        {
            ResponseDto response = new ResponseDto();
            Department selectedDepartment = null;
            try
            {
                using (var context = new EmployeesEntities())
                {
                    selectedDepartment = context.Departments.Where(d => d.Name == name).FirstOrDefault();
                }
                response.Result = true;
            }
            catch (Exception ex)
            {
                response.Result = false;
                response.Message = ex.Message;
            }

            return new Tuple<ResponseDto, Department>(response, selectedDepartment);
        }

        public Tuple<ResponseDto, List<DepartmentDto>> GetDepartments()
        {
            List<DepartmentDto> departmentsResult = new List<DepartmentDto>();
            ResponseDto response = new ResponseDto();
            try
            {
                using (var context = new EmployeesEntities())
                {
                    var departmentsSelected = context.Departments.ToList();
                    departmentsResult = _iMapper.Map<List<Department>, List<DepartmentDto>>(departmentsSelected);
                }
                response.Result = true;
            }
            catch (Exception ex)
            {
                response.Result = false;
                response.Message = ex.Message;
            }

            return new Tuple<ResponseDto, List<DepartmentDto>>(response, departmentsResult);
        }
    }
}
