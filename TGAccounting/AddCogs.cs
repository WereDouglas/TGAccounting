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
    public partial class AddCogs : Form
    {
        public AddCogs()
        {
            InitializeComponent();
            autocompleteCategory();
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
        private void autocompleteCategory()
        {
            categoryTxt.Items.Clear();
            AutoCompleteStringCollection AutoItem = new AutoCompleteStringCollection();
            foreach (Inventory r in Inventory.List("SELECT * from inventory").GroupBy(x => x.Category, (key, group) => group.First()))
            {
                AutoItem.Add(r.Category);
                categoryTxt.Items.Add(r.Category);
            }
            categoryTxt.AutoCompleteMode = AutoCompleteMode.Suggest;
            categoryTxt.AutoCompleteSource = AutoCompleteSource.CustomSource;
            categoryTxt.AutoCompleteCustomSource = AutoItem;


        }


        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Dispose();
        }

        private void dateTxt_ValueChanged(object sender, EventArgs e)
        {
            fillUp(Convert.ToDateTime(dateTxt.Text));
            categoryTxt_SelectedIndexChanged(null, null);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(endTxt.Text))
            {
                endTxt.BackColor = Color.Red;
                return;
            }
            if (string.IsNullOrEmpty(categoryTxt.Text))
            {
                categoryTxt.BackColor = Color.Red;
                return;
            }

            string ID = Guid.NewGuid().ToString();
            Cogs i = new Cogs(ID, dateTxt.Text, weekLbl.Text, startLbl.Text, endLbl.Text,categoryTxt.Text, Convert.ToDouble(begTxt.Text), Convert.ToDouble(endTxt.Text), Convert.ToDouble(cogsTxt.Text));
            DBConnect.Insert(i);
            MessageBox.Show("Information Saved ");
            categoryTxt.Text = "";
            endTxt.Text = "";
        }

        private void categoryTxt_SelectedIndexChanged(object sender, EventArgs e)
        {
            int prevWeek = Convert.ToInt32(weekLbl.Text) - 1;
            try
            {
                 begTxt.Text = Cogs.List("SELECT * from cogs").Where(k=>k.Week.Contains(prevWeek.ToString())).First().EndingInventory.ToString();
            }
            catch
            {
                  begTxt.Text = "0";
            }
        }

        private void endTxt_TextChanged(object sender, EventArgs e)
        {
            double purchase = 0;
            try { 
             purchase = Inventory.List("SELECT * from inventory WHERE category= '" + categoryTxt.Text + "' AND week = '" + weekLbl.Text + "'").Sum(t => t.Amount);
            }
            catch
            {

                MessageBox.Show("Please input the purchases for " + categoryTxt.Text );
                return;
            }
            try {
               

                cogsTxt.Text = ((Convert.ToDouble(begTxt.Text) + purchase) -  Convert.ToDouble(endTxt.Text)).ToString("N0");

            } catch {


            }
        }
    }
}
