using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TGAccounting;
using TGAccounting.Model;
using WindowsFormsCalendar;

namespace TGAccounting
{
    public partial class HomeForm : Form
    {
        DataTable idt, sdt;
        DateTime pStart, pEnd;
        private List<CalendarItem> _items = new List<CalendarItem>();
       
        Events _event;

        public HomeForm()
        {
            Global.LoadData();
            InitializeComponent();
            
            LoadingCalendarLite();
          

            var culture = new CultureInfo("en-US");
            CultureInfo.DefaultThreadCurrentCulture = culture;
            CultureInfo.DefaultThreadCurrentUICulture = culture;

            pStart = DateTime.Now;
            pEnd = DateTime.Now;

            LoadItems();
            LoadSales(pStart, pEnd);
        }
        /**sales list of items*/
        private void LoadItems()
        {
            idt = new DataTable();
            idt.Columns.Add("id", typeof(string));
            idt.Columns.Add("Name", typeof(string));
            idt.Columns.Add("Category", typeof(string));
            idt.Columns.Add("Description");
            idt.Columns.Add("Delete");
            foreach (Items w in Items.List())
            {
                idt.Rows.Add(new object[] { w.Id, w.Name, w.Category, w.Description, "Delete" });
            }
            itemGrid.DataSource = idt;
            itemGrid.Columns["id"].Visible = false;
            //itemGrid.Columns["Delete"].DefaultCellStyle.BackColor = Color.Red;
        }
        public static List<Events> events;
        private void LoadingCalendarLite()
        {
            Global.LoadData();
            _items.Clear();
            List<ItemInfo> lst = new List<ItemInfo>();
            string state = "";

            List<Events> events = new List<Events>(Global.events);

            foreach (Events e in events)
            {
                try
                {
                    CalendarItem cal = new CalendarItem(calendar1, Convert.ToDateTime(e.Starts), Convert.ToDateTime(e.Ends), e.Users + " " + e.Users + " " + e.Contact + ""  + e.Details);

                    if (e.Priority == " ")
                    {
                        state = "none";
                    }
                    else
                    {
                        state = e.Priority;
                    }
                    if (state == "Medium") { cal.ApplyColor(Color.LightGreen); }
                    if (state == "Low") { cal.ApplyColor(Color.CornflowerBlue); }
                    if (state == "High") { cal.ApplyColor(Color.Salmon); }
                    if (state == "none") { cal.ApplyColor(Color.LightSeaGreen); }
                    
                        _items.Add(cal);
                    
                    // t.Rows.Add(new object[] { Reader.GetString(0), Helper.ImageFolder + Reader.GetString(8), b, Reader.GetString(2), Reader.GetString(3), Reader.GetString(7), Reader.GetString(5), Reader.GetString(9), Reader.GetString(14) + "", Reader.GetString(6), "" + Reader.GetString(13) + "" });
                }
                catch { }
            }
            PlaceItems();

        }
        private void PlaceItems()
        {
            calendar1.Items.Clear();
            foreach (CalendarItem item in _items)
            {
                if (calendar1.ViewIntersects(item))
                {
                    if (!calendar1.Items.Contains(item))
                    {
                        calendar1.Items.Add(item);
                    }
                }
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {

            using (AddItem form = new AddItem())
            {
                DialogResult dr = form.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    tabControl1.SelectedTab = itemTab;
                    LoadItems();
                }
            }
        }
        /**End of item section*/
        /***Sales section***/
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
                sdt.Rows.Add(new object[] { w.Id, w.Item, w.Amount, w.Week, w.Starting, w.Ending, w.Date,w.Category, "Delete" });
            }
            saleGrid.DataSource = sdt;
            saleGrid.Columns["id"].Visible = false;
            saleGrid.Columns["Delete"].DefaultCellStyle.BackColor = Color.Red;
            // saleGrid.Columns["Delete"].Width = 50;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = salesTab;
            using (AddSale form = new AddSale())
            {
                DialogResult dr = form.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    tabControl1.SelectedTab = salesTab;
                    LoadSales(pStart, pEnd);

                }
            }
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

