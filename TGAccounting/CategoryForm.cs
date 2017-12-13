using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TGAccounting.Model;

namespace TGAccounting
{
    public partial class CategoryForm : Form
    {
        DataTable t = new DataTable();
        public CategoryForm()
        {
            InitializeComponent();
            LoadData();
        }
        private void LoadData()
        {

            t = new DataTable();
            t.Columns.Add("id", typeof(string));            
            t.Columns.Add("Name", typeof(string));//3
            t.Columns.Add("Description");//2
         
            
            t.Columns.Add("Delete");  //9 

            foreach (Category w in Category.List())
            {
                t.Rows.Add(new object[] { w.Id, w.Name, w.Description,"Delete" });

           }
            dtGrid.DataSource = t;
            dtGrid.Columns["id"].Visible = false;           
            dtGrid.Columns["Delete"].DefaultCellStyle.BackColor = Color.Red;
        }
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            using (AddCategory form = new AddCategory())
            {
                DialogResult dr = form.ShowDialog();
                if (dr == DialogResult.OK)
                {                   
                    LoadData();

                }
            }
        }

        private void dtGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dtGrid.Columns["delete"].Index && e.RowIndex >= 0)
            {
                if (MessageBox.Show("YES or NO?", "Are you sure you want to delete? ", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    string Query = "DELETE from category WHERE id ='" + dtGrid.Rows[e.RowIndex].Cells["id"].Value.ToString() + "'";
                    DBConnect.save(Query);

                    MessageBox.Show("Information deleted");
                    LoadData();
                }
            }
        }

        private void dtGrid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (string.IsNullOrEmpty(dtGrid.Rows[e.RowIndex].Cells["id"].Value.ToString()))
            {

                MessageBox.Show("Invalid entry");
                return;

            }
            Category _c = new Category(dtGrid.Rows[e.RowIndex].Cells["id"].Value.ToString(), dtGrid.Rows[e.RowIndex].Cells["name"].Value.ToString(), dtGrid.Rows[e.RowIndex].Cells["description"].Value.ToString());
            DBConnect.Update(_c, dtGrid.Rows[e.RowIndex].Cells["id"].Value.ToString());

        }
    }
}
