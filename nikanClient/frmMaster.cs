using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace nikanClient
{
    public partial class frmMaster : Form
    {
        public frmMaster()
        {
            InitializeComponent();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            MethodInfo addMethod = this.GetType().GetMethod("updateData");
            object result = addMethod.Invoke(this, null);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            MethodInfo addMethod = this.GetType().GetMethod("updateData");
            object result = addMethod.Invoke(this, null);
        }

        private void searchToolStripButton_Click(object sender, EventArgs e)
        {
            MethodInfo addMethod = this.GetType().GetMethod("search");
            object result = addMethod.Invoke(this, null);
        }
    }
}
