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
            if (!string.IsNullOrEmpty(Helper.CurrentStarting) && !string.IsNullOrEmpty(Helper.CurrentEnding))
            {
                session();
            }
            else
            {
                fillUp(Convert.ToDateTime(DateTime.Now.Date));
            }
        }
        string month;
        private void fillUp(DateTime d)
        {
            month = d.ToString("MMMM");
            int year = Convert.ToInt32(d.ToString("yyyy"));
           
            int week = Helper.GetIso8601WeekOfYear(d);
            weekLbl.Text = week.ToString();
            startLbl.Text = Helper.FirstDateOfWeek(year, week).Date.ToString("dd-MM-yyyy");
            endLbl.Text = Convert.ToDateTime(startLbl.Text).AddDays(+6).Date.ToString("dd-MM-yyyy");
            Helper.CurrentWeek = week;
            Helper.CurrentStarting = startLbl.Text;
            Helper.CurrentEnding = endLbl.Text;
        }
        private void session()
        {
            weekLbl.Text = Helper.CurrentWeek.ToString();
            startLbl.Text = Helper.CurrentStarting;
            endLbl.Text = Helper.CurrentEnding;
        }
        private void autocompleteCategory()
        {
            categoryTxt.Items.Clear();
            AutoCompleteStringCollection AutoItem = new AutoCompleteStringCollection();
            foreach (var r in Global.categories)
            {
                AutoItem.Add(r);
                categoryTxt.Items.Add(r);
            }
            categoryTxt.AutoCompleteMode = AutoCompleteMode.Suggest;
            categoryTxt.AutoCompleteSource = AutoCompleteSource.CustomSource;
            categoryTxt.AutoCompleteCustomSource = AutoItem;
        }


        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void dateTxt_ValueChanged(object sender, EventArgs e)
        {
            fillUp(Convert.ToDateTime(dateTxt.Text));
            categoryTxt_SelectedIndexChanged(null, null);
           
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
        string existingID = "";
        private void categoryTxt_SelectedIndexChanged(object sender, EventArgs e)
        {
            int prevWeek = Convert.ToInt32(weekLbl.Text) - 1;
            try
            {
                begTxt.Text = Cogs.List("SELECT * from cogs WHERE category = '" + categoryTxt.Text + "'").Where(k => k.Week == prevWeek).First().EndingInventory.ToString();
            }
            catch
            {
                begTxt.Text = "0";
                try
                {
                    begTxt.Text = Cogs.List("SELECT * from cogs WHERE category='" + categoryTxt.Text + "' AND week = '" + weekLbl.Text + "' AND date = '" + Convert.ToDateTime(dateTxt.Text).Year.ToString() + "'").First().BeginningInventory.ToString();
                }
                catch { }
            }
            try
            {

                endTxt.Text = Cogs.List("SELECT * from cogs WHERE category='" + categoryTxt.Text + "' AND week = '" + weekLbl.Text + "' AND date = '" + Convert.ToDateTime(dateTxt.Text).Year.ToString() + "'").First().EndingInventory.ToString();
            }
            catch (Exception y)
            {
                // Helper.Exceptions(y.Message, "on adding inventory auto fill the category list selected item");
            }
            try
            {

                cogsTxt.Text = Cogs.List("SELECT * from cogs WHERE category='" + categoryTxt.Text + "' AND week = '" + weekLbl.Text + "' AND date = '" + Convert.ToDateTime(dateTxt.Text).Year.ToString() + "'").First().Cost.ToString();
            }
            catch (Exception y)
            {
                // Helper.Exceptions(y.Message, "on adding inventory auto fill the category list selected item");
            }
            try
            {

                month = Cogs.List("SELECT * from cogs WHERE category='" + categoryTxt.Text + "' AND week = '" + weekLbl.Text + "' AND date = '" + Convert.ToDateTime(dateTxt.Text).Year.ToString() + "'").First().Month;
            }
            catch (Exception y)
            {
                // Helper.Exceptions(y.Message, "on adding inventory auto fill the category list selected item");
            }
            try
            {

                existingID = Cogs.List("SELECT * from cogs WHERE category='" + categoryTxt.Text + "' AND week = '" + weekLbl.Text + "' AND date = '" + Convert.ToDateTime(dateTxt.Text).Year.ToString() + "'").First().Id.ToString();
            }
            catch (Exception y)
            {
                // Helper.Exceptions(y.Message, "on adding inventory auto fill the category list selected item");
            }
        }

        private void endTxt_TextChanged(object sender, EventArgs e)
        {
            double purchase = 0;
            try
            {

                purchase = Inventory.List("SELECT * from inventory WHERE category= '" + categoryTxt.Text + "' AND week = '" + weekLbl.Text + "' AND date = '" + Convert.ToDateTime(dateTxt.Text).Year.ToString() + "'").Sum(t => t.Amount);

            }
            catch
            {

                MessageBox.Show("Please input the purchases for " + categoryTxt.Text);
                return;
            }
            try
            {


                cogsTxt.Text = (Math.Round((Convert.ToDouble(begTxt.Text) + Math.Round(purchase, 2)) - Convert.ToDouble(endTxt.Text), 2)).ToString();

            }
            catch
            {

                //  MessageBox.Show("Please input the purchases for " + categoryTxt.Text);
               // cogsTxt.BackColor = Color.Red;
                return;
            }
        }

        private void begTxt_KeyPress(object sender, KeyPressEventArgs e)
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

        private void button4_Click(object sender, EventArgs e)
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
            if (!string.IsNullOrEmpty(existingID))
            {

                if (MessageBox.Show("YES or No?", "Are you sure you want to update the current existing information  ? ", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    Cogs j = new Cogs(existingID, Convert.ToDateTime(dateTxt.Text).Year.ToString(), Convert.ToInt32(weekLbl.Text), startLbl.Text, endLbl.Text, categoryTxt.Text, Convert.ToDouble(begTxt.Text), Convert.ToDouble(endTxt.Text), Convert.ToDouble(cogsTxt.Text), month);
                    DBConnect.Update(j, existingID);
                    existingID = "";
                    return;
                }
                else {

                    return;
                }
            }
            existingID = "";
            string ID = Guid.NewGuid().ToString();
            Cogs i = new Cogs(ID, Convert.ToDateTime(dateTxt.Text).Year.ToString(), Convert.ToInt32(weekLbl.Text), startLbl.Text, endLbl.Text, categoryTxt.Text, Convert.ToDouble(begTxt.Text), Convert.ToDouble(endTxt.Text), Convert.ToDouble(cogsTxt.Text), month);
            DBConnect.Insert(i);
            MessageBox.Show("Information Saved ");
            categoryTxt.Text = "";
            endTxt.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Dispose();
        }
    }
}
