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
    public partial class ChartForm : Form
    {
        public ChartForm()
        {
            InitializeComponent();
        }

        private void ChartForm_Load(object sender, EventArgs e)
        {

            //this.reportViewer1.RefreshReport();
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            TabPage current = (sender as TabControl).SelectedTab;
            string tab = current.Name.ToString();
            switch (tab)
            {
                            
                    
                case "tabInventory":
                    autocompleteCategory();
                    //string query7 = "SELECT * FROM inventory WHERE ";
                    // this.InventoryBindingSource.DataSource = Inventory.List(query7);
                    // reportViewerInventory.RefreshReport();
                    break;
                case "tabExpense":
                    //autocompleteCateg();
                    string query8 = "SELECT * FROM expense WHERE date = '" + Helper.CurrentYear + "'";
                    this.ExpenseBindingSource.DataSource = Expense.List(query8);
                  //  reportViewerExpense.RefreshReport();
                    break;
              

            }

        }
        private void autocompleteCategory()
        {
            //categoryCbx.Items.Clear();
            //AutoCompleteStringCollection AutoItem = new AutoCompleteStringCollection();
            //foreach (var r in Inventory.ListCategory("SELECT DISTINCT category from inventory "))
            //{
            //    AutoItem.Add(r);
            //    categoryCbx.Items.Add(r);
            //}
            //categoryCbx.AutoCompleteMode = AutoCompleteMode.Suggest;
            //categoryCbx.AutoCompleteSource = AutoCompleteSource.CustomSource;
            //categoryCbx.AutoCompleteCustomSource = AutoItem;


        }
        List<Profit> pr = new List<Profit>();
        private void button21_Click(object sender, EventArgs e)
        {
            reportViewer7.RefreshReport();
            Profit r = new Profit();
            int week = Convert.ToInt32(Convert.ToInt32(maxWeeksTxt.Text));
            string year = Helper.CurrentYear;
            string date = "";
            pr = new List<Profit>();
            double totalPayRoll = 0;
            double totalCogs = 0;
            double totalComps = 0;
            double totalSales = 0;
            double totalTaxes = 0;
            double totalEquip = 0;
            
            for (int x = 1; x <= week; x++)
            {
                DateTime startWeek = Helper.FirstDateOfWeek(Convert.ToInt32(Helper.CurrentYear), x - 1);
                string ending = startWeek.AddDays(7).ToString("dd-MM-yyyy");
                string month = startWeek.AddDays(7).ToString("MMMM");
                totalSales = Sale.List("SELECT * FROM sale  WHERE week ='" + x + "'  AND date= '" + Helper.CurrentYear + "'").Sum(t => t.Amount);
                totalCogs = Cogs.List("SELECT * FROM cogs  WHERE week ='" + x + "'  AND date= '" + Helper.CurrentYear + "' ").Sum(t => t.Cost);
                totalComps = Comp.List("SELECT * FROM comp  WHERE week ='" + x + "'  AND date= '" + Helper.CurrentYear + "'").Sum(t => t.Amount);
                double Gross = totalSales - (totalCogs + totalComps);
                double totalLabor = Labor.List("SELECT * FROM labor  WHERE week ='" + x + "'  AND date= '" + Helper.CurrentYear + "' ").Sum(t => t.Amount);
                totalTaxes = Taxes.List("SELECT * FROM taxes  WHERE week ='" + x + "'   AND date= '" + Helper.CurrentYear + "' ").Sum(t => t.Amount);
                totalPayRoll = totalTaxes + totalLabor;
                double prime = totalCogs + totalComps + totalPayRoll;
                double totalSupplies = Supplies.List("SELECT * FROM supplies  WHERE week ='" + x + "' AND date= '" + Helper.CurrentYear + "' ").Sum(t => t.Amount);
                double totalRepair = Repair.List("SELECT * FROM repair  WHERE week ='" + x + "' AND date= '" + Helper.CurrentYear + "' ").Sum(t => t.Amount);
                double totalVariable = Expense.List("SELECT * FROM expense  WHERE week ='" + x + "' AND date= '" + Helper.CurrentYear + "' AND category<>'Occupancy Expenses'").Sum(t => t.Amount);
                double ctrl = totalPayRoll + totalVariable + totalSupplies + totalRepair;
                double ctrlProfit = Gross - ctrl;
                double occupancyExpense = Expense.List("SELECT * FROM expense  WHERE week ='" + x + "' AND category='Occupancy Expenses'  AND date= '" + Helper.CurrentYear + "' ").Sum(t => t.Amount);
                totalEquip = Equipment.List("SELECT * FROM equipment  WHERE week ='" + x + "' AND date= '" + Helper.CurrentYear + "' ").Sum(t => t.Amount);
                double restProfit = ctrlProfit - occupancyExpense - totalEquip;

                r = new Profit(Helper.CurrentYear, month, x, Convert.ToDateTime(ending).ToString("dd-MMM-yy"), totalSales, totalCogs, totalComps, Gross, totalPayRoll, prime, totalVariable, totalSupplies, totalRepair, ctrl, ctrlProfit, occupancyExpense, totalEquip, restProfit);
                pr.Add(r);

            }
            this.ProfitBindingSource.DataSource = pr;
            reportViewer7.RefreshReport();
        }
    }
}
