using MakarovDev.ExpandCollapsePanel;
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
    public partial class frmMainMenu : Form
    {
        public frmMainMenu()
        {
            InitializeComponent();
            this.tabControl1.OnClose += new MyControlLibrary.TabCtlEx.OnHeaderCloseDelegate(this.tabControl1_OnClose);
        }
        private void frmMainMenu_Load(object sender, EventArgs e)
        {
            //expandCollapsePanel11.co
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
            form.ControlBox = false;
            tabControl1.Controls.Add(tp);
            addTab(tp, form);
            tabControl1.SelectedTab = tp;
        }

        public void addTab(TabPage tp, Form f)
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

    }
}
