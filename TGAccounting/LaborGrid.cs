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
    public partial class LaborGrid : Form
    {
        DataTable t;
        DateTime pStart, pEnd;
        public LaborGrid()
        {
            InitializeComponent();
            pStart = DateTime.Now;
            pEnd = DateTime.Now;
            LoadData(pStart, pEnd);
        }

        private void dtGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dtGrid.Columns["delete"].Index && e.RowIndex >= 0)
            {
                if (MessageBox.Show("YES or NO?", "Are you sure you want to delete? ", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    string Query = "DELETE from labor WHERE id ='" + dtGrid.Rows[e.RowIndex].Cells["id"].Value.ToString() + "'";
                    DBConnect.save(Query);

                    MessageBox.Show("Information deleted");
                    LoadData(pStart, pEnd);
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
            Labor _c = new Labor(dtGrid.Rows[e.RowIndex].Cells["id"].Value.ToString(), dtGrid.Rows[e.RowIndex].Cells["date"].Value.ToString(), dtGrid.Rows[e.RowIndex].Cells["week"].Value.ToString(), dtGrid.Rows[e.RowIndex].Cells["starting"].Value.ToString(), dtGrid.Rows[e.RowIndex].Cells["ending"].Value.ToString(), dtGrid.Rows[e.RowIndex].Cells["department"].Value.ToString(), Convert.ToDouble(dtGrid.Rows[e.RowIndex].Cells["amount"].Value));
            DBConnect.Update(_c, dtGrid.Rows[e.RowIndex].Cells["id"].Value.ToString());

        }

        private void button7_Click(object sender, EventArgs e)
        {
            using (AddLabor form = new AddLabor())
            {
                DialogResult dr = form.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    LoadData(pStart, pEnd);
                }
            }
        }

        private void LoadData(DateTime start, DateTime end)
        {
            t = new DataTable();
            t.Columns.Add("id", typeof(string));
            t.Columns.Add("Department", typeof(string));
            t.Columns.Add("Amount", typeof(string));
            t.Columns.Add("Week");
            t.Columns.Add("Starting");
            t.Columns.Add("Ending");
            t.Columns.Add("Date");
            t.Columns.Add("Delete");
            string query = "SELECT * FROM labor";
            foreach (Labor w in Labor.List(query))
            {
                t.Rows.Add(new object[] { w.Id, w.Item, w.Amount, w.Week, w.Starting, w.Ending, w.Date, "Delete" });
            }
            dtGrid.DataSource = t;
            dtGrid.Columns["id"].Visible = false;
            dtGrid.Columns["Delete"].DefaultCellStyle.BackColor = Color.Red;
            // dtGrid.Columns["Delete"].Width = 50;
        }
    }
}
