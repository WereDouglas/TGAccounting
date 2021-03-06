﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
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
        string current;

        public HomeForm()
        {
            LoadingWindow.ShowSplashScreen();

            if (Global.LoadData())
            {

                LoadingWindow.CloseForm();
            }

            InitializeComponent();

            var culture = new CultureInfo("en-US");
            CultureInfo.DefaultThreadCurrentCulture = culture;
            CultureInfo.DefaultThreadCurrentUICulture = culture;

            pStart = DateTime.Now;
            pEnd = DateTime.Now;
            try { Helper.CurrentYear = Company.List().First().Current; } catch { }
            if (string.IsNullOrEmpty(Helper.CurrentYear))
            {

                current = DateTime.Now.Year.ToString();
                Helper.CurrentYear = current;
                globalYrTxt.Text = current;

            }
            else
            {

                globalYrTxt.Text = Helper.CurrentYear;
            }


            /**image**/
            try
            {
                Image img = Helper.Base64ToImage(Company.List().First().Logo);
                System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(img);
                //Bitmap bps = new Bitmap(bmp, 50, 50);
                pictureBox2.Image = bmp;
                pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            catch (Exception p)
            {


                Helper.Exceptions(p.Message, "Loading the Company Logo !");
            }
            LoadProfile();
            /**Loading the first tab*/
            string query2 = "SELECT * FROM sale WHERE date= '" + Helper.CurrentYear + "'";
            this.SaleBindingSource.DataSource = Sale.List(query2);
            reportViewer1.RefreshReport();
            LoadingCalendarLite();
            LoadingWindow.CloseForm();
        }
        private void LoadProfile()
        {


            usernameTxt.Text = Helper.UserName;
            try
            {
                Image img = Helper.Base64ToImage(Helper.UserImage);
                System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(img);
                pictureBox1.Image = bmp;
                GraphicsPath gp = new GraphicsPath();
                gp.AddEllipse(pictureBox1.DisplayRectangle);
                pictureBox1.Region = new Region(gp);
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            catch (Exception p)
            {


                Helper.Exceptions(p.Message, "Loading the user image !");
            }

        }
        /**sales list of items*/

        public static List<Events> events;
        private void LoadingCalendarLite()
        {

            _items.Clear();
            List<ItemInfo> lst = new List<ItemInfo>();
            string state = "";

            List<Events> events = Model.Events.List();

            foreach (Events e in events)
            {
                try
                {
                    CalendarItem cal = new CalendarItem(calendar1, Convert.ToDateTime(e.Starts), Convert.ToDateTime(e.Ends), e.Users + " " + e.Users + " " + e.Contact + "" + e.Details);

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


        }
        /**End of item section*/
        /***Sales section***/


        private void button1_Click(object sender, EventArgs e)
        {

            using (AddSale form = new AddSale())
            {
                DialogResult dr = form.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    tabControl1.SelectedTab = saleTab;
                    string query2 = "SELECT * FROM sale WHERE date= '" + Helper.CurrentYear + "'";
                    this.SaleBindingSource.DataSource = Sale.List(query2);
                    reportViewer1.RefreshReport();


                }
            }
        }


        /***End the Sales section***/


        private void saleGrid_Click(object sender, EventArgs e)
        {

        }

        private void HomeForm_Load(object sender, EventArgs e)
        {

            string query2 = "SELECT * FROM sale WHERE date= '" + Helper.CurrentYear + "'";
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
            string query = "SELECT * FROM sale WHERE date= '" + Helper.CurrentYear + "'";
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

                }
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {


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
                    string query4 = "SELECT * FROM supplies WHERE date = '" + Helper.CurrentYear + "'";
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
                    string query6 = "SELECT * FROM repair WHERE date = '" + Helper.CurrentYear + "'";
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
                    string query4 = "SELECT * FROM supplies WHERE date = '" + Helper.CurrentYear + "'";
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
                    if (!string.IsNullOrEmpty(categoryCbx.Text))
                    {
                        tabControl1.SelectedTab = tabInventory;
                        string query4 = "SELECT * FROM inventory  WHERE date = '" + Helper.CurrentYear + "' AND category = '" + categoryCbx.Text + "'";
                        this.InventoryBindingSource.DataSource = Inventory.List(query4);
                        reportViewerInventory.RefreshReport();
                        autocompleteCategory();
                    }

                }
            }
        }
        private void autocompleteCategory()
        {
            categoryCbx.Items.Clear();
            AutoCompleteStringCollection AutoItem = new AutoCompleteStringCollection();
            foreach (var r in Inventory.ListCategory("SELECT DISTINCT category from inventory "))
            {
                AutoItem.Add(r);
                categoryCbx.Items.Add(r);
            }
            categoryCbx.AutoCompleteMode = AutoCompleteMode.Suggest;
            categoryCbx.AutoCompleteSource = AutoCompleteSource.CustomSource;
            categoryCbx.AutoCompleteCustomSource = AutoItem;


        }

        private void categoryCbx_SelectedIndexChanged(object sender, EventArgs e)
        {


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
                    string query4 = "SELECT * FROM expense WHERE date= '" + Helper.CurrentYear + "'";
                    this.ExpenseBindingSource.DataSource = Expense.List(query4);
                    reportViewerExpense.RefreshReport();

                }
            }
        }
        List<Report> reports;
        private void button15_Click(object sender, EventArgs e)
        {

        }

        private void button16_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabCogs;
            using (AddCogs form = new AddCogs())
            {
                DialogResult dr = form.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    string query9 = "SELECT * FROM cogs  WHERE date= '" + Helper.CurrentYear + "'";
                    this.CogsBindingSource.DataSource = Cogs.List(query9);
                    reportViewer5.RefreshReport();

                }
            }
        }

        private void monthView1_SelectionChanged(object sender, EventArgs e)
        {
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

        private void globalYrTxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void globalYrTxt_Leave(object sender, EventArgs e)
        {
            Helper.CurrentYear = globalYrTxt.Text;
        }

        private void button20_Click(object sender, EventArgs e)
        {
            Helper.CurrentYear = globalYrTxt.Text;
        }

        private void tabControl1_SelectedIndexChanged_1(object sender, EventArgs e)
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
                    string query2 = "SELECT * FROM sale WHERE date= '" + Helper.CurrentYear + "'";
                    this.SaleBindingSource.DataSource = Sale.List(query2);
                    reportViewer1.RefreshReport();
                    break;
                case "tabSalary":
                    string query10 = "SELECT * FROM salary WHERE date= '" + Helper.CurrentYear + "'";
                    this.SalaryBindingSource.DataSource = Salary.List();
                    // reportViewerSalary.RefreshReport();
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
                    string query9 = "SELECT * FROM cogs WHERE date= '" + Helper.CurrentYear + "'";
                    this.CogsBindingSource.DataSource = Cogs.List(query9);
                    reportViewer5.RefreshReport();
                    break;
                case "tabCalendar":
                    //autocompleteCateg();
                    LoadingCalendarLite();
                    break;
                case "tabComp":
                    //autocompleteCateg();
                    string query19 = "SELECT * FROM comp WHERE date= '" + Helper.CurrentYear + "'";
                    this.SaleBindingSource.DataSource = Comp.List(query19);
                    reportViewer6.RefreshReport();
                    break;

            }
        }

        private void categoryCbx_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(categoryCbx.Text))
            {
                LoadingWindow.ShowSplashScreen();
                string query7 = "SELECT * FROM inventory WHERE category='" + categoryCbx.Text + "' AND date= '" + Helper.CurrentYear + "' ORDER BY week ASC";
                this.InventoryBindingSource.DataSource = Inventory.List(query7);
                reportViewerInventory.RefreshReport();
                LoadingWindow.CloseForm();
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void reportViewerInventory_Load(object sender, EventArgs e)
        {

        }

        private void calendar1_LoadItems_1(object sender, CalendarLoadEventArgs e)
        {
            LoadingCalendarLite();
        }

        private void calendar1_ItemCreating_1(object sender, CalendarItemCancelEventArgs e)
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

        private void button2_Click_1(object sender, EventArgs e)
        {
            using (AddBudget form = new AddBudget())
            {
                DialogResult dr = form.ShowDialog();
                if (dr == DialogResult.OK)
                {


                }
            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            using (AddComp form = new AddComp())
            {
                DialogResult dr = form.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    tabControl1.SelectedTab = tabComp;
                    string query19 = "SELECT * FROM comp WHERE date= '" + Helper.CurrentYear + "'";
                    this.SaleBindingSource.DataSource = Comp.List(query19);
                    reportViewer6.RefreshReport();

                }
            }
        }
        Dictionary<string, double> SaleWeeklyBudget = new Dictionary<string, double>();
        Dictionary<string, double> SaleAnnualBudget = new Dictionary<string, double>();

        private void button15_Click_1(object sender, EventArgs e)
        {
            double projectionWeekly = 0;
            double projectionAnnual = 0;
            try
            {
                projectionWeekly = Annual.List("SELECT * FROM annual WHERE year ='" + Helper.CurrentYear + "'").Sum(t => t.Weekly);
            }
            catch
            {
            }
            try
            {
                projectionAnnual = Annual.List("SELECT * FROM annual WHERE year ='" + Helper.CurrentYear + "'").Sum(t => t.Annuals);
            }
            catch
            {
            }
            projectionWeeklyTxt.Text = projectionWeekly.ToString("n0");
            projectAnnualTxt.Text = projectionAnnual.ToString("n0");
            reportViewer4.RefreshReport();
            Report r = new Report();
            int week = Convert.ToInt32(Convert.ToInt32(weekTxt.Text));
            string year = Helper.CurrentYear;
            string date = "";
            reports = new List<Report>();
            string ending = "";
            DateTime startWeek = Helper.FirstDateOfWeek(Convert.ToInt32(Helper.CurrentYear), week - 1);
            ending = startWeek.AddDays(7).ToString("dd-MM-yyyy");
            double totalPayRoll = 0;
            double totalPayRollYTD = 0;
            double totalCogs = 0;
            double totalCogsYTD = 0;
            double totalComps = 0;
            double totalCompsYTD = 0;
            double totalSales = 0;
            double totalSalesYTD = 0;
            double totalTaxes = 0;
            double totalTaxesYtd = 0;
            double totalExpenses = 0;
            double totalExpensesYTD = 0;

            double totalEquip = 0;
            double totalEquipYTD = 0;

            totalSales = Sale.List("SELECT * FROM sale  WHERE week ='" + week + "'  AND date= '" + Helper.CurrentYear + "'").Sum(t => t.Amount);
            totalSalesYTD = Sale.List("SELECT * FROM sale WHERE CAST(week AS INTEGER) <='" + week + "'  AND date= '" + Helper.CurrentYear + "' ").Sum(t => t.Amount);

            foreach (Sale s in Sale.List("SELECT * FROM sale  WHERE week ='" + week + "'  AND date= '" + Helper.CurrentYear + "' "))
            {
                double sums = Sale.List("SELECT * FROM sale  WHERE week ='" + week + "' AND item='" + s.Item + "'  AND date= '" + Helper.CurrentYear + "' ").Sum(t => t.Amount);
                double ytd = Sale.List("SELECT * FROM sale WHERE CAST(week AS INTEGER) <='" + week + "'  AND item='" + s.Item + "'  AND date= '" + Helper.CurrentYear + "' ").Sum(t => t.Amount);
                ending = Convert.ToDateTime(s.Ending).ToString("dd-MMM-yy");
                date = s.Date;
                /**Budget **/
                double budgetPerc = 0;
                try
                {
                    budgetPerc = Budget.List("SELECT * FROM budget WHERE item ='" + s.Item + "' AND category='Sale'  AND date= '" + Helper.CurrentYear + "' ").First().Pct;
                }
                catch
                {
                    //throw;
                }
                double budgetWeekly = 0;
                try
                {
                    budgetWeekly = SaleWeeklyBudget[s.Item] * (budgetPerc / 100);
                }
                catch { }
                double budgetAnnual = 0;
                try
                {
                    budgetAnnual = SaleAnnualBudget[s.Item] * (budgetPerc / 100);
                }
                catch { }
                try
                { }
                catch { }
                if (!SaleWeeklyBudget.ContainsKey(s.Item))
                {
                    SaleWeeklyBudget.Add(s.Item, budgetWeekly);
                }
                if (!SaleAnnualBudget.ContainsKey(s.Item))
                {
                    SaleAnnualBudget.Add(s.Item, budgetAnnual);
                }
                double difference = ytd - budgetAnnual;
                double weeklyDiff = sums - budgetWeekly;
                double differencePerc = Math.Round((ytd / budgetAnnual) * 100, 1);
                /**End working with Budget**/
                double p1 = Math.Round((s.Amount / totalSales) * 100, 1);
                double p2 = Math.Round((ytd / totalSalesYTD) * 100, 1);

                r = new Report(s.Date, s.Week, Convert.ToDateTime(s.Ending).ToString("dd-MMM-yy"), "Sales_", s.Category, "SALES", s.Item, s.Amount, p1, budgetWeekly, weeklyDiff, ytd, p2, 1, 1, budgetAnnual, budgetPerc, difference, differencePerc);
                reports.Add(r);
            }
            totalCogs = Cogs.List("SELECT * FROM cogs  WHERE week ='" + week + "'  AND date= '" + Helper.CurrentYear + "' ").Sum(t => t.Cost);
            totalCogsYTD = Cogs.List("SELECT * FROM cogs  WHERE CAST(week AS INTEGER) <='" + week + "'   AND date= '" + Helper.CurrentYear + "' ").Sum(t => t.Cost);

            foreach (Cogs s in Cogs.List("SELECT * FROM cogs  WHERE week ='" + week + "'  AND date= '" + Helper.CurrentYear + "' "))
            {
                double sums = Cogs.List("SELECT * FROM cogs  WHERE week ='" + week + "' AND category='" + s.Category + "'  AND date= '" + Helper.CurrentYear + "' ").Sum(t => t.Cost);
                double SaleSum = Sale.List("SELECT * FROM sale  WHERE week ='" + week + "' AND item='" + s.Category + "'  AND date= '" + Helper.CurrentYear + "' ").Sum(t => t.Amount);
                double SaleSumYtd = Sale.List("SELECT * FROM sale  WHERE CAST(week AS INTEGER) <='" + week + "' AND item='" + s.Category + "'  AND date= '" + Helper.CurrentYear + "' ").Sum(t => t.Amount);
                double ytd = Cogs.List("SELECT * FROM cogs  WHERE CAST(week AS INTEGER) <='" + week + "'  AND category='" + s.Category + "'  AND date= '" + Helper.CurrentYear + "' ").Sum(t => t.Cost);
                /**Budget **/
                double budgetPerc = 0;
                try
                {
                    budgetPerc = Budget.List("SELECT * FROM budget WHERE item ='" + s.Category + "' AND category='Cost of Goods'  AND date= '" + Helper.CurrentYear + "' ").First().Pct;

                }
                catch { }
                double budgetWeekly = 0;
                try
                {
                    budgetWeekly = SaleWeeklyBudget[s.Category] * (budgetPerc / 100);
                }
                catch { }
                double budgetAnnual = 0;
                try
                {
                    budgetAnnual = SaleAnnualBudget[s.Category] * (budgetPerc / 100);
                }
                catch { }
                try
                { }
                catch { }
                double weeklyDiff = sums - budgetWeekly;
                double difference = sums - budgetAnnual;
                double differencePerc = sums / budgetAnnual;
                /**End working with Budget**/
                double p1 = Math.Round((s.Cost / SaleSum) * 100, 1);
                double p2 = Math.Round((ytd / SaleSumYtd) * 100, 1);

                r = new Report(s.Date, s.Week, Convert.ToDateTime(s.Ending).ToString("dd-MMM-yy"), "COST OF GOODS", "Cost of goods", "COST OF GOODS", s.Category, s.Cost, p1, budgetWeekly, weeklyDiff, ytd, p2, 2, 1, budgetAnnual, budgetPerc, difference, differencePerc);
                reports.Add(r);

            }
            totalComps = Comp.List("SELECT * FROM comp  WHERE week ='" + week + "'  AND date= '" + Helper.CurrentYear + "'").Sum(t => t.Amount);

            totalCompsYTD = Comp.List("SELECT * FROM comp  WHERE CAST(week AS INTEGER) <='" + week + "'  AND date= '" + Helper.CurrentYear + "' ").Sum(t => t.Amount);

            foreach (Comp s in Comp.List("SELECT * FROM comp  WHERE week ='" + week + "'  AND date= '" + Helper.CurrentYear + "'"))
            {
                double sums = Comp.List("SELECT * FROM comp  WHERE week ='" + week + " 'AND item='" + s.Item + "'  AND date= '" + Helper.CurrentYear + "' ").Sum(t => t.Amount);
                double SaleSum = Sale.List("SELECT * FROM sale  WHERE week ='" + week + "' AND item='" + s.Item + "'  AND date= '" + Helper.CurrentYear + "' ").Sum(t => t.Amount);
                double SaleSumYtd = Sale.List("SELECT * FROM sale  WHERE CAST(week AS INTEGER) <='" + week + "' AND item='" + s.Item + "'  AND date= '" + Helper.CurrentYear + "' ").Sum(t => t.Amount);
                ending = Convert.ToDateTime(s.Ending).ToString("dd-MMM-yy");
                double ytd = Comp.List("SELECT * FROM comp  WHERE CAST(week AS INTEGER) <='" + week + "'  AND item='" + s.Item + "'  AND date= '" + Helper.CurrentYear + "' ").Sum(t => t.Amount);
                /**Budget **/
                double budgetPerc = 0;
                try
                {
                    budgetPerc = Budget.List("SELECT * FROM budget WHERE item ='" + s.Item + "' AND category='Complimentaries'  AND date= '" + Helper.CurrentYear + "' ").First().Pct;
                }
                catch { }
                double budgetWeekly = 0;
                try
                {
                     budgetWeekly = SaleWeeklyBudget[s.Item] * (budgetPerc / 100);
                }
                catch { }
                double budgetAnnual = 0;
                try
                {
                   budgetAnnual = SaleAnnualBudget[s.Item] * (budgetPerc / 100);
                }
                catch { }
                try
                { }
                catch { }
                 double weeklyDiff = sums - budgetWeekly;
                double difference = ytd - budgetAnnual;
                double differencePerc = ytd / budgetAnnual;
                /**End working with Budget**/

                double p1 = Math.Round((s.Amount / SaleSum) * 100, 1);
                double p2 = Math.Round((ytd / SaleSumYtd) * 100, 1);

                r = new Report(s.Date, s.Week, Convert.ToDateTime(s.Ending).ToString("dd-MMM-yy"), "Complimentaries", "COMPLIMENTARIES", "COST OF GOODS", s.Item, s.Amount, p1, budgetWeekly, weeklyDiff, ytd, p2, 2, 2, budgetAnnual, budgetPerc, difference, differencePerc);
                reports.Add(r);

            }

            /**Computing the Gross profit*/

            double Gross = totalSales - (totalCogs + totalComps);
            double GrossYTD = totalSalesYTD - (totalCogsYTD + totalCompsYTD);

            double p1Gross = Math.Round((Gross / totalSales) * 100, 1);
            double p2Gross = Math.Round((GrossYTD / totalSalesYTD) * 100, 1);

            r = new Report(date, Convert.ToInt32(weekTxt.Text), ending, "Gross Profit_", "Gross Profit", "GROSS PROFIT_", "Gross Profit", Gross, p1Gross, 0, 0, GrossYTD, p2Gross, 3, 1, 0, 0, 0, 0);
            reports.Add(r);

            /**End of Gross ***/

            double totalLabor = Labor.List("SELECT * FROM labor  WHERE week ='" + week + "'  AND date= '" + Helper.CurrentYear + "' ").Sum(t => t.Amount);
            double totalLaborYtd = Labor.List("SELECT * FROM labor  WHERE CAST(week AS INTEGER) <='" + week + "' AND date= '" + Helper.CurrentYear + "' ").Sum(t => t.Amount);

            foreach (Labor l in Labor.List("SELECT * FROM labor  WHERE week ='" + week + "'  AND date= '" + Helper.CurrentYear + "' "))
            {
                double sums = Labor.List("SELECT * FROM labor  WHERE week ='" + week + "' AND item='" + l.Item + "'  AND date= '" + Helper.CurrentYear + "' ").Sum(t => t.Amount);

                double ytd = Labor.List("SELECT * FROM labor  WHERE CAST(week AS INTEGER) <='" + week + "' AND item='" + l.Item + "'  AND date= '" + Helper.CurrentYear + "' ").Sum(t => t.Amount);
                date = l.Date;

                double p1 = Math.Round((l.Amount / totalSales) * 100, 1);
                double p2 = Math.Round((ytd / totalSalesYTD) * 100, 1);
                r = new Report(l.Date, l.Week, Convert.ToDateTime(l.Ending).ToString("dd-MMM-yy"), "Salaries & Wages", "Salaries & Wages", "PAYROLL", l.Item, l.Amount, p1, 0, 0, ytd, p2, 4, 1, 0, 0, 0, 0);
                reports.Add(r);


            }
            totalTaxes = Taxes.List("SELECT * FROM taxes  WHERE week ='" + week + "'   AND date= '" + Helper.CurrentYear + "' ").Sum(t => t.Amount);
            totalTaxesYtd = Taxes.List("SELECT * FROM taxes  WHERE CAST(week AS INTEGER) <='" + week + "'   AND date= '" + Helper.CurrentYear + "' ").Sum(t => t.Amount);

            foreach (Taxes l in Taxes.List("SELECT * FROM taxes  WHERE week ='" + week + "' AND date= '" + Helper.CurrentYear + "' "))
            {
                double sums = Taxes.List("SELECT * FROM taxes  WHERE week ='" + week + "' AND name='" + l.Name + "'  AND date= '" + Helper.CurrentYear + "' ").Sum(t => t.Amount);

                double ytd = Taxes.List("SELECT * FROM taxes  WHERE CAST(week AS INTEGER) <='" + week + "' AND name='" + l.Name + "'  AND date= '" + Helper.CurrentYear + "' ").Sum(t => t.Amount);

                double p1 = Math.Round((l.Amount / totalSales) * 100, 1);
                double p2 = Math.Round((ytd / totalSalesYTD) * 100, 1);
                r = new Report(l.Date, l.Week, Convert.ToDateTime(l.Ending).ToString("dd-MMM-yy"), "Employee Benefits", "Employee Benefits", "PAYROLL", l.Name, l.Amount, p1, 0, 0, ytd, p2, 4, 2, 0, 0, 0, 0);
                reports.Add(r);
            }
            totalPayRoll = totalTaxes + totalLabor;
            totalPayRollYTD = totalTaxesYtd + totalLaborYtd;
            /**Computing the prime costs*/

            double prime = totalCogs + totalComps + totalPayRoll;
            double primeYTD = totalCogsYTD + +totalCompsYTD + totalPayRollYTD;
            double p1Prime = Math.Round((prime / totalSales) * 100, 1);
            double p2Prime = Math.Round((primeYTD / totalSalesYTD) * 100, 1);
            r = new Report(date, Convert.ToInt32(Convert.ToInt32(weekTxt.Text)), Convert.ToDateTime(ending).ToString("dd-MMM-yy"), "Prime Cost_", "Prime Cost", "PRIME COST_", "Prime Cost", prime, p1Prime, 0, 0, primeYTD, p2Prime, 6, 1, 0, 0, 0, 0);
            reports.Add(r);
            /**end of prime costs***/

            /*Controllable Expenses*/
            double totalSupplies = Supplies.List("SELECT * FROM supplies  WHERE week ='" + week + "' AND date= '" + Helper.CurrentYear + "' ").Sum(t => t.Amount);
            double totalSuppliesYTD = Supplies.List("SELECT * FROM supplies  WHERE CAST(week AS INTEGER) <='" + week + "' AND date= '" + Helper.CurrentYear + "' ").Sum(t => t.Amount);

            foreach (Supplies s in Supplies.List("SELECT * FROM supplies  WHERE week ='" + week + "'  AND date= '" + Helper.CurrentYear + "' "))
            {
                double sums = Supplies.List("SELECT * FROM supplies  WHERE week ='" + week + "' AND supplier='" + s.Supplier + "' AND date= '" + Helper.CurrentYear + "' ").Sum(t => t.Amount);
                double ytd = Supplies.List("SELECT * FROM supplies  WHERE CAST(week AS INTEGER) <='" + week + "'  AND supplier='" + s.Supplier + "'  AND date= '" + Helper.CurrentYear + "' ").Sum(t => t.Amount);
                double p1 = Math.Round((s.Amount / totalSales) * 100, 1);
                double p2 = Math.Round((ytd / totalSalesYTD) * 100, 1);
                r = new Report(s.Date, s.Week, Convert.ToDateTime(s.Ending).ToString("dd-MMM-yy"), "Supplies", "Other Controllable Expenses", "Expense", s.Supplier, s.Amount, p1, 0, 0, ytd, p2, 7, 1, 0, 0, 0, 0);
                reports.Add(r);

            }
            double totalRepair = Repair.List("SELECT * FROM repair  WHERE week ='" + week + "' AND date= '" + Helper.CurrentYear + "' ").Sum(t => t.Amount);
            double totalRepairYTD = Repair.List("SELECT * FROM repair  WHERE CAST(week AS INTEGER) <='" + week + "' AND date= '" + Helper.CurrentYear + "' ").Sum(t => t.Amount);

            foreach (Repair s in Repair.List("SELECT * FROM repair  WHERE week ='" + week + "'  AND date= '" + Helper.CurrentYear + "' "))
            {
                double sums = Repair.List("SELECT * FROM repair  WHERE week ='" + week + "'  AND supplier='" + s.Supplier + "'  AND date= '" + Helper.CurrentYear + "' ").Sum(t => t.Amount);
                double ytd = Repair.List("SELECT * FROM repair  WHERE CAST(week AS INTEGER) <='" + week + "'  AND supplier='" + s.Supplier + "'  AND date= '" + Helper.CurrentYear + "' ").Sum(t => t.Amount);

                double p1 = Math.Round((s.Amount / totalSales) * 100, 1);
                double p2 = Math.Round((ytd / totalSalesYTD) * 100, 1);
                r = new Report(s.Date, s.Week, Convert.ToDateTime(s.Ending).ToString("dd-MMM-yy"), "Repair and maintenance", "Other Controllable Expenses", "EXPENSE", s.Supplier, s.Amount, p1, 0, 0, ytd, p2, 7, 2, 0, 0, 0, 0);
                reports.Add(r);

            }

            double totalVariable = Expense.List("SELECT * FROM expense  WHERE week ='" + week + "' AND date= '" + Helper.CurrentYear + "' AND category<>'Occupancy Expenses'").Sum(t => t.Amount);
            double totalVariableYTD = Expense.List("SELECT * FROM expense  WHERE CAST(week AS INTEGER) <='" + week + "' AND date= '" + Helper.CurrentYear + "' AND category<>'Occupancy Expenses'").Sum(t => t.Amount);

            foreach (Expense s in Expense.List("SELECT * FROM expense  WHERE week ='" + week + "' AND date= '" + Helper.CurrentYear + "' AND category<>'Occupancy Expenses' "))
            {
                double sums = Expense.List("SELECT * FROM expense  WHERE week ='" + week + "' AND name='" + s.Name + "' AND date= '" + Helper.CurrentYear + "' AND category<>'Occupancy Expenses' ").Sum(t => t.Amount);

                double ytd = Expense.List("SELECT * FROM expense  WHERE CAST(week AS INTEGER) <='" + week + "'  AND name='" + s.Name + "'  AND date= '" + Helper.CurrentYear + "' AND category<>'Occupancy Expenses' ").Sum(t => t.Amount);
                double p1 = Math.Round((s.Amount / totalSales) * 100, 1);
                double p2 = Math.Round((ytd / totalSalesYTD) * 100, 1);

                /**Budget **/
                double budgetPerc = 0;
                try
                {
                    budgetPerc = Budget.List("SELECT * FROM budget WHERE item ='" + s.Name + "' AND category='Expenses'  AND date= '" + Helper.CurrentYear + "' ").First().Pct;
                }
                catch { }
                double budgetWeekly = SaleWeeklyBudget.Sum(k => k.Value) * (budgetPerc / 100);
                double budgetAnnual = SaleAnnualBudget.Sum(k => k.Value) * (budgetPerc / 100);
                double weeklyDiff = sums - budgetWeekly;
                double difference = ytd - budgetAnnual;
                double differencePerc = ytd / budgetAnnual;
                /**End working with Budget**/

                r = new Report(s.Date, s.Week, Convert.ToDateTime(s.Ending).ToString("dd-MMM-yy"), s.Category, "Other Controllable Expenses", "EXPENSE", s.Name, s.Amount, p1, budgetWeekly, weeklyDiff, ytd, p2, 7, 3, budgetAnnual, budgetPerc, difference, differencePerc);
                reports.Add(r);
            }
            /**Computing Controllable Expenses*/
            double ctrl = totalPayRoll + totalVariable + totalSupplies + totalRepair;
            double ctrlYTD = totalPayRollYTD + totalVariableYTD + totalSuppliesYTD + totalRepairYTD;
            double p1Ctrl = Math.Round((ctrl / totalSales) * 100, 1);
            double p2Ctrl = Math.Round((ctrlYTD / totalSalesYTD) * 100, 1);
            r = new Report(date, Convert.ToInt32(weekTxt.Text), ending, "Controllable Expenses_", "Controllable Expense", "CONTROLLABLE EXPENSES_", "Controllable Expenses", ctrl, p1Ctrl, 0, 0, ctrlYTD, p2Ctrl, 8, 1, 0, 0, 0, 0);
            reports.Add(r);
            /**end of  Controllable Expenses***/

            /**Controllable profit*/
            double ctrlProfit = Gross - ctrl;
            double ctrlProfitYTD = GrossYTD - ctrlYTD;
            double p1CtrlProfit = Math.Round((ctrlProfit / totalSales) * 100, 1);
            double p2CtrlProfit = Math.Round((ctrlProfitYTD / totalSalesYTD) * 100, 1);
            r = new Report(date, Convert.ToInt32(weekTxt.Text), Convert.ToDateTime(ending).ToString("dd-MMM-yy"), "Controllable Profits_", "Controllable Profits", "CONTROLLABLE PROFITS_", "Controllable Profit", ctrlProfit, p1CtrlProfit, 0, 0, ctrlProfitYTD, p2CtrlProfit, 9, 1, 0, 0, 0, 0);
            reports.Add(r);

            /*end of controllable profit*/

            /** Occupancy Expenses**/
            double occupancyExpense = Expense.List("SELECT * FROM expense  WHERE week ='" + week + "' AND category='Occupancy Expenses'  AND date= '" + Helper.CurrentYear + "' ").Sum(t => t.Amount);
            double occupancyExpenseYTD = Expense.List("SELECT * FROM expense WHERE CAST(week AS INTEGER) <='" + week + "' AND category='Occupancy Expenses'  AND date= '" + Helper.CurrentYear + "' ").Sum(t => t.Amount);

            double p1Occupancy = Math.Round((occupancyExpense / totalSales) * 100, 1);
            double p2OCCupancy = Math.Round((occupancyExpenseYTD / totalSalesYTD) * 100, 1);
            /**  r = new Report(date, Convert.ToInt32(weekTxt.Text), Convert.ToDateTime(ending).ToString("dd-MMM-yy"), "Occupancy Expenses", "Occupancy Expenses", occupancyExpense, p1Occupancy, occupancyExpenseYTD, p2OCCupancy, "Occupancy Expenses", "Occupancy Expenses", 10, 1);
            reports.Add(r);**/
            foreach (Expense s in Expense.List("SELECT * FROM expense  WHERE week ='" + week + "' AND date= '" + Helper.CurrentYear + "' AND category='Occupancy Expenses' "))
            {
                double sums = Expense.List("SELECT * FROM expense  WHERE week ='" + week + "' AND name='" + s.Name + "' AND date= '" + Helper.CurrentYear + "' AND category='Occupancy Expenses' ").Sum(t => t.Amount);

                double ytd = Expense.List("SELECT * FROM expense  WHERE CAST(week AS INTEGER) <='" + week + "' AND category='Occupancy Expenses'  AND name='" + s.Name + "'  AND date= '" + Helper.CurrentYear + "'").Sum(t => t.Amount);
                double p1 = Math.Round((s.Amount / totalSales) * 100, 1);
                double p2 = Math.Round((ytd / totalSalesYTD) * 100, 1);
                r = new Report(s.Date, s.Week, Convert.ToDateTime(s.Ending).ToString("dd-MMM-yy"), s.Category, s.Category, s.Category.ToUpper(), s.Name, s.Amount, p1, 0, 0, ytd, p2, 10, 1, 0, 0, 0, 0);
                reports.Add(r);

            }
            /*End of occupancy*/
            foreach (Equipment s in Equipment.List("SELECT * FROM equipment  WHERE week ='" + week + "' AND date= '" + Helper.CurrentYear + "' "))
            {
                double sums = Equipment.List("SELECT * FROM equipment  WHERE week ='" + week + "' AND date= '" + Helper.CurrentYear + "' ").Sum(t => t.Amount);
                double ytd = Equipment.List("SELECT * FROM equipment  WHERE CAST(week AS INTEGER) <='" + week + "'  AND name='" + s.Name + "'  AND date= '" + Helper.CurrentYear + "' ").Sum(t => t.Amount);
                double p1 = Math.Round((s.Amount / sums) * 100, 1);
                double p2 = Math.Round((s.Amount / sums) * 100, 1);
                r = new Report(s.Date, s.Week, Convert.ToDateTime(s.Ending).ToString("dd-MMM-yy"), "Equipment & Improvements_", "Equipment & Improvements", "EQUIPMENT & IMPROVEMENTS_", s.Name, s.Amount, p1, 0, 0, ytd, p2, 11, 1, 0, 0, 0, 0);
                reports.Add(r);
                totalEquip = totalEquip + sums;
                totalEquipYTD = totalEquipYTD + ytd;
            }

            double restProfit = ctrlProfit - occupancyExpense - totalEquip;
            double restProfitYTD = ctrlProfit - occupancyExpenseYTD - totalEquipYTD;

            double p1RestProfit = Math.Round((restProfit / totalSales) * 100, 1);
            double p2RestProfit = Math.Round((restProfitYTD / totalSalesYTD) * 100, 1);
            /** restaurant profit**/
            r = new Report(date, Convert.ToInt32(weekTxt.Text), Convert.ToDateTime(ending).ToString("dd-MMM-yy"), "Restaurant Profit_", "Restaurant Profit", "RESTAURANT PROFIT_", "Restaurant Profit", restProfit, p1RestProfit, 0, 0, restProfitYTD, p2RestProfit, 12, 1, 0, 0, 0, 0);
            reports.Add(r);
            /** end restaurant profit**/
            Microsoft.Reporting.WinForms.ReportParameter rp = new Microsoft.Reporting.WinForms.ReportParameter("week", week.ToString());
            this.reportViewer4.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter[] { rp });
            this.ReportBindingSource.DataSource = reports;
            reportViewer4.RefreshReport();
        }

        private void weekTxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar)
             && !char.IsDigit(e.KeyChar)
             && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            // only allow two decimal point
            if (e.KeyChar == '.'
                && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            ChartForm frm = new ChartForm();
            frm.Show();
        }

        private void button8_Click_1(object sender, EventArgs e)
        {
            using (ImportDialog form = new ImportDialog())
            {
                DialogResult dr = form.ShowDialog();
                if (dr == DialogResult.OK)
                {

                }
            }
        }

        private void categoryCbx_Leave(object sender, EventArgs e)
        {

        }

        private void button18_Click_1(object sender, EventArgs e)
        {
            categoryCbx_SelectedIndexChanged_1(null, null);
        }

        private void reportViewer5_Load(object sender, EventArgs e)
        {

        }
        List<Profit> pr = new List<Profit>();
        private void button21_Click_1(object sender, EventArgs e)
        {
            reportViewer7.RefreshReport();
            Profit r = new Profit();
            int week = Convert.ToInt32(Convert.ToInt32(maxWeeksTxt.Text));

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
                string year = startWeek.AddDays(7).ToString("yyyy");
                totalSales = Sale.List("SELECT * FROM sale  WHERE week ='" + x + "'  AND date= '" + year + "'").Sum(t => t.Amount);
                totalCogs = Cogs.List("SELECT * FROM cogs  WHERE week ='" + x + "'  AND date= '" + year + "' ").Sum(t => t.Cost);
                totalComps = Comp.List("SELECT * FROM comp  WHERE week ='" + x + "'  AND date= '" + year + "'").Sum(t => t.Amount);
                double Gross = totalSales - (totalCogs + totalComps);
                double totalLabor = Labor.List("SELECT * FROM labor  WHERE week ='" + x + "'  AND date= '" + year + "' ").Sum(t => t.Amount);
                totalTaxes = Taxes.List("SELECT * FROM taxes  WHERE week ='" + x + "'   AND date= '" + year + "' ").Sum(t => t.Amount);
                totalPayRoll = totalTaxes + totalLabor;
                double prime = totalCogs + totalComps + totalPayRoll;
                double totalSupplies = Supplies.List("SELECT * FROM supplies  WHERE week ='" + x + "' AND date= '" + year + "' ").Sum(t => t.Amount);
                double totalRepair = Repair.List("SELECT * FROM repair  WHERE week ='" + x + "' AND date= '" + year + "' ").Sum(t => t.Amount);
                double totalVariable = Expense.List("SELECT * FROM expense  WHERE week ='" + x + "' AND date= '" + year + "' AND category<>'Occupancy Expenses'").Sum(t => t.Amount);
                double ctrl = totalPayRoll + totalVariable + totalSupplies + totalRepair;
                double ctrlProfit = Gross - ctrl;
                double occupancyExpense = Expense.List("SELECT * FROM expense  WHERE week ='" + x + "' AND category='Occupancy Expenses'  AND date= '" + year + "' ").Sum(t => t.Amount);
                totalEquip = Equipment.List("SELECT * FROM equipment  WHERE week ='" + x + "' AND date= '" + year + "' ").Sum(t => t.Amount);
                double restProfit = ctrlProfit - occupancyExpense - totalEquip;

                r = new Profit(year, month, x, Convert.ToDateTime(ending).ToString("dd-MMM-yy"), totalSales, totalCogs, totalComps, Gross, totalPayRoll, prime, totalVariable, totalSupplies, totalRepair, ctrl, ctrlProfit, occupancyExpense, totalEquip, restProfit);
                pr.Add(r);

            }
            this.ProfitBindingSource.DataSource = pr;
            reportViewer7.RefreshReport();
        }

        private void button22_Click(object sender, EventArgs e)
        {
            using (AnnualDialog form = new AnnualDialog())
            {
                DialogResult dr = form.ShowDialog();
                if (dr == DialogResult.OK)
                {


                }
            }
        }

        private void weekTxt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button15.PerformClick();
            }
        }

        private void monthView1_SelectionChanged_1(object sender, EventArgs e)
        {
            this.calendar1.SetViewRange(this.monthView1.SelectionStart.Date, this.monthView1.SelectionEnd.Date);

        }

        private void button21_Click(object sender, EventArgs e)
        {
            using (AddSalary form = new AddSalary())
            {
                DialogResult dr = form.ShowDialog();
                if (dr == DialogResult.OK)
                {

                }
            }
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


    }
}
