using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinformsDBFirstLayered_Application.UI.XtraControls
{
    using System;
    using System.ComponentModel;
    using System.Windows.Forms;
    using System.Runtime.InteropServices;

    [ToolboxBitmap(typeof(ToolStripTextBox))]
    public partial class ToolStripTextBoxWithCue : ToolStripTextBox
    {
        private const int EM_SETCUEBANNER = 0x1501;
        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        private static extern Int32 SendMessage(IntPtr hWnd, int msg,
            int wParam, string lParam);
        public ToolStripTextBoxWithCue()
        {
            this.Control.HandleCreated += Control_HandleCreated;
        }
        private void Control_HandleCreated(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(cueBanner))
                UpdateCueBanner();
        }
        string cueBanner;
        public string CueBanner
        {
            get { return cueBanner; }
            set
            {
                cueBanner = value;
                UpdateCueBanner();
            }
        }
        private void UpdateCueBanner()
        {
            SendMessage(this.Control.Handle, EM_SETCUEBANNER, 0, cueBanner);
        }
    }

}
