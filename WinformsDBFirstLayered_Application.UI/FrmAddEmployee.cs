using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinformsDBFirstLayered_Application.BLL;
using WinformsDBFirstLayered_Application.Dto;

namespace WinformsDBFirstLayered_Application.UI
{
    public partial class FrmAddEmployee : Form
    {
        BindingSource departmentsBindingSource;
        private readonly AddEmployeeBLL addEmployeeBll;
        public FrmAddEmployee(AddEmployeeBLL _addEmployeeBll)
        {
            InitializeComponent();
            this.addEmployeeBll = _addEmployeeBll;
            this.cmbDepartment.DropDownStyle = ComboBoxStyle.DropDownList;
        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmAddEmployee_Load(object sender, EventArgs e)
        {
            this.GetDepartments();
        }

        private void GetDepartments()
        {
            departmentsBindingSource = new BindingSource();
            var response = addEmployeeBll.GetDepartments();
            if (response.Item1.Result)
            {
                departmentsBindingSource.DataSource = response.Item2;

                cmbDepartment.DataSource = departmentsBindingSource;
                cmbDepartment.DisplayMember = "Name";
                cmbDepartment.ValueMember = "Name";
            }
            else
            {
                MessageBox.Show(response.Item1.Message);
                this.Close();
            }
                
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            var newEmployee = new EmployeeDto()
            {
                Name = txtName.Text,
                Surname = txtSurname.Text,
                DepartmentName = cmbDepartment.SelectedValue.ToString()
            };
            var response = addEmployeeBll.AddEmployee(newEmployee);
            if (response.Result)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show(response.Message);
            }
            
        }
    }
}
