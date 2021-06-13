using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace nikanClient
{
    public partial class frmUser : frmMaster
    {
        DataTable dt=new DataTable();
        BLL.Users users;
        BindingSource bindingSource;
        Classes.configClass configClass = Classes.singleTonClassConfig.Instance;
        Classes.Cryptography crypto;
        public frmUser()
        {
            InitializeComponent();
            bindingSource = new BindingSource();
            //((System.Data.DataRowView)bindingSource.Current).IsNew==true
            base.btnSave.Visible = false;
            crypto = new Classes.Cryptography();
        }

        private void frmUser_Load(object sender, EventArgs e)
        {
            users = new BLL.Users();
            users.httpUrl = configClass.BaseUriGet();
            dt = users.getData();
            for (int i = 0; i < dt.Rows.Count; i++)
                dt.Rows[i]["Password"] = crypto.Decrypt(dt.Rows[i]["Password"].ToString());
            if (dt.Rows.Count == 0)
            {
                dt.Rows.Add(dt.NewRow());
                dt.Rows[0]["IsActive"] = 0;        
            }
            
            bindingSource.DataSource = dt;
            base.bindingNavigator1.BindingSource = bindingSource;
            txtFirstName.DataBindings.Add("Text", bindingSource, "FirstName");
            txtLastName.DataBindings.Add("Text", bindingSource, "LastName");
            txtEmail.DataBindings.Add("Text", bindingSource, "email");
            txtLogin.DataBindings.Add("Text", bindingSource, "Login");
            txtPassword.DataBindings.Add("Text", bindingSource, "Password");
            chkIsActive.DataBindings.Add("Checked", bindingSource, "IsActive",true);
            dataGridView_withQuery1.DataSource = bindingSource;
        }
        public void updateData()
        {
            bindingSource.EndEdit();
            for (int i = 0; i < dt.Rows.Count; i++)
                dt.Rows[i]["Password"] = crypto.Encrypt(dt.Rows[i]["Password"].ToString());
            users.updateData((DataTable)dt);
            for (int i = 0; i < dt.Rows.Count; i++)
                dt.Rows[i]["Password"] = crypto.Decrypt(dt.Rows[i]["Password"].ToString());
        }
        public void search()
        {
            dataGridView_withQuery1.SearchSimpleStart();
        }

    }
}