        /***End the Sales section***/
        private void button4_Click(object sender, EventArgs e)
        {
            using (CategoryForm form = new CategoryForm())
            {
                DialogResult dr = form.ShowDialog();
                if (dr == DialogResult.OK)
                {


                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (DepartmentForm form = new DepartmentForm())
            {
                DialogResult dr = form.ShowDialog();
                if (dr == DialogResult.OK)
                {


                }
            }
        }

        private void saleGrid_Click(object sender, EventArgs e)
        {

        }

        private void HomeForm_Load(object sender, EventArgs e)
        {

            string query2 = "SELECT * FROM sale";
            this.SaleBindingSource.DataSource = Sale.List(query2);
            reportViewer1.RefreshReport();

            this.reportViewer3.RefreshReport();
            this.reportViewerSupply.RefreshReport();
            this.reportViewerRm.RefreshReport();
            this.reportViewerEquipment.RefreshReport();
            this.reportViewerInventory.RefreshReport();
            this.reportViewerExpense.RefreshReport();
            this.reportViewer4.RefreshReport();
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            string query = "SELECT * FROM sale";
            this.SaleBindingSource.DataSource = Sale.List(query);
            reportViewer1.RefreshReport();
        }

        private void HomeForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            using (AddLabor form = new AddLabor())
            {
                DialogResult dr = form.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    tabControl1.SelectedTab = laborTab;
                    LoadItems();
                }
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            using (LaborGrid form = new LaborGrid())
            {
                DialogResult dr = form.ShowDialog();
                if (dr == DialogResult.OK)
                {

                }
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

            TabPage current = (sender as TabControl).SelectedTab;
            string tab = current.Name.ToString();
            switch (tab)
            {
                case "laborTab":
                    string query = "SELECT * FROM labor";
                    this.LaborBindingSource.DataSource = Labor.List(query);
                    reportViewer2.RefreshReport();
                    break;

                case "saleTab":
                    string query2 = "SELECT * FROM sale";
                    this.SaleBindingSource.DataSource = Sale.List(query2);
                    reportViewer1.RefreshReport();
                    break;
                case "tabTax":
                    string query3 = "SELECT * FROM taxes";
                    this.TaxesBindingSource.DataSource = Taxes.List(query3);
                    reportViewer3.RefreshReport();
                    break;
                case "tabSupply":
                    string query4 = "SELECT * FROM supplies";
                    this.SuppliesBindingSource.DataSource = Supplies.List(query4);
                    reportViewerSupply.RefreshReport();
                    break;
                case "tabEq":
                    string query5 = "SELECT * FROM equipment";
                    this.EquipmentBindingSource.DataSource = Equipment.List(query5);
                    reportViewerEquipment.RefreshReport();
                    break;
                case "tabRm":
                    string query6 = "SELECT * FROM repair";
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
                    string query8 = "SELECT * FROM expense";
                    this.ExpenseBindingSource.DataSource = Expense.List(query8);
                    reportViewerExpense.RefreshReport();
                    break;
                case "tabCogs":
                    //autocompleteCateg();
                    string query9 = "SELECT * FROM cogs";
                    this.CogsBindingSource.DataSource = Cogs.List(query9);
                    reportViewer5.RefreshReport();
                    break;
                case "tabCalendar":
                    //autocompleteCateg();
                    LoadingCalendarLite();
                    break;
            }
        }

        private void splitContainer2_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            using (AddTax form = new AddTax())
            {
                DialogResult dr = form.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    tabControl1.SelectedTab = tabTax;
                    
                }
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            using (AddSupply form = new AddSupply())
            {
                DialogResult dr = form.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    tabControl1.SelectedTab = tabSupply;
                    string query4 = "SELECT * FROM supplies";
                    this.SuppliesBindingSource.DataSource = Supplies.List(query4);
                    reportViewerSupply.RefreshReport();

                }
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            using (AddRm form = new AddRm())
            {
                DialogResult dr = form.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    tabControl1.SelectedTab = tabRm;                   
                    string query6 = "SELECT * FROM repair";
                    this.SuppliesBindingSource.DataSource = Repair.List(query6);
                    reportViewerRm.RefreshReport();

                }
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            using (AddEquipment form = new AddEquipment())
            {
                DialogResult dr = form.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    tabControl1.SelectedTab = tabSupply;
                    string query4 = "SELECT * FROM supplies";
                    this.SuppliesBindingSource.DataSource = Supplies.List(query4);
                    reportViewerSupply.RefreshReport();

                }
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabInventory;
            using (AddInventory form = new AddInventory())
            {
                DialogResult dr = form.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    tabControl1.SelectedTab = tabInventory;
                    string query4 = "SELECT * FROM inventory";
                    this.InventoryBindingSource.DataSource = Inventory.List(query4);
                    reportViewerInventory.RefreshReport();

                }
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

        private void categoryCbx_SelectedIndexChanged(object sender, EventArgs e)
        {
            string query7 = "SELECT * FROM inventory WHERE category='"+categoryCbx.Text+"' ";
            this.InventoryBindingSource.DataSource = Inventory.List(query7);
            reportViewerInventory.RefreshReport();
           
        }

        private void categoryCbx_SelectionChangeCommitted(object sender, EventArgs e)
        {

        }

        private void button14_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabExpense;
            using (AddExpense form = new AddExpense())
            {
                DialogResult dr = form.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    tabControl1.SelectedTab = tabExpense;
                    string query4 = "SELECT * FROM expense";
                    this.ExpenseBindingSource.DataSource = Expense.List(query4);
                    reportViewerExpense.RefreshReport();

                }
            }
        }
        List<Report> reports;
        private void button15_Click(object sender, EventArgs e)
        {
            Report r = new Report();
             int week = Convert.ToInt32(weekTxt.Text);
            string year = yearTxt.Text; string date = "";
            reports = new List<Report>();
            string ending = "";
                
            double totalPayRoll = 0;
            double totalPayRollYTD = 0;
            double totalCogs = 0;
            double totalCogsYTD = 0;
            double totalSales = 0;
            double totalSalesYTD = 0;
            double totalTaxes = 0;
            double totalTaxesYTD = 0;
            double totalExpenses = 0;
            double totalExpensesYTD = 0;

            double totalEquip = 0;
            double totalEquipYTD = 0;
            foreach (Taxes l in Taxes.List("SELECT * FROM taxes  WHERE week ='" + week + "' "))
            {
                double sums = Taxes.List("SELECT * FROM taxes  WHERE week ='" + week + "' ").Sum(t => t.Amount);
                double p1 = Math.Round((l.Amount / sums) * 100, 1);
                double ytd = Taxes.List("SELECT * FROM taxes  WHERE CAST(week AS INTEGER) <='" + week + "' AND name='" + l.Name + "' ").Sum(t => t.Amount);

                double p2 = Math.Round((l.Amount / sums) * 100, 1);
                r = new Report(l.Date, l.Week, l.Ending, "Employee Benefits", l.Name, l.Amount, p1, ytd, p2, "PAYROLL","EXPENSE");
                reports.Add(r);
                ending = l.Ending;
                date = l.Date;
                totalTaxes = totalTaxes + sums;
                totalTaxesYTD = totalTaxesYTD + ytd;

                totalPayRoll = totalPayRoll + sums;
                totalPayRollYTD = totalPayRollYTD + ytd;
            }          

            foreach (Labor l in Labor.List("SELECT * FROM labor  WHERE week ='" + week + "' "))
            {
                double sums = Labor.List("SELECT * FROM labor  WHERE week ='" + week + "' ").Sum(t => t.Amount);
                double p1 = Math.Round((l.Amount / sums) * 100,1);
                double ytd = Labor.List("SELECT * FROM labor  WHERE CAST(week AS INTEGER) <='" + week + "' AND item='" + l.Item + "' ").Sum(t => t.Amount);
                date = l.Date;
                double p2 = Math.Round((l.Amount / sums) * 100,1);
                r = new Report(l.Date, l.Week, l.Ending, "Salaries & Wages", l.Item, l.Amount, p1, ytd, p2, "PAYROLL", "EXPENSE");
                reports.Add(r);

                totalPayRoll = totalPayRoll + sums;
                totalPayRollYTD = totalPayRollYTD + ytd;
            }

            //r = new Report("", week, ending, "TOTAL PAYROLL", "TOTAL PAYROLL",totalPayRoll, p1, ytd, p2);
            // reports.Add(r);

            foreach (Sale s in Sale.List("SELECT * FROM sale  WHERE week ='" + week + "' "))
            {
                double sums = Sale.List("SELECT * FROM sale  WHERE week ='" + week + "' ").Sum(t => t.Amount);
                double p1 = Math.Round((s.Amount / sums) * 100, 1);
                double ytd = Sale.List("SELECT * FROM sale  WHERE CAST(week AS INTEGER) <='" + week + "'  AND item='"+s.Item+"' ").Sum(t => t.Amount);

                double p2 = Math.Round((s.Amount / sums) * 100, 1);
                r = new Report(s.Date, s.Week, s.Ending, "SALES", s.Item, s.Amount, p1, ytd, p2, "SALES", "INCOME");
                reports.Add(r);
                totalSales = totalSales + sums;
                totalSalesYTD = totalSalesYTD + ytd;
            }

            foreach (Cogs s in Cogs.List("SELECT * FROM cogs  WHERE week ='" + week + "' "))
            {
                double sums = Cogs.List("SELECT * FROM cogs  WHERE week ='" + week + "' ").Sum(t => t.Cost);
                double p1 = Math.Round((s.Cost / sums) * 100, 1);
                double ytd = Cogs.List("SELECT * FROM cogs  WHERE CAST(week AS INTEGER) <='" + week + "'  AND category='" + s.Category + "' ").Sum(t => t.Cost);

                double p2 = Math.Round((s.Cost / sums) * 100, 1);
                r = new Report(s.Date, s.Week, s.Ending, "COST OF GOODS SOLD", s.Category, s.Cost, p1, ytd, p2, "COST OF GOODS SOLD", "COST OF GOODS SOLD");
                reports.Add(r);
                totalCogs = totalCogs + sums;
                totalCogsYTD = totalCogsYTD + ytd;
            }
            foreach (Supplies s in Supplies.List("SELECT * FROM supplies  WHERE week ='" + week + "' "))
            {
                double sums = Supplies.List("SELECT * FROM supplies  WHERE week ='" + week + "' ").Sum(t => t.Amount);
                double p1 = Math.Round((s.Amount / sums) * 100, 1);
                double ytd = Supplies.List("SELECT * FROM supplies  WHERE CAST(week AS INTEGER) <='" + week + "'  AND supplier='" + s.Supplier + "' ").Sum(t => t.Amount);

                double p2 = Math.Round((s.Amount / sums) * 100, 1);
                r = new Report(s.Date, s.Week, s.Ending, "Supplies", s.Supplier, s.Amount, p1, ytd, p2, "Other Controllable Expenses", "EXPENSE");
                reports.Add(r);
                totalExpenses = totalExpenses + sums;
                totalExpensesYTD = totalExpensesYTD + ytd;
            }
            foreach (Expense s in Expense.List("SELECT * FROM expense  WHERE week ='" + week + "' "))
            {
                double sums = Expense.List("SELECT * FROM expense  WHERE week ='" + week + "' ").Sum(t => t.Amount);
                double p1 = Math.Round((s.Amount / sums) * 100, 1);
                double ytd = Expense.List("SELECT * FROM expense  WHERE CAST(week AS INTEGER) <='" + week + "'  AND name='" + s.Name + "' ").Sum(t => t.Amount);

                double p2 = Math.Round((s.Amount / sums) * 100, 1);
                r = new Report(s.Date, s.Week, s.Ending, s.Category, s.Name, s.Amount, p1, ytd, p2, "Other Controllable Expenses", "EXPENSE");
                reports.Add(r);
                totalExpenses = totalExpenses + sums;
                totalExpensesYTD = totalExpensesYTD + ytd;
            }
            foreach (Repair s in Repair.List("SELECT * FROM repair  WHERE week ='" + week + "' "))
            {
                double sums = Repair.List("SELECT * FROM repair  WHERE week ='" + week + "' ").Sum(t => t.Amount);
                double p1 = Math.Round((s.Amount / sums) * 100, 1);
                double ytd = Repair.List("SELECT * FROM repair  WHERE CAST(week AS INTEGER) <='" + week + "'  AND supplier='" + s.Supplier + "' ").Sum(t => t.Amount);

                double p2 = Math.Round((s.Amount / sums) * 100, 1);
                r = new Report(s.Date, s.Week, s.Ending, "Repair and maintenance", s.Supplier, s.Amount, p1, ytd, p2, "Other Controllable Expenses", "EXPENSE");
                reports.Add(r);
                totalExpenses = totalExpenses + sums;
                totalExpensesYTD = totalExpensesYTD + ytd;
            }
            foreach (Equipment s in Equipment.List("SELECT * FROM equipment  WHERE week ='" + week + "' "))
            {
                double sums = Equipment.List("SELECT * FROM equipment  WHERE week ='" + week + "' ").Sum(t => t.Amount);
                double p1 = Math.Round((s.Amount / sums) * 100, 1);
                double ytd = Equipment.List("SELECT * FROM equipment  WHERE CAST(week AS INTEGER) <='" + week + "'  AND name='" + s.Name + "' ").Sum(t => t.Amount);

                double p2 = Math.Round((s.Amount / sums) * 100, 1);
                r = new Report(s.Date, s.Week, s.Ending, "Equipment", s.Name, s.Amount, p1, ytd, p2,"Equipment", "EXPENSE");
                reports.Add(r);
                totalEquip = totalEquip + sums;
                totalEquipYTD = totalEquipYTD + ytd;

            }
            /**Computing the prime costs*/
             totalCogsYTD = Cogs.List("SELECT * FROM cogs  WHERE CAST(week AS INTEGER) <='" + week + "'").Sum(t => t.Cost);
             totalCogs = Cogs.List("SELECT * FROM cogs  WHERE CAST(week AS INTEGER) ='" + week + "'").Sum(t => t.Cost);

            double prime = totalCogs + totalPayRoll;
            double p1Prime = Math.Round((prime / totalSales) * 100, 1);
            double p2Prime = Math.Round((totalCogsYTD / totalSalesYTD) * 100, 1);

            r = new Report(date, weekTxt.Text, ending, "PRIME COST", "PRIME COST", prime , p1Prime, totalSalesYTD, p2Prime, "PRIME COST", "PRIME COST");
            reports.Add(r);
            /**end of prime costs***/

            /**Computing the Gross profit*/
                      
            double Gross = totalSales - totalCogs;
            double GrossYTD = totalSalesYTD - totalCogsYTD;

            double p1Gross = Math.Round((Gross / totalSales) * 100, 1);
            double p2Gross = Math.Round((GrossYTD / totalSalesYTD) * 100, 1);

            r = new Report(date, weekTxt.Text, ending, "Gross Profits", "Gross Profit", Gross, p1Gross, GrossYTD, p2Gross, "Gross Profit", "Profit");
            reports.Add(r);

            /**End of Gross ***/

            /**Computing Controllable Expenses*/
           
            double ctrl = totalPayRoll + totalExpenses;
            double ctrlYTD = totalPayRollYTD + totalExpenses;

            double p1Ctrl = Math.Round((prime / totalSales) * 100, 1);
            double p2Ctrl = Math.Round((totalCogsYTD / totalSalesYTD) * 100, 1);

            r = new Report(date, weekTxt.Text, ending, "Controllable Expenses", "Controllable Expense", ctrl, p1Ctrl, ctrlYTD, p2Ctrl, "Controllable Expenses", "Controllable");
            reports.Add(r);
            /**end of  Controllable Expenses***/

            /**Controllable profit*/
            double ctrlProfit = Gross - ctrl;
            double ctrlProfitYTD = GrossYTD - ctrlYTD;
            double p1CtrlProfit = Math.Round((ctrlProfit / totalSales) * 100, 1);
            double p2CtrlProfit = Math.Round((ctrlProfitYTD / totalSalesYTD) * 100, 1);

            r = new Report(date, weekTxt.Text, ending, "Controllable Profits", "Controllable Profits", ctrlProfit, p1CtrlProfit, ctrlProfitYTD, p2CtrlProfit, "Controllable Profit", "Controllable");
            reports.Add(r);

            /*end of controllable profit*/

            /** restaurant profit**/
            double occupancyExpense = Expense.List("SELECT * FROM expense  WHERE week ='" + week + "' AND category='Occupancy Expenses' ").Sum(t => t.Amount);
            double occupancyExpenseYTD = Expense.List("SELECT * FROM expense WHERE CAST(week AS INTEGER) ='" + week + "' AND category='Occupancy Expenses' ").Sum(t => t.Amount);

            double restProfit = ctrlProfit - occupancyExpense - totalEquip;
            double restProfitYTD = ctrlProfit - occupancyExpenseYTD - totalEquipYTD;

            double p1RestProfit = Math.Round((restProfit / totalSales) * 100, 1);
            double p2RestProfit = Math.Round((restProfitYTD / totalSalesYTD) * 100, 1);

            r = new Report(date, weekTxt.Text, ending, "Restaurant Profit", "Restaurant Profit", restProfit, p1RestProfit, restProfitYTD, p2RestProfit, "Restaurant Profits", "Restaurant");
            reports.Add(r);
            /** end restaurant profit**/

            this.ReportBindingSource.DataSource = reports;
            reportViewer4.RefreshReport();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabCogs;
            using (AddCogs form = new AddCogs())
            {
                DialogResult dr = form.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    string query9 = "SELECT * FROM cogs";
                    this.CogsBindingSource.DataSource = Cogs.List(query9);
                    reportViewer5.RefreshReport();

                }
            }
        }

        private void monthView1_SelectionChanged(object sender, EventArgs e)
        {
            this.calendar1.SetViewRange(this.monthView1.SelectionStart.Date, this.monthView1.SelectionEnd.Date);
        }

        private void calendar1_ItemCreated(object sender, CalendarItemCancelEventArgs e)
        {
           
        }

        private void calendar1_LoadItems(object sender, CalendarLoadEventArgs e)
        {
           // PlaceItems();
        }

        private void calendar1_ItemSelected(object sender, CalendarItemEventArgs e)
        {
           
        }

        private void calendar1_DoubleClick(object sender, EventArgs e)
        {

        }

        private void calendar1_ItemCreating(object sender, CalendarItemCancelEventArgs e)
        {
            var start = Convert.ToDateTime(e.Item.Date).ToString("yyyy-MM-dd") + "T" + Convert.ToDateTime(e.Item.Date).ToString("HH:mm:ss");
            var end = Convert.ToDateTime(e.Item.EndDate).ToString("yyyy-MM-dd") + "T" + Convert.ToDateTime(e.Item.EndDate).ToString("HH:mm:ss");

            using (EventDialog form = new EventDialog(start, end, e.Item.Date.ToString()))
            {
                // DentalDialog form1 = new DentalDialog(item.Text, TransactorID);
                DialogResult dr = form.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    LoadingCalendarLite();
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void button18_Click(object sender, EventArgs e)
        {
            using (StaffPayments form = new StaffPayments())
            {
                DialogResult dr = form.ShowDialog();
                if (dr == DialogResult.OK)
                {
                   

                }
            }
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            using (AddStaff form = new AddStaff(null))
            {
                DialogResult dr = form.ShowDialog();
                if (dr == DialogResult.OK)
                {


                }
            }
        }

        private void button19_Click(object sender, EventArgs e)
        {
            DataForm frm = new DataForm();
            frm.Show();
          
        }

        private void button17_Click(object sender, EventArgs e)
        {
            using (CompanyProfile form = new CompanyProfile(Helper.CompanyID))
            {
                DialogResult dr = form.ShowDialog();
                if (dr == DialogResult.OK)
                {


                }
            }
        }

        private void tabControl1_TabIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            using (AddUser form = new AddUser(null))
            {
                DialogResult dr = form.ShowDialog();
                if (dr == DialogResult.OK)
                {


                }
            }
        }

        private void endTxt_ValueChanged(object sender, EventArgs e)
        {
            LoadSales(pStart, pEnd);
        }
    }
}
