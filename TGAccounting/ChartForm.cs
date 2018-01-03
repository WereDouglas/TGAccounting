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

            this.reportViewer1.RefreshReport();
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            TabPage current = (sender as TabControl).SelectedTab;
            string tab = current.Name.ToString();
            switch (tab)
            {
                case "laborTab":
                    string query = "SELECT * FROM labor WHERE date= '" + Helper.CurrentYear + "'";
                    this.LaborBindingSource.DataSource = Labor.List(query);
                    reportViewer2.RefreshReport();
                    break;

                case "saleTab":
                    string query2 = "SELECT * FROM sale ";
                    this.SaleBindingSource.DataSource = Sale.List(query2);
                    reportViewer1.RefreshReport();
                    break;
                case "tabSalary":
                    string query10 = "SELECT * FROM salary WHERE date= '" + Helper.CurrentYear + "'";
                    this.SalaryBindingSource.DataSource = Salary.List();
                    reportViewerSalary.RefreshReport();
                    break;
                case "tabTax":
                    string query3 = "SELECT * FROM taxes WHERE date= '" + Helper.CurrentYear + "'";
                    this.TaxesBindingSource.DataSource = Taxes.List(query3);
                    reportViewer3.RefreshReport();
                    break;
                case "tabSupply":
                    string query4 = "SELECT * FROM supplies WHERE date= '" + Helper.CurrentYear + "'";
                    this.SuppliesBindingSource.DataSource = Supplies.List(query4);
                    reportViewerSupply.RefreshReport();
                    break;
                case "tabEq":
                    string query5 = "SELECT * FROM equipment WHERE date= '" + Helper.CurrentYear + "'";
                    this.EquipmentBindingSource.DataSource = Equipment.List(query5);
                    reportViewerEquipment.RefreshReport();
                    break;
                case "tabRm":
                    string query6 = "SELECT * FROM repair WHERE date= '" + Helper.CurrentYear + "'";
                    this.SuppliesBindingSource.DataSource = Repair.List(query6);
                    reportViewerRm.RefreshReport();
                    break;
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
                    reportViewerExpense.RefreshReport();
                    break;
                case "tabCogs":
                    //autocompleteCateg();
                    string query9 = "SELECT * FROM cogs ";
                    this.CogsBindingSource.DataSource = Cogs.List(query9);
                    reportViewer5.RefreshReport();
                    break;
                case "tabCalendar":
                    //autocompleteCateg();
                   
                    break;
                case "tabComp":
                    //autocompleteCateg();
                    string query19 = "SELECT * FROM comp";
                    this.SaleBindingSource.DataSource = Comp.List(query19);
                    reportViewer6.RefreshReport();
                    break;

            }

        }
        private void autocompleteCategory()
        {
            categoryCbx.Items.Clear();
            AutoCompleteStringCollection AutoItem = new AutoCompleteStringCollection();
            foreach (Inventory r in Inventory.List("SELECT * from inventory").GroupBy(x => x.Category, (key, group) => group.First()))
            {
                AutoItem.Add(r.Category);
                categoryCbx.Items.Add(r.Category);
            }
            categoryCbx.AutoCompleteMode = AutoCompleteMode.Suggest;
            categoryCbx.AutoCompleteSource = AutoCompleteSource.CustomSource;
            categoryCbx.AutoCompleteCustomSource = AutoItem;


        }
    }
}
