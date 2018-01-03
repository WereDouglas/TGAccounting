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
            startLbl.Text = Helper.GetFirstDayOfWeek(d, CultureInfo.CurrentCulture).Date.ToString("dd-MM-yyyy");

            string mylast = startLbl.Text;
            string myStart = Convert.ToDateTime(startLbl.Text).AddDays(-7).Date.ToString("dd-MM-yyyy");
            startLbl.Text = Convert.ToDateTime(startLbl.Text).AddDays(-7).Date.ToString("dd-MM-yyyy");
            endLbl.Text = Helper.GetFirstDayOfWeek(d, CultureInfo.CurrentCulture).Date.ToString("dd-MM-yyyy");
            // startLbl.Text = Convert.ToDateTime(mylast).AddDays(-7).Date.ToString("dd-MM-yyyy");

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
                return;
            }
            if (!string.IsNullOrEmpty(existingID))
            {
                if (MessageBox.Show("YES or No?", "Are you sure you want to update the current existing information  ? ", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    Supplies j = new Supplies(existingID, Convert.ToDateTime(dateTxt.Text).Year.ToString(), weekLbl.Text, startLbl.Text, endLbl.Text, itemTxt.Text, Convert.ToDouble(amountTxt.Text));
                    DBConnect.Update(j, existingID);
                    existingID = "";
                    return;
                }
            }
            existingID = "";

            string ID = Guid.NewGuid().ToString();
            Supplies i = new Supplies(ID, Convert.ToDateTime(dateTxt.Text).Year.ToString(), weekLbl.Text, startLbl.Text, endLbl.Text, itemTxt.Text, Convert.ToDouble(amountTxt.Text));
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

        private void amountTxt_KeyUp(object sender, KeyEventArgs e)
        {


        }
        string existingID = "";
        private void itemTxt_Leave(object sender, EventArgs e)
        {
            try
            {

                amountTxt.Text = Supplies.List("SELECT * from supplies WHERE supplier='" + itemTxt.Text + "' AND week = '" + weekLbl.Text + "' AND date = '" + Convert.ToDateTime(dateTxt.Text).Year.ToString() + "'").First().Amount.ToString();
            }
            catch (Exception y)
            {
                // Helper.Exceptions(y.Message, "on adding inventory auto fill the category list selected item");
            }
            try
            {

                existingID = Supplies.List("SELECT * from supplies WHERE supplier='" + itemTxt.Text + "' AND week = '" + weekLbl.Text + "' AND date = '" + Convert.ToDateTime(dateTxt.Text).Year.ToString() + "'").First().Id.ToString();
            }
            catch (Exception y)
            {
                // Helper.Exceptions(y.Message, "on adding inventory auto fill the category list selected item");
            }
        }
    }
}
