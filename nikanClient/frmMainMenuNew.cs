using MyControlLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;

namespace nikanClient
{
    public partial class frmMainMenuNew : Form
    {
        public frmMainMenuNew()
        {
            InitializeComponent();
            //this.tabControl1.OnClose += new MyControlLibrary.TabCtlEx.OnHeaderCloseDelegate(this.tabControl1_OnClose);
        }
        private void frmMainMenu_Load(object sender, EventArgs e)
        {
            tabControl1.DisplayStyle = TabStyle.Chrome;
            //label2.Text = permissionDT.Rows[0]["FirstName"].ToString().Trim() + " " + permissionDT.Rows[0]["LastName"].ToString().Trim();
            //setAuthorization();
        }
        private void runMethod(string name)
        {
            MethodInfo addMethod = this.GetType().GetMethod(name);
            object result = addMethod.Invoke(this, null);
        }
        private void runForm(string name)
        {
            var form = (Form)Activator.CreateInstance(Type.GetType(name));
            foreach (TabPage item in tabControl1.TabPages)
                if (item.Text.Trim() == form.Text.Trim())
                {
                    tabControl1.SelectedTab = item;
                    return;
                }
            MyControlLibrary.TabPageEx tp = new MyControlLibrary.TabPageEx();
            tp.BorderStyle = BorderStyle.FixedSingle;
            tp.Text = form.Text.Trim();
            tp.Name = form.Text;
            tp.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            form.ControlBox = false;
            tabControl1.Controls.Add(tp);
            addTab(tp, form);
            tabControl1.SelectedTab = tp;
        }

        private void addTab(TabPage tp, Form f)
        {

            f.TopLevel = false;
            //no border if needed
            f.FormBorderStyle = FormBorderStyle.None;
            f.AutoScaleMode = AutoScaleMode.Dpi;
            f.AutoScroll = true;
            if (!tp.Controls.Contains(f))
            {
                tp.AutoScroll = true;
                tp.Controls.Add(f);
                f.Dock = DockStyle.Fill;
                f.Show();
                Refresh();
            }
            Refresh();
        }
        private void setAuthorization()
        {
            foreach (Control item in this.advancedFlowLayoutPanel1.Controls)
                foreach (var item1 in item.Controls)
                    if (item1 is Button)
                        if (((System.Windows.Forms.Control)item1).Tag == null || permissionDT.Select("formTag='" + ((System.Windows.Forms.Control)item1).Tag + "'").Length == 0)
                            ((System.Windows.Forms.Control)item1).Visible = false;
        }
        private void clickButton(object sender, EventArgs e)
        {
            var button = sender as Button;
            runForm(button.Tag.ToString());
        }


        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private void tabControl1_OnClose(object sender, CloseEventArgs e)
        {

            this.tabControl1.Controls.Remove(this.tabControl1.TabPages[e.TabIndex]);
        }
        public DataTable permissionDT { get; set; }
    }
}
