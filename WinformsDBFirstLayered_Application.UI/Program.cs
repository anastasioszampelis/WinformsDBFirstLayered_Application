using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using AutoMapper;
using SimpleInjector;
using SimpleInjector.Diagnostics;
using WinformsDBFirstLayered_Application.BLL;
using WinformsDBFirstLayered_Application.DAL;
using WinformsDBFirstLayered_Application.DAL.Data;
using WinformsDBFirstLayered_Application.DAL.Interfaces;
using WinformsDBFirstLayered_Application.Dto;

namespace WinformsDBFirstLayered_Application.UI
{
    static class Program
    {
        private static Container container;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Bootstrap();
            Application.Run(container.GetInstance<FrmMain>());
        }

        private static void Bootstrap()
        {
            // Create the container as usual.
            container = new Container();

            // Register your types, for instance:
            container.Register<FrmMain>();
            Registration frmMainRegistration = container.GetRegistration(typeof(FrmMain)).Registration;
            frmMainRegistration.SuppressDiagnosticWarning(DiagnosticType.DisposableTransientComponent, "Reason of suppression");
            container.Register<FrmAddEmployee>();
            Registration frmAddEmployeeRegistration = container.GetRegistration(typeof(FrmAddEmployee)).Registration;
            frmAddEmployeeRegistration.SuppressDiagnosticWarning(DiagnosticType.DisposableTransientComponent, "Reason of suppression");
            container.Register<MainFormBLL>(Lifestyle.Transient);
            container.Register<AddEmployeeBLL>(Lifestyle.Transient);
            container.Register<IEmployeesRepository, EmployeesRepository>(Lifestyle.Transient);
            container.Register<IDepartmentsRepository, DepartmentsRepository>(Lifestyle.Transient);

            container.RegisterInstance<MapperConfiguration>(AutoMapperConfig.RegisterMappings());
            container.Register<IMapper>(() => AutoMapperConfig.RegisterMappings().CreateMapper(container.GetInstance));


            // Optionally verify the container.
            container.Verify();
        }

        
    }

    public static class AutoMapperConfig
    {
        public static MapperConfiguration RegisterMappings()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Employee, EmployeeDto>()
                    .ForMember(dest => dest.DepartmentName, opt => opt.MapFrom(src => src.Department.Name));
                cfg.CreateMap<Department, DepartmentDto>();
            });
        }
    }
}
