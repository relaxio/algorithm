using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DPsingleton
{
    public partial class FormToolbox : Form
    {
        private static FormToolbox ftb = null;
        private FormToolbox()
        {
            InitializeComponent();
        }

        public static FormToolbox GetInstance()
        {
            if(null == ftb || ftb.IsDisposed)
            {
                ftb = new FormToolbox();
                ftb.MdiParent = Form1.ActiveForm;
            }
            return ftb;
        }
    }
}
