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
using System.Windows.Controls;
using System.Windows.Forms;
using RestSharp;
using common.DataModel;


namespace nikanClient
{
    public partial class Form2 : Form
    {
        TreeNode _selectedNode = null;
        string httpUrl;
        DataTable _ProductGroupDB = null;
        int _parent = -1;
        bool _newNode, _thisLevel, _update, _delete = false;
        bool _createParent = false;
        string fullCode = "";
        int codeLen = 3;
        public Form2()
        {
            InitializeComponent();
            httpUrl = new Classes.configClass().BaseUriGet();
            _newNode = _thisLevel = _update = false;
        }
        private void createRoot()
        {
            _selectedNode = treeView1.SelectedNode;
            if (_ProductGroupDB != null && _ProductGroupDB.Rows.Count > 0)
            {
                if (treeView1.SelectedNode == null)
                {
                    MessageBox.Show("Select A Node");
                    return;
                }
                _parent = int.Parse(_ProductGroupDB.Rows[int.Parse(_selectedNode.Tag.ToString())]["parentId"].ToString());
            }
            _createParent = true;
            _update = false;
            _newNode = true;
            _thisLevel = true;
            txtName.Focus();
            txtNewCode.Text = "000";
            txtNewName.Text = "Product Tree";
            saveTree();
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            loadTreeView();
        }
        private void loadTreeView()
        {
            treeView1.Nodes.Clear();
            txtCode.Text = "";
            txtName.Text = "";
            txtNewCode.Text = "";
            txtNewName.Text = "";
            _ProductGroupDB = (DataTable)JsonConvert.DeserializeObject(getData(), (typeof(DataTable)));
            if (_ProductGroupDB.Rows.Count == 0)
                createRoot();
            else
                PopulateTreeView(-1, null);

        }
        private void PopulateTreeView(int parentId, TreeNode parentNode)
        {

            TreeNode childNode;

            foreach (DataRow dr in _ProductGroupDB.Select("[parentId]=" + parentId))
            {
                TreeNode t = new TreeNode();
                t.Text = dr["name"].ToString(); //+ " - " + dr["name"].ToString();
                t.Name = dr["code"].ToString();
                t.Tag = _ProductGroupDB.Rows.IndexOf(dr);
                if (parentNode == null)
                {
                    treeView1.Nodes.Add(t);
                    childNode = t;
                }
                else
                {
                    parentNode.Nodes.Add(t);
                    childNode = t;
                }
                PopulateTreeView(Convert.ToInt32(dr["Id"].ToString()), childNode);
            }
            for (int i = 0; i < treeView1.Nodes.Count; i++)
                treeView1.Nodes[i].ExpandAll();
        }

        private string getData()
        {
            HttpWebRequest httpWebRequest;
            httpWebRequest = (HttpWebRequest)WebRequest.Create(httpUrl + "productGroups/productGroupsGet");
            httpWebRequest.Method = "GET";
            try
            {
                WebResponse httpResponse = httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    return streamReader.ReadToEnd();
                }
            }
            catch (Exception exc)
            {
                //Logger.Instance.WriteError("Error", exc.Message, exc);
                return "";
            }
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            _selectedNode = treeView1.SelectedNode;
            ShowNodeData(_selectedNode);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            btnSave.Enabled = false;
            txtNewCode.Enabled = false;
            txtNewName.Enabled = false;
            treeView1.Enabled = true;
            btnCancel.Enabled = false;
            txtNewCode.Text = txtCode.Text;
            txtNewName.Text = txtName.Text;
        }

        private void btnCreateChild_Click(object sender, EventArgs e)
        {
            if (_ProductGroupDB == null || _ProductGroupDB.Rows.Count == 0)
                return;
            if (treeView1.SelectedNode == null)
            {
                MessageBox.Show("Select A Node");
                return;
            }
            txtNewCode.Enabled = true;
            txtNewName.Enabled = true;
            treeView1.Enabled = false;
            btnSave.Enabled = true;
            btnCancel.Enabled = true;

            _update = false;
            _newNode = true;
            _thisLevel = false;
            _selectedNode = treeView1.SelectedNode;
            DataRow r = _ProductGroupDB.Rows[int.Parse(treeView1.SelectedNode.Tag.ToString())];
            string code = string.Empty;
            _parent = int.Parse(_ProductGroupDB.Rows[int.Parse(_selectedNode.Tag.ToString())]["Id"].ToString());

            //if (_selectedNode.Nodes.Count > 0)
            //{

            //    DataRow[] nodes = _ProductGroupDB.Select("[parentId]=" + _parent);
            //    int max = 0;
            //    foreach (DataRow ra in nodes)
            //    {
            //        int n = int.Parse(ra["code"].ToString());
            //        if (n > max)
            //            max = n;

            //    }
            //    max += 1;
            //    txtNewCode.Text = max.ToString();
            //    code = max.ToString();
            //}
            //else
            //    code = "1".PadRight(_selectedNode.Level + 2, '0');
            //txtNewCode.Text = code;
            txtName.Focus();
            txtNewCode.Text = "";
            txtNewName.Text = "";
        }

