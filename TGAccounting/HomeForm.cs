using System;
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
           
            InitializeComponent();

            LoadingWindow.ShowSplashScreen();
            Global.LoadData();
            LoadingWindow.CloseForm();
            LoadingCalendarLite();

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
            else {

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

            List<Events> events = new List<Events>(Global.events);

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
                    if (!string.IsNullOrEmpty(categoryCbx.Text)) {
                        tabControl1.SelectedTab = tabInventory;
                        string query4 = "SELECT * FROM inventory  WHERE date = '" + Helper.CurrentYear + "' AND category = '" + categoryCbx.Text + "'";
                        this.InventoryBindingSource.DataSource = Inventory.List(query4);
                        reportViewerInventory.RefreshReport();
                    }

                }
            }
        }
        private void autocompleteCategory()
        {
            categoryCbx.Items.Clear();
            AutoCompleteStringCollection AutoItem = new AutoCompleteStringCollection();
            foreach (var r in Global.categories)
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


                }
            }
        }

        private void button15_Click_1(object sender, EventArgs e)
        {
            Report r = new Report();
            int week = Convert.ToInt32(Convert.ToInt32(weekTxt.Text));
            string year = Helper.CurrentYear;
            string date = "";
            reports = new List<Report>();
            string ending = "";

            double totalPayRoll = 0;
            double totalPayRollYTD = 0;
            double totalCogs = 0;
            double totalCogsYTD = 0;
            double totalComps = 0;
            double totalCompsYTD = 0;
            double totalSales = 0;
            double totalSalesYTD = 0;
            double totalTaxes = 0;
            double totalTaxesYTD = 0;
            double totalExpenses = 0;
            double totalExpensesYTD = 0;

            double totalEquip = 0;
            double totalEquipYTD = 0;
            foreach (Sale s in Sale.List("SELECT * FROM sale  WHERE week ='" + week + "'  AND date= '" + Helper.CurrentYear + "' "))
            {
                double sums = Sale.List("SELECT * FROM sale  WHERE week ='" + week + "' ").Sum(t => t.Amount);
                double p1 = Math.Round((s.Amount / sums) * 100, 1);
                double ytd = Sale.List("SELECT * FROM sale WHERE CAST(week AS INTEGER) <='" + week + "'  AND item='" + s.Item + "'  AND date= '" + Helper.CurrentYear + "' ").Sum(t => t.Amount);

                
                totalSales = totalSales + sums;
                totalSalesYTD = totalSalesYTD + ytd;

                ending = Convert.ToDateTime(s.Ending).ToString("dd-MMM-yy");
                date = s.Date;
                double p2 = Math.Round((s.Amount / sums) * 100, 1);
                r = new Report(s.Date, s.Week, Convert.ToDateTime(s.Ending).ToString("dd-MMM-yy"), "Sales", s.Item, s.Amount, p1, ytd, p2, "Sales", "Income", 1,1);
                reports.Add(r);
            }

            foreach (Cogs s in Cogs.List("SELECT * FROM cogs  WHERE week ='" + week + "'  AND date= '" + Helper.CurrentYear + "' "))
            {
                double sums = Cogs.List("SELECT * FROM cogs  WHERE week ='" + week + "'  AND date= '" + Helper.CurrentYear + "' ").Sum(t => t.Cost);
                double p1 = Math.Round((s.Cost / sums) * 100, 1);
                double ytd = Cogs.List("SELECT * FROM cogs  WHERE CAST(week AS INTEGER) <='" + week + "'  AND category='" + s.Category + "'  AND date= '" + Helper.CurrentYear + "' ").Sum(t => t.Cost);

                double p2 = Math.Round((s.Cost / sums) * 100, 1);
                r = new Report(s.Date, s.Week, Convert.ToDateTime(s.Ending).ToString("dd-MMM-yy"), "Cost of goods sold", s.Category, s.Cost, p1, ytd, p2, "Cost of goods", "Cost of goods", 2,1);
                reports.Add(r);
                totalCogs = totalCogs + sums;
                totalCogsYTD = totalCogsYTD + ytd;
            }
            foreach (Comp s in Comp.List("SELECT * FROM comp  WHERE week ='" + week + "'  AND date= '" + Helper.CurrentYear + "' "))
            {
                double sums = Comp.List("SELECT * FROM comp  WHERE week ='" + week + " 'AND item='" + s.Item + "'  AND date= '" + Helper.CurrentYear + "' ").Sum(t => t.Amount);
                double p1 = Math.Round((s.Amount / sums) * 100, 1);
                double ytd = Comp.List("SELECT * FROM comp  WHERE CAST(week AS INTEGER) <='" + week + "'  AND item='" + s.Item + "'  AND date= '" + Helper.CurrentYear + "' ").Sum(t => t.Amount);

                double p2 = Math.Round((s.Amount / sums) * 100, 1);
                r = new Report(s.Date, s.Week, Convert.ToDateTime(s.Ending).ToString("dd-MMM-yy"), "Complimentaries", s.Item, s.Amount, p1, ytd, p2, "Complimentary", "Cost of goods", 2, 2);
                reports.Add(r);
                totalComps = totalComps + sums;
                totalCompsYTD = totalCompsYTD + ytd;
            }

            /**Computing the Gross profit*/

            double Gross = totalSales - (totalCogs + totalComps);
            double GrossYTD = totalSalesYTD - (totalCogsYTD + totalCompsYTD);

            double p1Gross = Math.Round((Gross / totalSales) * 100, 1);
            double p2Gross = Math.Round((GrossYTD / totalSalesYTD) * 100, 1);

            r = new Report(date, Convert.ToInt32(weekTxt.Text), ending, "Gross Profits", "Gross Profit", Gross, p1Gross, GrossYTD, p2Gross, "Gross Profit", "Gross Profit", 3,1);
            reports.Add(r);

            /**End of Gross ***/
            foreach (Labor l in Labor.List("SELECT * FROM labor  WHERE week ='" + week + "'  AND date= '" + Helper.CurrentYear + "' "))
            {
                double sums = Labor.List("SELECT * FROM labor  WHERE week ='" + week + "'  AND date= '" + Helper.CurrentYear + "' ").Sum(t => t.Amount);
                double p1 = Math.Round((l.Amount / sums) * 100, 1);
                double ytd = Labor.List("SELECT * FROM labor  WHERE CAST(week AS INTEGER) <='" + week + "' AND item='" + l.Item + "'  AND date= '" + Helper.CurrentYear + "' ").Sum(t => t.Amount);
                date = l.Date;
                double p2 = Math.Round((l.Amount / sums) * 100, 1);
                r = new Report(l.Date, l.Week, Convert.ToDateTime(l.Ending).ToString("dd-MMM-yy"), "Salaries & Wages", l.Item, l.Amount, p1, ytd, p2, "Payroll", "Expense", 4,1);
                reports.Add(r);

                totalPayRoll = totalPayRoll + sums;
                totalPayRollYTD = totalPayRollYTD + ytd;
            }
            foreach (Taxes l in Taxes.List("SELECT * FROM taxes  WHERE week ='" + week + "' AND date= '" + Helper.CurrentYear + "' "))
            {
                double sums = Taxes.List("SELECT * FROM taxes  WHERE week ='" + week + "'  AND date= '" + Helper.CurrentYear + "' ").Sum(t => t.Amount);
                double p1 = Math.Round((l.Amount / sums) * 100, 1);
                double ytd = Taxes.List("SELECT * FROM taxes  WHERE CAST(week AS INTEGER) <='" + week + "' AND name='" + l.Name + "'  AND date= '" + Helper.CurrentYear + "' ").Sum(t => t.Amount);

                double p2 = Math.Round((l.Amount / sums) * 100, 1);
                r = new Report(l.Date, l.Week,Convert.ToDateTime(l.Ending).ToString("dd-MMM-yy"), "Employee Benefits", l.Name, l.Amount, p1, ytd, p2, "Payroll", "Expense",5,1);
                reports.Add(r);
               
                totalTaxes = totalTaxes + sums;
                totalTaxesYTD = totalTaxesYTD + ytd;

                totalPayRoll = totalPayRoll + sums;
                totalPayRollYTD = totalPayRollYTD + ytd;
            }

            /**Computing the prime costs*/
            totalCogsYTD = Cogs.List("SELECT * FROM cogs  WHERE CAST(week AS INTEGER) <='" + week + "'  AND date= '" + Helper.CurrentYear + "'").Sum(t => t.Cost);
            totalCogs = Cogs.List("SELECT * FROM cogs  WHERE CAST(week AS INTEGER) ='" + week + "'  AND date= '" + Helper.CurrentYear + "'").Sum(t => t.Cost);

            double prime = totalCogs + totalPayRoll;
            double p1Prime = Math.Round((prime / totalSales) * 100, 1);
            double p2Prime = Math.Round((totalCogsYTD / totalSalesYTD) * 100, 1);

            r = new Report(date, Convert.ToInt32(Convert.ToInt32(weekTxt.Text)), Convert.ToDateTime(ending).ToString("dd-MMM-yy"), "Prime Cost", "Prime Cost", prime, p1Prime, totalSalesYTD, p2Prime, "Prime Cost", "Prime Cost", 6,1);
            reports.Add(r);
            /**end of prime costs***/

            /*Controllable Expenses*/
            foreach (Supplies s in Supplies.List("SELECT * FROM supplies  WHERE week ='" + week + "'  AND date= '" + Helper.CurrentYear + "' "))
            {
                double sums = Supplies.List("SELECT * FROM supplies  WHERE week ='" + week + "' AND date= '" + Helper.CurrentYear + "' ").Sum(t => t.Amount);
                double p1 = Math.Round((s.Amount / sums) * 100, 1);
                double ytd = Supplies.List("SELECT * FROM supplies  WHERE CAST(week AS INTEGER) <='" + week + "'  AND supplier='" + s.Supplier + "'  AND date= '" + Helper.CurrentYear + "' ").Sum(t => t.Amount);

                double p2 = Math.Round((s.Amount / sums) * 100, 1);
                r = new Report(s.Date, s.Week,Convert.ToDateTime(s.Ending).ToString("dd-MMM-yy"), "Supplies", s.Supplier, s.Amount, p1, ytd, p2, "Other Controllable Expenses", "Expense",7,1);
                reports.Add(r);
                totalExpenses = totalExpenses + sums;
                totalExpensesYTD = totalExpensesYTD + ytd;
            }
            foreach (Repair s in Repair.List("SELECT * FROM repair  WHERE week ='" + week + "'  AND date= '" + Helper.CurrentYear + "' "))
            {
                double sums = Repair.List("SELECT * FROM repair  WHERE week ='" + week + "'  AND date= '" + Helper.CurrentYear + "' ").Sum(t => t.Amount);
                double p1 = Math.Round((s.Amount / sums) * 100, 1);
                double ytd = Repair.List("SELECT * FROM repair  WHERE CAST(week AS INTEGER) <='" + week + "'  AND supplier='" + s.Supplier + "'  AND date= '" + Helper.CurrentYear + "' ").Sum(t => t.Amount);

                double p2 = Math.Round((s.Amount / sums) * 100, 1);
                r = new Report(s.Date, s.Week, Convert.ToDateTime(s.Ending).ToString("dd-MMM-yy"), "Repair and maintenance", s.Supplier, s.Amount, p1, ytd, p2, "Other Controllable Expenses", "Expense", 7,2);
                reports.Add(r);
                totalExpenses = totalExpenses + sums;
                totalExpensesYTD = totalExpensesYTD + ytd;
            }
            foreach (Expense s in Expense.List("SELECT * FROM expense  WHERE week ='" + week + "' AND date= '" + Helper.CurrentYear + "' "))
            {
                double sums = Expense.List("SELECT * FROM expense  WHERE week ='" + week + "' AND date= '" + Helper.CurrentYear + "' ").Sum(t => t.Amount);
                double p1 = Math.Round((s.Amount / sums) * 100, 1);
                double ytd = Expense.List("SELECT * FROM expense  WHERE CAST(week AS INTEGER) <='" + week + "'  AND name='" + s.Name + "'  AND date= '" + Helper.CurrentYear + "' ").Sum(t => t.Amount);

                double p2 = Math.Round((s.Amount / sums) * 100, 1);
                r = new Report(s.Date, s.Week, Convert.ToDateTime(s.Ending).ToString("dd-MMM-yy"), s.Category, s.Name, s.Amount, p1, ytd, p2, "Other Controllable Expenses", "Expense", 7,3);
                reports.Add(r);
                totalExpenses = totalExpenses + sums;
                totalExpensesYTD = totalExpensesYTD + ytd;
            }
            /**Computing Controllable Expenses*/

            double ctrl = totalPayRoll + totalExpenses;
            double ctrlYTD = totalPayRollYTD + totalExpenses;

            double p1Ctrl = Math.Round((prime / totalSales) * 100, 1);
            double p2Ctrl = Math.Round((totalCogsYTD / totalSalesYTD) * 100, 1);

            r = new Report(date, Convert.ToInt32(weekTxt.Text), ending, "Controllable Expenses", "Controllable Expense", ctrl, p1Ctrl, ctrlYTD, p2Ctrl, "Controllable Expenses", "Controllable",8,1);
            reports.Add(r);
            /**end of  Controllable Expenses***/

            /**Controllable profit*/
            double ctrlProfit = Gross - ctrl;
            double ctrlProfitYTD = GrossYTD - ctrlYTD;
            double p1CtrlProfit = Math.Round((ctrlProfit / totalSales) * 100, 1);
            double p2CtrlProfit = Math.Round((ctrlProfitYTD / totalSalesYTD) * 100, 1);

            r = new Report(date, Convert.ToInt32(weekTxt.Text), Convert.ToDateTime(ending).ToString("dd-MMM-yy"), "Controllable Profits", "Controllable Profits", ctrlProfit, p1CtrlProfit, ctrlProfitYTD, p2CtrlProfit, "Controllable Profit", "Controllable",9,1);
            reports.Add(r);

            /*end of controllable profit*/


            foreach (Equipment s in Equipment.List("SELECT * FROM equipment  WHERE week ='" + week + "' AND date= '" + Helper.CurrentYear + "' "))
            {
                double sums = Equipment.List("SELECT * FROM equipment  WHERE week ='" + week + "' AND date= '" + Helper.CurrentYear + "' ").Sum(t => t.Amount);
                double p1 = Math.Round((s.Amount / sums) * 100, 1);
                double ytd = Equipment.List("SELECT * FROM equipment  WHERE CAST(week AS INTEGER) <='" + week + "'  AND name='" + s.Name + "'  AND date= '" + Helper.CurrentYear + "' ").Sum(t => t.Amount);

                double p2 = Math.Round((s.Amount / sums) * 100, 1);
                r = new Report(s.Date, s.Week, Convert.ToDateTime(s.Ending).ToString("dd-MMM-yy"), "Equipment & Improvements", s.Name, s.Amount, p1, ytd, p2, "Equipment & Improvements", "Equipment & Improvements", 10,1);
                reports.Add(r);
                totalEquip = totalEquip + sums;
                totalEquipYTD = totalEquipYTD + ytd;

            }
          
            double occupancyExpense = Expense.List("SELECT * FROM expense  WHERE week ='" + week + "' AND category='Occupancy Expenses'  AND date= '" + Helper.CurrentYear + "' ").Sum(t => t.Amount);
            double occupancyExpenseYTD = Expense.List("SELECT * FROM expense WHERE CAST(week AS INTEGER) ='" + week + "' AND category='Occupancy Expenses'  AND date= '" + Helper.CurrentYear + "' ").Sum(t => t.Amount);

            double restProfit = ctrlProfit - occupancyExpense - totalEquip;
            double restProfitYTD = ctrlProfit - occupancyExpenseYTD - totalEquipYTD;

            double p1RestProfit = Math.Round((restProfit / totalSales) * 100, 1);
            double p2RestProfit = Math.Round((restProfitYTD / totalSalesYTD) * 100, 1);



            /** Occupancy Expenses**/
            double p1Occupancy = Math.Round((occupancyExpense / totalSales) * 100, 1);
            double p2OCCupancy = Math.Round((occupancyExpenseYTD / totalSalesYTD) * 100, 1);
            r = new Report(date, Convert.ToInt32(weekTxt.Text), Convert.ToDateTime(ending).ToString("dd-MMM-yy"), "Occupancy Expenses", "Occupancy Expenses", occupancyExpense, p1Occupancy, occupancyExpenseYTD, p2RestProfit, "Occupancy Expenses", "Occupancy Expenses", 11,1);
            reports.Add(r);
            /*End of occupancy*/


            /** restaurant profit**/
            r = new Report(date, Convert.ToInt32(weekTxt.Text),Convert.ToDateTime(ending).ToString("dd-MMM-yy"), "Restaurant Profit", "Restaurant Profit", restProfit, p1RestProfit, restProfitYTD, p2RestProfit, "Restaurant Profit", "Restaurant Profit", 12,1);
            reports.Add(r);
            /** end restaurant profit**/

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
