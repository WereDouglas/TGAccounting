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
    public partial class DataForm : Form
    {
        DataTable idt, sdt;
        DateTime pStart, pEnd;
        public DataForm()
        {
            InitializeComponent();
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            TabPage current = (sender as TabControl).SelectedTab;
            string tab = current.Name.ToString();
            switch (tab)
            {
                case "laborTab":
                    string query = "SELECT * FROM labor";

                    break;

                case "saleTab":
                    LoadSales(pStart, pEnd);

                    break;
                case "tabTax":
                    string query3 = "SELECT * FROM taxes";

                    break;
                case "tabSupply":
                    string query4 = "SELECT * FROM supplies";

                    break;
                case "tabEq":
                    string query5 = "SELECT * FROM equipment";

                    break;
                case "tabRm":
                    string query6 = "SELECT * FROM repair";

                    break;
                case "tabInventory":

                    //string query7 = "SELECT * FROM inventory WHERE ";
                    // this.InventoryBindingSource.DataSource = Inventory.List(query7);
                    // reportViewerInventory.RefreshReport();
                    break;
                case "tabExpense":
                    //autocompleteCateg();
                    string query8 = "SELECT * FROM expense";

                    break;
                case "tabCogs":
                    //autocompleteCateg();
                    string query9 = "SELECT * FROM cogs";

                    break;
                case "tabCalendar":
                    //autocompleteCateg();

                    break;
            }
        }

        private void saleGrid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (String.IsNullOrEmpty(saleGrid.Rows[e.RowIndex].Cells["id"].Value.ToString()))
            {

                MessageBox.Show("Invalid entry");
                return;

            }
            Sale _c = new Sale(saleGrid.Rows[e.RowIndex].Cells["id"].Value.ToString(), saleGrid.Rows[e.RowIndex].Cells["date"].Value.ToString(), saleGrid.Rows[e.RowIndex].Cells["week"].Value.ToString(), saleGrid.Rows[e.RowIndex].Cells["starting"].Value.ToString(), saleGrid.Rows[e.RowIndex].Cells["ending"].Value.ToString(), saleGrid.Rows[e.RowIndex].Cells["item"].Value.ToString(), Convert.ToDouble(saleGrid.Rows[e.RowIndex].Cells["amount"].Value), saleGrid.Rows[e.RowIndex].Cells["category"].Value.ToString());
            DBConnect.Update(_c, saleGrid.Rows[e.RowIndex].Cells["id"].Value.ToString());
            //Global.payments.RemoveAll(x => x.Id == dtGrid.Rows[e.RowIndex].Cells["id"].Value.ToString());
            //Global.payments.Add(_c);
        }

        private void tabControl1_TabIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void LoadSales(DateTime start, DateTime end)
        {
            sdt = new DataTable();
            sdt.Columns.Add("id", typeof(string));
            sdt.Columns.Add("Item", typeof(string));
            sdt.Columns.Add("Amount", typeof(string));
            sdt.Columns.Add("Week");
            sdt.Columns.Add("Starting");
            sdt.Columns.Add("Ending");
            sdt.Columns.Add("Date");
            sdt.Columns.Add("Category");
            sdt.Columns.Add("Delete");
            string query = "SELECT * FROM sale";
            foreach (Sale w in Sale.List(query))
            {
                sdt.Rows.Add(new object[] { w.Id, w.Item, w.Amount, w.Week, w.Starting, w.Ending, w.Date, w.Category, "Delete" });
            }
            saleGrid.DataSource = sdt;
            saleGrid.Columns["id"].Visible = false;
            saleGrid.Columns["Delete"].DefaultCellStyle.BackColor = Color.Red;
            // saleGrid.Columns["Delete"].Width = 50;
        }
        private void saleGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == saleGrid.Columns["delete"].Index && e.RowIndex >= 0)
            {
                if (MessageBox.Show("YES or NO?", "Are you sure you want to delete? ", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    string Query = "DELETE from sale WHERE id ='" + saleGrid.Rows[e.RowIndex].Cells["id"].Value.ToString() + "'";
                    DBConnect.save(Query);

                    MessageBox.Show("Information deleted");
                    LoadSales(pStart, pEnd);
                }
            }
        }
    }
}
