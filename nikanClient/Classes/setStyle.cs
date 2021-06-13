using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace nikanClient.Classes
{
    public class setStyle
    {
        public void gridStyle(DataGridView dataGridView1)
        {
            dataGridView1.RowsDefaultCellStyle.BackColor = Color.Bisque;
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.Beige;
            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.None;

            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.Red;
            dataGridView1.DefaultCellStyle.SelectionForeColor = Color.Yellow;

            dataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dataGridView1.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.AllowUserToResizeColumns = false;

        }
    }
}
