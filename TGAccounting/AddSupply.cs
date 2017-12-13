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
    public partial class AddSupply : Form
    {
        public AddSupply()
        {
            InitializeComponent();
            autocomplete();
            fillUp(Convert.ToDateTime(DateTime.Now.Date));
        }
        private void fillUp(DateTime d)
        {
            int week = Helper.GetIso8601WeekOfYear(d);
            weekLbl.Text = week.ToString();
            string mylast = startLbl.Text = Helper.FirstDateOfWeek(d.Year, Convert.ToInt32(week), CultureInfo.CurrentCulture).Date.ToString("yyyy-MM-dd");
            string myStart = Convert.ToDateTime(startLbl.Text).AddDays(7).Date.ToString("yyyy-MM-dd");

            endLbl.Text = mylast;
            startLbl.Text = Convert.ToDateTime(mylast).AddDays(-7).Date.ToString("yyyy-MM-dd");

        }
        private void autocomplete()
        {
            AutoCompleteStringCollection AutoItem = new AutoCompleteStringCollection();
            foreach (Supplies r in Supplies.List("SELECT * from supplies").GroupBy(x => x.Supplier, (key, group) => group.First()))
            {
                AutoItem.Add(r.Supplier);
            }
            itemTxt.AutoCompleteMode = AutoCompleteMode.Suggest;
            itemTxt.AutoCompleteSource = AutoCompleteSource.CustomSource;
            itemTxt.AutoCompleteCustomSource = AutoItem;


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
                return;            }

            string ID = Guid.NewGuid().ToString();
            Supplies i = new Supplies(ID, dateTxt.Text, weekLbl.Text, startLbl.Text, endLbl.Text, itemTxt.Text, Convert.ToDouble(amountTxt.Text));
            DBConnect.Insert(i);
            MessageBox.Show("Information Saved ");
            itemTxt.Text = "";
            amountTxt.Text = "";
            autocomplete();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Dispose();
        }
        private void dateTxt_CloseUp(object sender, EventArgs e)
        {
            fillUp(Convert.ToDateTime(dateTxt.Text));
        }
    }
}
