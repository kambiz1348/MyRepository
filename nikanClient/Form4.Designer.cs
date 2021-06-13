namespace nikanClient
{
    partial class Form4
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.dataGridView_withQuery1 = new DataGridView_withQuery.DataGridView_withQuery();
            this.dataGridViewTextBoxColumn1 = new DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn();
            this.Id1 = new DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_withQuery1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(169, 119);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Unit Name :";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(239, 116);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(221, 21);
            this.txtName.TabIndex = 2;
            // 
            // dataGridView_withQuery1
            // 
            this.dataGridView_withQuery1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_withQuery1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.Id1});
            this.dataGridView_withQuery1.Location = new System.Drawing.Point(171, 213);
            this.dataGridView_withQuery1.Name = "dataGridView_withQuery1";
            this.dataGridView_withQuery1.SearchFormTitle = "";
            this.dataGridView_withQuery1.Size = new System.Drawing.Size(235, 149);
            this.dataGridView_withQuery1.TabIndex = 9;
            this.dataGridView_withQuery1.Visible = false;
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
            // Form4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dataGridView_withQuery1);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label1);
            this.Name = "Form4";
            this.Load += new System.EventHandler(this.Form4_Load);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.txtName, 0);
            this.Controls.SetChildIndex(this.dataGridView_withQuery1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_withQuery1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtName;
        private DataGridView_withQuery.DataGridView_withQuery dataGridView_withQuery1;
        private DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn Id1;
    }
}
