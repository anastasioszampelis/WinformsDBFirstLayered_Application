namespace WinformsDBFirstLayered_Application.UI
{
    partial class FrmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.dgvEmployees = new System.Windows.Forms.DataGridView();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbAddEmployee = new System.Windows.Forms.ToolStripButton();
            this.tsbDeleteEmployee = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmployees)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvEmployees
            // 
            this.dgvEmployees.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEmployees.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvEmployees.Location = new System.Drawing.Point(0, 105);
            this.dgvEmployees.Name = "dgvEmployees";
            this.dgvEmployees.Size = new System.Drawing.Size(502, 345);
            this.dgvEmployees.TabIndex = 0;
            this.dgvEmployees.SelectionChanged += new System.EventHandler(this.dgvEmployees_SelectionChanged);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbAddEmployee,
            this.tsbDeleteEmployee});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(502, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbAddEmployee
            // 
            this.tsbAddEmployee.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbAddEmployee.Image = ((System.Drawing.Image)(resources.GetObject("tsbAddEmployee.Image")));
            this.tsbAddEmployee.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbAddEmployee.Name = "tsbAddEmployee";
            this.tsbAddEmployee.Size = new System.Drawing.Size(42, 22);
            this.tsbAddEmployee.Text = "Add...";
            this.tsbAddEmployee.Click += new System.EventHandler(this.tsbAddEmployee_Click);
            // 
            // tsbDeleteEmployee
            // 
            this.tsbDeleteEmployee.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbDeleteEmployee.Image = ((System.Drawing.Image)(resources.GetObject("tsbDeleteEmployee.Image")));
            this.tsbDeleteEmployee.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbDeleteEmployee.Name = "tsbDeleteEmployee";
            this.tsbDeleteEmployee.Size = new System.Drawing.Size(44, 22);
            this.tsbDeleteEmployee.Text = "Delete";
            this.tsbDeleteEmployee.Click += new System.EventHandler(this.tsbDeleteEmployee_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(502, 450);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.dgvEmployees);
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Employees App";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmployees)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvEmployees;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbAddEmployee;
        private System.Windows.Forms.ToolStripButton tsbDeleteEmployee;
    }
}

