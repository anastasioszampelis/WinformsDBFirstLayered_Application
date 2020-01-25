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
using WinformsDBFirstLayered_Application.UI.XtraControls;

namespace WinformsDBFirstLayered_Application.UI
{
    public partial class FrmMain : Form
    {
        public BindingSource employeesBindingSource;
        public virtual List<EmployeeDto> totalEmployees { get; set; }
        public virtual EmployeeDto selectedEmployee { get; set; } = null;

        ToolStripTextBoxWithCue myToolstriptextboxwithcue;
        ToolStripButton tsbFilterEmployees;
        private readonly SimpleInjector.Container container;
        private readonly MainFormBLL mainFormBLL;
        public FrmMain(SimpleInjector.Container _container, MainFormBLL _mainFormBLL)
        {
            InitializeComponent();
            this.mainFormBLL = _mainFormBLL;
            this.container = _container;
            employeesBindingSource = new BindingSource();
            dgvEmployees.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvEmployees.ReadOnly = true;
            dgvEmployees.MultiSelect = false;
            dgvEmployees.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;
            myToolstriptextboxwithcue = new ToolStripTextBoxWithCue()
            {
                CueBanner="Επώνυμο"
            };
            tsbFilterEmployees = new ToolStripButton()
            {
                Text = "Φίλτρο"
            };
            //tsbFilterEmployees.Enabled = false;
            myToolstriptextboxwithcue.KeyUp += new System.Windows.Forms.KeyEventHandler(MyToolStripTextBoxWithCue_KeyUp);
            tsbFilterEmployees.Click += new EventHandler(tsbFilterEmployees_Click);
            toolStrip1.Items.Add(myToolstriptextboxwithcue);
            toolStrip1.Items.Add(tsbFilterEmployees);
        }

        private void tsbFilterEmployees_Click(object sender, EventArgs e)
        {
            employeesBindingSource.DataSource = null;
            List<EmployeeDto> filteredEmployees = null;
            if (myToolstriptextboxwithcue.Text==string.Empty)
            {
                filteredEmployees = totalEmployees;
            }
            else
            {
                filteredEmployees = totalEmployees.Where(d => d.Surname.StartsWith(myToolstriptextboxwithcue.Text)).ToList();
            }
            employeesBindingSource.DataSource = filteredEmployees;
            dgvEmployees.DataSource = employeesBindingSource;
        }

        private void MyToolStripTextBoxWithCue_KeyUp(object sender, KeyEventArgs e)
        {
            //tsbFilterEmployees.Enabled = myToolstriptextboxwithcue.Text != string.Empty;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.GetEmployees();
        }

        public void GetEmployees()
        {
            employeesBindingSource.DataSource = null;
            var response = mainFormBLL.GetEmployees();
            if (response.Item1.Result==true)
            {
                totalEmployees = response.Item2;
                employeesBindingSource.DataSource = totalEmployees;
                dgvEmployees.DataSource = employeesBindingSource;
            }
            else
            {
                MessageBox.Show(response.Item1.Message);
                Application.Exit();
            }
           
        }

        private void tsbAddEmployee_Click(object sender, EventArgs e)
        {
            //FrmAddEmployee frmAddEmployee = new FrmAddEmployee(container.GetInstance<AddEmployeeBLL>());

            var frmAddEmployee = container.GetInstance<FrmAddEmployee>();
            if (frmAddEmployee.ShowDialog() == DialogResult.OK)
            {
                GetEmployees();
            }
            
        }

        private void dgvEmployees_SelectionChanged(object sender, EventArgs e)
        {
            if(dgvEmployees.SelectedRows != null && dgvEmployees.SelectedRows.Count == 1)
            {
                tsbDeleteEmployee.Enabled = true;
                selectedEmployee = (EmployeeDto)dgvEmployees.CurrentRow.DataBoundItem;
            }
            else
            {
                tsbDeleteEmployee.Enabled = false;
                selectedEmployee = null;
            }
            
        }

        private void tsbDeleteEmployee_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Είστε σίγουροι;", "Employees App", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                var response = mainFormBLL.DeleteEmployee(selectedEmployee);
                if (response.Result)
                {
                    GetEmployees();
                }
                else
                {
                    MessageBox.Show(response.Message);
                }
            }
            
        }
    }
}
