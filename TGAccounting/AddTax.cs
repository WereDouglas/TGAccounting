using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TGAccounting.Model;

namespace TGAccounting
{
    public partial class AddTax : Form
    {
        public AddTax()
        {
            InitializeComponent();
            autocomplete();
            fillUp(Convert.ToDateTime(DateTime.Now.Date));
        }
        private void fillUp(DateTime d)
        {

            int week = GetIso8601WeekOfYear(d);
            weekLbl.Text = week.ToString();
            string mylast = startLbl.Text = FirstDateOfWeek(d.Year, Convert.ToInt32(week), CultureInfo.CurrentCulture).Date.ToString("yyyy-MM-dd");
            string myStart = Convert.ToDateTime(startLbl.Text).AddDays(7).Date.ToString("yyyy-MM-dd");

            endLbl.Text = mylast;
            startLbl.Text = Convert.ToDateTime(mylast).AddDays(-7).Date.ToString("yyyy-MM-dd");

        }
        public static int GetIso8601WeekOfYear(DateTime time)
        {
            DayOfWeek day = CultureInfo.InvariantCulture.Calendar.GetDayOfWeek(time);
            if (day >= DayOfWeek.Monday && day <= DayOfWeek.Wednesday)
            {
                time = time.AddDays(3);
            }

            return CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(time, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
        }

        public static DateTime FirstDateOfWeek(int year, int weekOfYear, System.Globalization.CultureInfo ci)
        {
            DateTime jan1 = new DateTime(year, 1, 1);
            int daysOffset = (int)ci.DateTimeFormat.FirstDayOfWeek - (int)jan1.DayOfWeek;
            DateTime firstWeekDay = jan1.AddDays(daysOffset);
            int firstWeek = ci.Calendar.GetWeekOfYear(jan1, ci.DateTimeFormat.CalendarWeekRule, ci.DateTimeFormat.FirstDayOfWeek);
            if ((firstWeek <= 1 || firstWeek >= 52) && daysOffset >= -3)
            {
                weekOfYear -= 1;
            }
            return firstWeekDay.AddDays(weekOfYear * 7);
        }
        private void autocomplete()
        {
            AutoCompleteStringCollection AutoItem = new AutoCompleteStringCollection();
            foreach (Taxes r in Taxes.List("SELECT * from taxes").GroupBy(x => x.Name, (key, group) => group.First()))
            {
                AutoItem.Add(r.Name);
            }
            itemTxt.AutoCompleteMode = AutoCompleteMode.Suggest;
            itemTxt.AutoCompleteSource = AutoCompleteSource.CustomSource;
            itemTxt.AutoCompleteCustomSource = AutoItem;


        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(amountTxt.Text))
            {
                amountTxt.BackColor = Color.Red;
                return;
            }
            if (string.IsNullOrEmpty(itemTxt.Text))
            {
                itemTxt.BackColor = Color.Red;
                return;
            }

            string ID = Guid.NewGuid().ToString();
            Taxes i = new Taxes(ID, dateTxt.Text, weekLbl.Text, startLbl.Text, endLbl.Text, itemTxt.Text, Convert.ToDouble(amountTxt.Text));
            DBConnect.Insert(i);
            MessageBox.Show("Information Saved ");
            itemTxt.Text = "";
            amountTxt.Text = "";
        }

        private void dateTxt_CloseUp(object sender, EventArgs e)
        {
            fillUp(Convert.ToDateTime(dateTxt.Text));
        }
    }
}
