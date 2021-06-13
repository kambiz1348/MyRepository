using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace nikanClient
{
    public partial class Form4 : nikanClient.frmMaster
    {
        DataTable dt;
        BindingSource bindingSource;
        BLL.Units units;
        Classes.configClass configClass = Classes.singleTonClassConfig.Instance;
        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            base.btnSave.Visible = false;
            bindingSource = new BindingSource();
            units = new BLL.Units();
            units.httpUrl = configClass.BaseUriGet();
            dt = units.getData();
            if (dt.Rows.Count == 0)
                dt.Rows.Add(dt.NewRow());
            
            bindingSource.DataSource = dt;
            base.bindingNavigator1.BindingSource = bindingSource;
            dataGridView_withQuery1.DataSource = bindingSource;
            txtName.DataBindings.Add("Text", bindingSource, "Name");
        }
        public void updateData()
        {
            bindingSource.EndEdit();
            units.updateData((DataTable)dt);
        }
        public void search()
        {
            dataGridView_withQuery1.SearchSimpleStart();
        }
    }
}
