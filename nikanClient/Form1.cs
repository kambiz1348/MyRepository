using DataGridViewAutoFilter;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace nikanClient
{
    public partial class Form1 : frmMaster
    {
        string httpUrl;
        BindingSource bindingSource;
        DataTable dt;
        BLL.Units units;
        public Form1()
        {
            InitializeComponent();

            new Classes.setStyle().gridStyle(dataGridView1);

            dataGridView1.AutoGenerateColumns = false;
            httpUrl = new Classes.configClass().BaseUriGet();
            base.bindingNavigator1.Visible = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            units = new BLL.Units();
            units.httpUrl= new Classes.configClass().BaseUriGet();
            dt = units.getData();
            bindingSource = new BindingSource();
            bindingSource.DataSource = dt;
            dataGridView1.DataSource = bindingSource;
            base.bindingNavigator1.BindingSource = bindingSource;
            dataGridView_withQuery1.DataSource = bindingSource;
        }
        public void updateData()
        {
            units.updateData(dt);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView_withQuery1.SearchAdvancedStart();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView_withQuery1.SearchSimpleStart();
        }

        private void dataGridView_withQuery1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Alt && (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up))
            {
                DataGridViewAutoFilterColumnHeaderCell filterCell =
                    dataGridView1.CurrentCell.OwningColumn.HeaderCell as
                    DataGridViewAutoFilterColumnHeaderCell;
                if (filterCell != null)
                {
                    filterCell.ShowDropDownList();
                    e.Handled = true;
                }
            }

        }

        private void dataGridView_withQuery1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            String filterStatus = DataGridViewAutoFilterColumnHeaderCell
    .GetFilterStatus(dataGridView_withQuery1);
            if (String.IsNullOrEmpty(filterStatus))
            {
                showAllLabel.Visible = false;
                filterStatusLabel.Visible = false;
            }
            else
            {
                showAllLabel.Visible = true;
                filterStatusLabel.Visible = true;
                filterStatusLabel.Text = filterStatus;
            }

        }

        private void showAllLabel_Click(object sender, EventArgs e)
        {
            DataGridViewAutoFilterColumnHeaderCell.RemoveFilter(dataGridView1);
        }
    }
}