        private void btnEditName_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode == null)
            {
                MessageBox.Show("Select A Node");
                return;
            }
            if (_ProductGroupDB == null || _ProductGroupDB.Rows.Count == 0 || treeView1.SelectedNode.Tag.ToString() == "0")
                return;
            _update = true;
            _selectedNode = treeView1.SelectedNode;
            txtNewCode.Text = txtCode.Text;
            txtNewName.Text = txtName.Text;
            txtNewCode.Enabled = true;
            txtNewName.Enabled = true;
            treeView1.Enabled = false;
            btnSave.Enabled = true;
            btnCancel.Enabled = true;
            DataRow r = _ProductGroupDB.Rows[int.Parse(treeView1.SelectedNode.Tag.ToString())];
            _newNode = true;
            _thisLevel = false;
            string code = string.Empty;
            _parent = int.Parse(_ProductGroupDB.Rows[int.Parse(_selectedNode.Tag.ToString())]["parentId"].ToString());
            //txtCode.Text = r["code"].ToString().Trim() + code;
            txtName.Focus();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNewName.Text) || string.IsNullOrWhiteSpace(txtNewName.Text) ||
                    string.IsNullOrEmpty(txtNewCode.Text) || string.IsNullOrWhiteSpace(txtNewCode.Text))
            {
                MessageBox.Show(" Code and Name Can not be empty", "Code - Name", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtName.Focus();
                return;
            }
            if (txtNewCode.Text.Trim().Length != 3)
            {
                MessageBox.Show("Code must be 3 digits");
                return;
            }
            if (_ProductGroupDB.Rows.Count > 0 && _ProductGroupDB.Select("code=" + txtNewCode.Text).Length > 0 && !_update && !_delete)
            {
                MessageBox.Show(" Riplicate Code ", "Code", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtName.Focus();
                return;
            }
            saveTree(_update || _delete ? int.Parse(_ProductGroupDB.Rows[int.Parse(_selectedNode.Tag.ToString())]["id"].ToString()) : -1);
            for (int i = 0; i < treeView1.Nodes.Count; i++)
                treeView1.Nodes[i].ExpandAll();
            btnSave.Enabled = false;
            btnCancel.Enabled = false;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (_ProductGroupDB == null || _ProductGroupDB.Rows.Count == 0 || treeView1.SelectedNode.Tag.ToString() == "0")
                return;
            _delete = true;
            txtNewCode.Text = txtCode.Text;
            txtNewName.Text = txtName.Text;
            treeView1.Enabled = false;
            btnSave.Enabled = true;
            btnCancel.Enabled = true;
        }

        private void saveTree(int id = -1)
        {
            productGroup pg = new productGroup();
            pg.id = id;
            pg.code = txtNewCode.Text.Trim();
            pg.name = txtNewName.Text;
            if (_delete)
                pg.parentId = -3;
            else
                pg.parentId = _update ? -2 : _parent;
            pg.levelNo = _selectedNode == null ? 0 : _selectedNode.Level;
            pg.active = 0;
            if ((_update || _createParent) && fullCode.Trim().Length >= codeLen)
                fullCode = fullCode.Trim().Substring(0, fullCode.Trim().Length - codeLen);
            pg.fullCode = fullCode.Trim() + txtNewCode.Text.Trim();

            byte[] dataStream = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(pg));
            HttpWebRequest httpWebRequest;
            httpWebRequest = (HttpWebRequest)WebRequest.Create(httpUrl + "productGroups/productGroupsUpdate");
            httpWebRequest.Method = "POST";
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.ContentLength = dataStream.Length;
            Stream newStream = httpWebRequest.GetRequestStream();
            newStream.Write(dataStream, 0, dataStream.Length);
            newStream.Close();
            try
            {
                var httpResponseStock = (HttpWebResponse)httpWebRequest.GetResponse();
                //using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                //{
                //    return streamReader.ReadToEnd();
                //}
            }
            catch (Exception exc)
            {
                //Logger.Instance.WriteError("Error", exc.Message, exc);
            }
            loadTreeView();
            txtNewCode.Enabled = false;
            txtNewName.Enabled = false;
            treeView1.Enabled = true;
            _delete = false;
            _createParent = false;
        }
        private void ShowNodeData(TreeNode nod)
        {
            DataRow r = _ProductGroupDB.Rows[int.Parse(nod.Tag.ToString())];
            txtNewCode.Text = r["code"].ToString();
            txtCode.Text = txtNewCode.Text;
            txtName.Text = r["name"].ToString();
            txtName.Focus();
            fullCode = "";
            txtNewName.Text = txtName.Text;
            while (nod != null)
            {
                fullCode = r["code"].ToString().Trim() + fullCode;
                nod = nod.Parent;
                if (nod != null)
                    r = _ProductGroupDB.Rows[int.Parse(nod.Tag.ToString())];
            }
        }
        public void updateData()
        {
            MessageBox.Show("2");
        }
    }
}
