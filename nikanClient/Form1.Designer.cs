namespace nikanClient
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.id = new DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.expandCollapseButton2 = new MakarovDev.ExpandCollapsePanel.ExpandCollapseButton();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.dataGridView_withQuery1 = new DataGridView_withQuery.DataGridView_withQuery();
            this.dataGridViewTextBoxColumn1 = new DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn();
            this.Id1 = new DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.filterStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.showAllLabel = new System.Windows.Forms.ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_withQuery1)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.name});
            this.dataGridView1.Location = new System.Drawing.Point(6, 78);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(388, 94);
            this.dataGridView1.TabIndex = 2;
            // 
            // id
            // 
            this.id.DataPropertyName = "id";
            this.id.HeaderText = "id";
            this.id.Name = "id";
            this.id.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.id.Visible = false;
            this.id.Width = 50;
            // 
            // name
            // 
            this.name.DataPropertyName = "name";
            this.name.HeaderText = "name";
            this.name.Name = "name";
            this.name.Width = 200;
            // 
            // name1
            // 
            this.name1.DataPropertyName = "name";
            this.name1.HeaderText = "Name";
            this.name1.MinimumWidth = 22;
            this.name1.Name = "name1";
            this.name1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // name2
            // 
            this.name2.DataPropertyName = "name";
            this.name2.HeaderText = "Name";
            this.name2.Name = "name2";
            // 
            // expandCollapseButton2
            // 
            this.expandCollapseButton2.ButtonSize = MakarovDev.ExpandCollapsePanel.ExpandCollapseButton.ExpandButtonSize.Normal;
            this.expandCollapseButton2.ButtonStyle = MakarovDev.ExpandCollapsePanel.ExpandCollapseButton.ExpandButtonStyle.Circle;
            this.expandCollapseButton2.IsExpanded = false;
            this.expandCollapseButton2.Location = new System.Drawing.Point(508, 274);
            this.expandCollapseButton2.MaximumSize = new System.Drawing.Size(0, 40);
            this.expandCollapseButton2.Name = "expandCollapseButton2";
            this.expandCollapseButton2.Size = new System.Drawing.Size(0, 8);
            this.expandCollapseButton2.TabIndex = 5;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 331);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "Search1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(86, 331);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 7;
            this.button2.Text = "Search2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // dataGridView_withQuery1
            // 
            this.dataGridView_withQuery1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_withQuery1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.Id1});
            this.dataGridView_withQuery1.Location = new System.Drawing.Point(8, 182);
            this.dataGridView_withQuery1.Name = "dataGridView_withQuery1";
            this.dataGridView_withQuery1.SearchFormTitle = "";
            this.dataGridView_withQuery1.Size = new System.Drawing.Size(362, 150);
            this.dataGridView_withQuery1.TabIndex = 8;
            this.dataGridView_withQuery1.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dataGridView_withQuery1_DataBindingComplete);
            this.dataGridView_withQuery1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGridView_withQuery1_KeyDown);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "name";
            this.dataGridViewTextBoxColumn1.HeaderText = "Name";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // Id1
            // 
            this.Id1.DataPropertyName = "Id";
            this.Id1.HeaderText = "Id";
            this.Id1.Name = "Id1";
            this.Id1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.filterStatusLabel,
            this.showAllLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 531);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(500, 22);
            this.statusStrip1.TabIndex = 9;
            this.statusStrip1.Text = "statusStrip1";
            this.statusStrip1.Visible = false;
            // 
            // filterStatusLabel
            // 
            this.filterStatusLabel.Name = "filterStatusLabel";
            this.filterStatusLabel.Size = new System.Drawing.Size(0, 17);
            this.filterStatusLabel.Visible = false;
            // 
            // showAllLabel
            // 
            this.showAllLabel.Name = "showAllLabel";
            this.showAllLabel.Size = new System.Drawing.Size(53, 17);
            this.showAllLabel.Text = "Show &All";
            this.showAllLabel.Click += new System.EventHandler(this.showAllLabel_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 553);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.dataGridView_withQuery1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.expandCollapseButton2);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form1";
            this.Text = "Units ";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Controls.SetChildIndex(this.dataGridView1, 0);
            this.Controls.SetChildIndex(this.expandCollapseButton2, 0);
            this.Controls.SetChildIndex(this.button1, 0);
            this.Controls.SetChildIndex(this.button2, 0);
            this.Controls.SetChildIndex(this.dataGridView_withQuery1, 0);
            this.Controls.SetChildIndex(this.statusStrip1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_withQuery1)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn name1;
        private System.Windows.Forms.DataGridViewTextBoxColumn name2;
        private MakarovDev.ExpandCollapsePanel.ExpandCollapseButton expandCollapseButton2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private DataGridView_withQuery.DataGridView_withQuery dataGridView_withQuery1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel showAllLabel;
        private System.Windows.Forms.ToolStripStatusLabel filterStatusLabel;
        private DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn Id1;
    }
}

