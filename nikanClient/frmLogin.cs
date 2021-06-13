using nikanClient.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace nikanClient
{
    public partial class frmLogin : Form
    {
        BLL.Login login;
        Classes.configClass configClass = Classes.singleTonClassConfig.Instance;
        Classes.Cryptography crypto;
        DataTable dt;
        public frmLogin()
        {
            InitializeComponent();
            login = new BLL.Login();
            crypto = new Cryptography();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            login.httpUrl = configClass.BaseUriGet();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            dt = login.getData(txtUserId.Text,crypto.Encrypt(txtPassword.Text));
            if (dt.Rows.Count == 0)
                MessageBox.Show("Login Failed");
            else
            {
                frmMainMenuNew menu = new frmMainMenuNew();
                menu.permissionDT = dt;
                menu.ShowDialog();
            }
        }
    }
}
